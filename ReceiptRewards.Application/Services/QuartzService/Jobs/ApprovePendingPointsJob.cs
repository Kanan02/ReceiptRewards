using Microsoft.Extensions.Logging;
using Quartz;
using ReceiptRewards.Application.Services.Abstract;

namespace ReceiptRewards.Application.Services.QuartzService.Jobs;

public class ApprovePendingPointsJob: IJob
{
    private readonly ILogger<ApprovePendingPointsJob> _logger;
    private readonly IReceiptService _service;

    public ApprovePendingPointsJob(ILogger<ApprovePendingPointsJob> logger, IReceiptService service)
    {
        _logger = logger;
        _service = service;
    }
    
    
    public async Task Execute(IJobExecutionContext context)
    {
       await _service.ApproveAsync();
    }
}