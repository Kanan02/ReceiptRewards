using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using ReceiptRewards.App.Helpers;
using ReceiptRewards.Application.Services.Abstract;
using ReceiptRewards.Domain.Excel;
using ReceiptRewards.Domain.Requests;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ExcelController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReceiptService _receiptService;
        private readonly IStatisticsService _statisticsService;

        public ExcelController(
            IUserService userService,
            IReceiptService receiptService,
            IStatisticsService statisticsService
        )
        {
            _userService = userService;
            _receiptService = receiptService;
            _statisticsService = statisticsService;
        }

        [HttpGet("ExportUsers")]
        public async Task<IActionResult> ExportUsers([FromQuery] UserFilterRequest request)
        {
            var users = (await _userService.GetUsersByFilter(request))
                .Value.Select(x => new UserExcelDto(x))
                .ToList();
            return GetListExcellContent(users, "users_statistics.xlsx");
        }

        [HttpGet("ExportReceipts")]
        public async Task<IActionResult> ExportReceipts([FromQuery] ReceiptFilterRequest request)
        {
            var receiptsAll = (await _receiptService.GetReceiptsWithFilter(request)).Value;
            var receipts=receiptsAll.OrderBy(x => x.CreatedAt).Select(x=>new ReceiptExcelDto(x,request.FullMsisdn)).ToList();
            // receiptsAll = receiptsAll.OrderBy(x => x.CreatedAt).ToList();
            return GetListExcellContent(receipts, "receipts_statistics.xlsx");
        }
        [HttpGet("ExportStatistics")]
        public async Task<IActionResult> ExportStatistics([FromQuery] StatisticsRequest request)
        {
            var statsAll = (await _statisticsService.GetStatisticsAsync(request)).Value;
            //var receipts = statisAll.OrderBy(x => x).Select(x => new ReceiptExcelDto(x, request.FullMsisdn)).ToList();
            // receiptsAll = receiptsAll.OrderBy(x => x.CreatedAt).ToList();
            return GetListExcellStats(statsAll, "overall_statistics.xlsx");
        }
        private FileStreamResult GetListExcellStats(List<Statistic> list, string listName)
        {
            var propertiesList = new List<Statistic>(list.Where(x => x.PropertyName == "InstaCount" || x.PropertyName == "Users"
                                                                || x.PropertyName == "InstaSubCount" || x.PropertyName == "AllRegisterAttempts"
                                                                || x.PropertyName == "SuccessfulRegisterAttempts" || x.PropertyName == "FailedRegisterAttempts"));

            propertiesList.ForEach(x => x.Value = x.Value is string ? int.Parse(x.Value.ToString()):x.Value);
            var productsList = list.Where(x => x.PropertyName == "Products").FirstOrDefault()!.Value as List<ProductResponse>;
            var citiesList = list.Where(x => x.PropertyName == "Cities").FirstOrDefault()!.Value as List<CityResponse>;
            var operatorsList = list.Where(x => x.PropertyName == "Operators").FirstOrDefault()!.Value as List<OperatorResponse>;
            var logsList = list.Where(x => x.PropertyName == "ReceiptStat").FirstOrDefault()!.Value as List<LogResponse>;
            var stream = new MemoryStream();
            
            using (var package = new ExcelPackage(stream))
            {
                ExcelExport.ExportListPartially(propertiesList, package);
                ExcelExport.ExportListPartially(productsList, package);
                ExcelExport.ExportListPartially(citiesList, package);
                ExcelExport.ExportListPartially(operatorsList, package);
                ExcelExport.ExportListPartially(logsList, package);
                package.Save();
            }
            // new List<object>(list.Where(x=>x.PropertyName=="Products").FirstOrDefault().Value as List<ProductResponse>),
            // new List<object>(list.Where(x=>x.PropertyName=="Cities").FirstOrDefault().Value as List<object>),
            //  new List<object>(list.Where(x=>x.PropertyName=="Operators").FirstOrDefault().Value as List<object>),
            // stream = ExcelExport.ExportListPartially(propertiesList,stream);
            //  stream = ExcelExport.ExportListPartially(productsList, stream);
            //   stream = ExcelExport.ExportListPartially(citiesList, stream);
            stream.Position = 0;
            ExcelExport.ResetRow();
            return File(
                stream,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                listName
            );

        }
        private FileStreamResult GetListExcellContent<T>(List<T> list, string listName)
        {
            var streamContent = ExcelExport.ExportList(list);
            return File(
                streamContent,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                listName
            );
        }
    }
}
