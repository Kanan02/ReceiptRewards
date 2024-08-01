using System.Reflection;
using ReceiptRewards.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Infrastructure.DataAccess.Contexts;

public class ReceiptRewardsAPIDbContext: DbContext
{
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Present> Presents { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<AdditionalProperty> AdditionalProperties { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }

    public ReceiptRewardsAPIDbContext(DbContextOptions<ReceiptRewardsAPIDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<User>().HasData(
        new User
        {
            Id = -1,
            Name = "AdminName",
            Surname = "AdminSurname",
            Msisdn = "994506607883",
            Email = "ilkindenziyev@gmail.com",
            Address = "myaddress",
            Password = "Admin123@",
            Role = Role.Admin,
            Instagram = "admin"
        });
        modelBuilder.Entity<Present>().HasData(
            new Present
            {
                Id = 1,
                Name = "TESS çanta",
                Quantity = 200,
                Price = 1500
            },
            new Present
            {
                Id = 2,
                Name = "TESS fincan",
                Quantity = 200,
                Price = 2000
            },
            new Present
            {
                Id = 3,
                Name = "TESS T-Shirt",
                Quantity = 200,
                Price = 2200
            },
            new Present
            {
                Id = 4,
                Name = "TESS hədiyyə dəsti",
                Quantity = 200,
                Price = 3500
            },
            new Present
            {
                Id = 5,
                Name = "TESS uçuş yastğı",
                Quantity = 200,
                Price = 4500
            },
            new Present
            {
                Id = 6,
                Name = "TESS bel çanatası",
                Quantity = 200,
                Price = 6500
            },
            new Present
            {
                Id = 7,
                Name = "TESS idman çantası",
                Quantity = 200,
                Price = 7000
            },
            new Present
            {
                Id = 8,
                Name = "TESS gödəkçə",
                Quantity = 200,
                Price = 8000
            }
        );

        base.OnModelCreating(modelBuilder);
    }



}
