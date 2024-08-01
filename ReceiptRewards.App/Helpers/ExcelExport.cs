using System.Drawing;
using System.Text;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ReceiptRewards.Domain.Responses;

namespace ReceiptRewards.App.Helpers;

public class ExcelExport
{

    public static MemoryStream ExportList<T>(List<T> values)
    {
        var provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);

        var stream = new MemoryStream();

        using (var package = new ExcelPackage(stream))
        {
            var workSheet = package.Workbook.Worksheets.Add("Report");
            workSheet.Cells.LoadFromCollection(values, true);
            package.Save();
        }

        stream.Position = 0;
        return stream;
    }
    private static int currentRow = 1;
    public static void ExportListPartially<T>(List<T> values,ExcelPackage package)
    {
        if (values == null || values.Count == 0)
        {
            return;
        }
        var provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);
        var workSheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Report");
        if (workSheet == null)
        {
            workSheet = package.Workbook.Worksheets.Add("Report");
        }

        workSheet.Cells[currentRow, 1].LoadFromCollection(values, true);
        using (var headerCells = workSheet.Cells[currentRow, 1, currentRow, values[0].GetType().GetProperties().Length])
        {
            headerCells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            headerCells.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            headerCells.Style.Font.Bold = true;
        }
        currentRow += values.Count + 2; // Adding 2 for spacing between lists
    }
    public static void ResetRow()
    {
        currentRow = 1;
    }
    public static MemoryStream ExportStatsList(List<Statistic> values)
    {
        var provider = CodePagesEncodingProvider.Instance;
        Encoding.RegisterProvider(provider);

        var stream = new MemoryStream();

        using (var package = new ExcelPackage(stream))
        {
            var workSheet = package.Workbook.Worksheets.Add("Report");
            workSheet.Cells.LoadFromCollection(values, true);
            package.Save();
        }

        stream.Position = 0;
        return stream;
    }
}