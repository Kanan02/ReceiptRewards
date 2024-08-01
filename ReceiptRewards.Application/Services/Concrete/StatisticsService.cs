using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.Application.Services.Concrete
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IReceiptService _receiptService;
        private readonly IPropertyService _propertyService;
        private readonly ILogRepository _logRepository;


        public StatisticsService(IUserService userService, IProductService productService,
            IReceiptService receiptService, IPropertyService propertyService,ILogRepository logRepository)
        {
            _userService = userService;
            _productService = productService;
            _receiptService = receiptService;
            _propertyService = propertyService;
            _logRepository = logRepository;
        }

        public async Task<ApiValueResponse<List<Statistic>>> GetStatisticsAsync(StatisticsRequest statisticsRequest)
        {
            var users = (await _userService.GetUsersByFilter(
                new UserFilterRequest()
                {
                    StartDate = statisticsRequest.StartDate,
                    EndDate = statisticsRequest.EndDate,
                })).Value;
            var receipts = (await _receiptService.GetReceiptsWithFilter(
                new ReceiptFilterRequest()
                {
                    StartDate = statisticsRequest.StartDate,
                    EndDate = statisticsRequest.EndDate,
                })).Value;
            var receiptsApproved = receipts.Count(x => x.Status == ReceiptStatus.Approved);
            var receiptsRejected = receipts.Count(x => x.Status == ReceiptStatus.Rejected);
            var logs =  (await _logRepository.GetAllAsync(l=>l.CreatedAt<=statisticsRequest.EndDate&&l.CreatedAt>=statisticsRequest.StartDate)).ToList();
            var successfulReg = logs.Count(x => x.LogType == LogType.SuccessfulRegistration.ToString());
            var failedReg = logs.Count(x => x.LogType == LogType.FailedRegistration.ToString());
            logs = logs.Where(l => !l.LogType.Contains("Registration") && !l.LogType.Contains("Login")).ToList();
            var logResp = logs.GroupBy(p => p.LogType)
                        .Select(g => new LogResponse
                        {
                            ReceiptLog = g.Key,
                            ReceiptLogCount = g.Count()
                        })
                        .ToList();
            logResp.Add(new LogResponse() { ReceiptLog = "ReceiptsApproved", ReceiptLogCount = receiptsApproved });
            logResp.Add(new LogResponse() { ReceiptLog = "ReceiptsRejected", ReceiptLogCount = receiptsRejected });
            List<Statistic> statistics = new()
            {
                new Statistic
                {
                    PropertyName = "InstaCount",
                    Value = (await _propertyService.GetInsta(statisticsRequest)).Value.PropertyValue
                },
                new Statistic
                {
                    PropertyName = "Products",
                    Value = (await _productService.GetUniqueProductsFilteredAsync(new ProductFilterRequest()
                    {
                        StartDate = statisticsRequest.StartDate,
                        EndDate = statisticsRequest.EndDate,
                    })).Value
                },
                new Statistic
                {
                    PropertyName = "Users",
                    Value = users.Count
                },
                new Statistic
                {
                    PropertyName = "Cities",
                    Value = receipts.GroupBy(p => p.City)
                        .Select(g => new CityResponse
                        {
                            City = g.Key,
                            ReceiptCount = g.Count()
                        })
                        .ToList()
                },
                new Statistic
                {
                    PropertyName = "Operators",
                    Value = users.GroupBy(p => p.Operator)
                        .Select(g => new OperatorResponse
                        {
                            Operator = g.Key,
                            OperatorCount = g.Count()
                        })
                        .ToList()
                },
                new Statistic
                {
                    PropertyName = "ReceiptStat",
                    Value = logResp
                },
                new Statistic
                {
                    PropertyName = "InstaSubCount",
                    Value = (await _propertyService.GetInstaSub()).Value.PropertyValue
                },
                new Statistic 
                {
                    PropertyName = "AllRegisterAttempts",
                    Value=successfulReg+failedReg
                },
                new Statistic
                {
                    PropertyName = "SuccessfulRegisteration",
                    Value=successfulReg
                },
                new Statistic
                {
                    PropertyName = "FailedRegisteration",
                    Value=failedReg
                }

            };
            return new ApiValueResponse<List<Statistic>>(statistics);
        }
    }
}