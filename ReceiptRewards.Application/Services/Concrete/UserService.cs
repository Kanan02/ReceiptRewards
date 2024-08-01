using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ReceiptRewards.App.Helpers;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;
using ReceiptRewards.Domain.Messaging.Consumers;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Requests.Pagination;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Concrete;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IReceiptRepository _receiptRepository;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ILogger<UserService> _logger;

    private readonly IEmailService _emailService;

    // private readonly IOtpService _otpService;
    private readonly IConfiguration _configuration;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogRepository _logRepository;

    public UserService(
        IConfiguration configuration,
        IHttpContextAccessor contextAccessor,
        IUserRepository userRepository,
        IReceiptRepository receiptRepository,
        IEmailService emailService,
        IHttpClientFactory httpClientFactory,
        ILogger<UserService> logger, ILogRepository logRepository)
    {
        _configuration = configuration;
        _contextAccessor = contextAccessor;
        _userRepository = userRepository;
        _receiptRepository = receiptRepository;
        _emailService = emailService;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _logRepository = logRepository;
    }

    public async Task<ApiResponse> RegisterAsync(RegisterRequest request)
    {
        var existingUser = await _userRepository
            .GetAsync(u => u.Email == request.Email || u.Msisdn == request.Msisdn);

        if (existingUser is not null) 
        {
            await LogAsync(LogType.FailedRegistration.ToString());
            return new ApiResponse(new ApiError()
            {
                ErrorCode = "409",
                ErrorMsg = "A user with the same email or MSISDN already exists."
            });
        }

        User user = new()
        {
            RegisterDate = DateTime.Now,
            Address = request.Address,
            Email = request.Email,
            Msisdn = request.Msisdn,
            Instagram = request.Instagram,
            Name = request.Name,
            Surname = request.Surname,
            Password = request.Password,
            Operator = (Operator)await RequestHelper.GetDataFromUrl<int, UserService>(
                _configuration["MnpApiUrl"] + request.Msisdn, _logger, _httpClientFactory),
            Remaining = 50,
            Total = 50
        };

        
        
        await LogAsync(LogType.SuccessfulRegistration.ToString());
        await _userRepository.AddAsync(user);
        await _userRepository.SaveAsync();

        return new ApiResponse();
    }

    private async Task LogAsync(string logType)
    {
        await _logRepository.AddAsync(new ErrorLog(logType));
        await _logRepository.SaveAsync();
    }
    public async Task<ApiValueResponse<string>> LoginAsync(LoginRequest request)
    {
        var user = await GetUser(request);
        if (user == null)
        {
            await _logRepository.AddAsync(new ErrorLog(LogType.FailedLogin.ToString()));
            await _logRepository.SaveAsync();
           
        }
        if (!IsVerifiedUser(request))
        {
         
            return new ApiValueResponse<string>(Errors.UnverifiedUser);
        }

        var response = new ApiValueResponse<string> { Value = GenerateToken(user) };

        return response;
    }

    public async Task<ApiResponse> ChangePasswordAsync(ChangePasswordRequest request)
    {
        var userId = GetClaims().FirstOrDefault(x => x.Type == "userId")?.Value;
        var user = await _userRepository.GetAsync(x => x.Id == int.Parse(userId!));
        if (user.Password == request.OldPassword)
            user.Password = request.NewPassword;
        else
            return new ApiResponse(Errors.WrongPassword);
        await _userRepository.SaveAsync();

        return new ApiResponse();
    }

    public Task<ApiResponse> VerifyOtp(CheckOtpRequest request)
    {
        return null;
        // return _otpService.CheckPin(request);
    }

    public async Task<ApiValueResponse<UserResponse>> GetUserInfoAsync()
    {
        var userId = GetClaims().FirstOrDefault(x => x.Type == "userId")?.Value;

        var user = await _userRepository.GetAsync(x => x.Id == int.Parse(userId!), includes: nameof(User.Presents));

        return new ApiValueResponse<UserResponse>(new UserResponse(user));
    }

    public async Task<ApiValueResponse<UserResponse>> PutUserInfoAsync(UserPutRequest userRequest)
    {
        var userId = GetClaims().FirstOrDefault(x => x.Type == "userId")?.Value;
        var user = await _userRepository.GetAsync(x => x.Id == int.Parse(userId!));

        if (userRequest.Instagram != null)
        {
            user.Instagram = userRequest.Instagram;
        }

        if (userRequest.Address != null)
        {
            user.Address = userRequest.Address;
        }

        await _userRepository.SaveAsync();

        return new ApiValueResponse<UserResponse>(new UserResponse(user));
    }

    public async Task<ApiResponse> SendPassword(string msisdn)
    {
        var user = await _userRepository.GetAsync(x => x.Msisdn == msisdn);
        if (user == null)
            throw new CustomException("user_not_found");

        _emailService.Send(user.Password, user.Name, user.Email);

        return new ApiResponse();
    }

    public async Task<ApiValueResponse<List<UserResponse>>> GetUsersByFilter(UserFilterRequest request)
    {
        var allUsers = await _userRepository.GetAllAsync(includes: nameof(User.Presents));

        if (request is { StartDate: not null, EndDate: not null })
        {
            allUsers = allUsers.Where(c =>
                c.RegisterDate >= (DateTime)request.StartDate &&
                c.RegisterDate <= (DateTime)request.EndDate);
        }

        Search(ref allUsers, request.Name, request.Msisdn, request.Operator);
        // Order(ref allUsers, request.OrderBy);
        var list = await allUsers.Select(x => new UserResponse(x)).ToListAsync();
        // var pagedList = PagedList<UserResponse>.ToPagedList(list, request.PageNumber, request.PageSize);
        return new ApiValueResponse<List<UserResponse>>(list);
    }

    private void Search(ref IQueryable<User> allUsers, string? name, string? msisdn, Operator? op)
    {
        if (allUsers.Any() == false) return;

        if (string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(msisdn) && op == null) return;
        allUsers = allUsers.Where(c => (string.IsNullOrWhiteSpace(c.Name) || string.IsNullOrWhiteSpace(name) ||
                                        c.Name.ToLower().Contains(name.Trim().ToLower()))
                                       && (string.IsNullOrWhiteSpace(c.Msisdn) || string.IsNullOrWhiteSpace(msisdn) ||
                                           c.Msisdn.Contains(msisdn)
                                       )
                                       && (op == null || op == c.Operator)
        );
    }


    private async Task<User> GetUser(LoginRequest request)
    {
        return await _userRepository.GetAsync(u =>
            u.Msisdn == request.Msisdn.Trim() && u.Password == request.Password
        );
    }

    private bool IsVerifiedUser(LoginRequest request)
    {
        var userobj = _userRepository.GetAsync(u =>
                u.Msisdn == request.Msisdn.Trim()
                && u.Password == request.Password
            // && u.IsOtpVerified == true
        );

        return userobj != null;
    }

    private string GenerateToken(User user)
    {
        var jwtKey = _configuration["JwtSettings:SecretKey"];
        var issuer = _configuration["JwtSettings:Issuer"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("userId", user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var token = new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires: DateTime.Now.AddHours(24),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private List<Claim> GetClaims()
    {
        return _contextAccessor.HttpContext!.User.Claims.ToList();
    }
}