using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReceiptRewards.Domain.Entities;
using ReceiptRewards.Domain.Enums;
using ReceiptRewards.Domain.Messaging.Events;
using ReceiptRewards.Domain.Repositories;
using ReceiptRewards.Domain.Requests;

namespace ReceiptRewards.Domain.Messaging.Consumers;

public class ReceiptAddedEventConsumer : IConsumer<ReceiptMessagingEvent>
{
    private readonly ILogger<ReceiptAddedEventConsumer> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IReceiptRepository _receiptRepository;
    private readonly ILogRepository _logRepository;

    private readonly IConfiguration _configuration;

    public ReceiptAddedEventConsumer(IReceiptRepository receiptRepository, IHttpClientFactory httpClientFactory,
        ILogger<ReceiptAddedEventConsumer> logger, IConfiguration configuration, ILogRepository logRepository)
    {
        _receiptRepository = receiptRepository;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _configuration = configuration;
        _logRepository = logRepository;
    }

    public async Task Consume(ConsumeContext<ReceiptMessagingEvent> context)
    {
        var consumedReceipt = context.Message.Receipt;
        var data = await ReadDataFromUrl(new ReceiptRequest()
        {
            Fiscal = consumedReceipt.FiscalId,
            SearchProductName = "tes"
        });

        var receipt = await _receiptRepository.GetAsync(c => c.FiscalId == consumedReceipt.FiscalId, includes: "User");
        receipt.FiscalDate = data.fiscalDate;
        receipt.City = data.city ?? "Undefined";

        if (data.products.Count == 0)
        {
            receipt.Status = ReceiptStatus.Rejected;
            await _logRepository.AddAsync(new ErrorLog(LogType.FailedFiscalScan.ToString()));
            await _logRepository.SaveAsync();
        }
        else
        {
            foreach (var product in data.products.Select(pr => new Product()
                     {
                         Name = pr.name,
                         Price = Math.Round(pr.price, 2),
                         Quantity = pr.quantity,
                         TotalPrice = Math.Round(pr.totalPrice, 2),
                         ReceiptId = receipt.Id
                     }))
            { 
                receipt.products.Add(product);
                receipt.Points += Convert.ToInt32(Math.Floor(product.TotalPrice * 50));
                receipt.User!.Pending += Convert.ToInt32(Math.Floor(product.TotalPrice * 50));
            }
        }

        //check fiscal date for status change
        await _receiptRepository.SaveAsync();
    }

    private async Task<ReceiptConsumeResponse> ReadDataFromUrl(ReceiptRequest request)
    {
        return await RequestHelper.SendDataToUrl<ReceiptRequest, ReceiptConsumeResponse, ReceiptAddedEventConsumer>(
            _configuration["ReaderApiUrl"], request, _logger, _httpClientFactory);
    }
}