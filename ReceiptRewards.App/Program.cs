using System.Text;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using ReceiptRewards.App.Helpers;
using ReceiptRewards.Application.Options;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Application.Services.Concrete;
using ReceiptRewards.Application.Services.QuartzService;
using ReceiptRewards.Application.Services.QuartzService.Jobs;
using ReceiptRewards.Domain.Messaging.Consumers;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Infrastructure.DataAccess.Contexts;
using ReceiptRewards.Infrastructure.DataAccess.Repositories;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TessTeaDb");

// Add services to the container.
builder.Services.AddDbContext<ReceiptRewardsAPIDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
///////////////////
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReceiptService, ReceiptService>();
builder.Services.AddScoped<IPresentService, PresentService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPropertyService,PropertyService>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<IStatisticsService,StatisticsService>();
///////////////////
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReceiptRepository, ReceiptRepository>();
builder.Services.AddScoped<IPresentRepository, PresentRepository>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddScoped<ILogRepository, LogRepository>();
///////////////////
builder.Services.AddHostedService<QuartzHostedService>();
builder.Services.AddSingleton<QuartzJobRunner>();
builder.Services.AddSingleton<IJobFactory, SingletonJobFactory>();
builder.Services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

builder.Services.AddHttpClient();
//0 */2 * ? * *
//0 0 6 * * ?
builder.Services.AddScoped<ApprovePendingPointsJob>().AddSingleton(
    new JobSchedule(jobType: typeof(ApprovePendingPointsJob), cronExpression: "0 0 6 * * ?"));

builder.Services
    .AddOptions<EmailOptions>()
    .Bind(builder.Configuration.GetSection(EmailOptions.Key));



builder.Services.Configure<MessageBrokerOptions>(
    builder.Configuration.GetSection("MessageBroker"));

builder.Services.AddSingleton(sp => 
    sp.GetRequiredService<IOptions<MessageBrokerOptions>>().Value);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();
    busConfigurator.AddConsumer<ReceiptAddedEventConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        var settings = context.GetRequiredService<MessageBrokerOptions>();

        configurator.Host(new Uri(settings.Host), h =>
        {
            h.Username(settings.Username);
            h.Password(settings.Password);
        });
        configurator.ReceiveEndpoint("receipt-queue",
            e =>
            {
                e.ConfigureConsumer<ReceiptAddedEventConsumer>(context);
            });
    });
});

builder.Services.AddTransient<IEventBus, EventBus>();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        }
    );
    opt.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        }
    );
});

var key = Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"] ?? string.Empty);
builder
    .Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddHttpContextAccessor();
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System
            .Text
            .Json
            .Serialization
            .ReferenceHandler
            .IgnoreCycles;
    });
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().SetIsOriginAllowed(_ => true).AllowAnyMethod();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Host.UseSerilog(
    (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors();
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware(typeof(ErrorHandlingMiddleware));

app.MapControllers();

app.Run();