using ReceiptRewards.Domain.Entities;
namespace ReceiptRewards.Domain.Excel
{
    public class ReceiptExcelDto
    {
        public ReceiptExcelDto(Receipt receipt,bool fullMsisdn)
        {
            Name = receipt.User!.Name;
            Surname = receipt.User!.Surname;
            Msisdn = FormatMsisdn(receipt.User!.Msisdn, fullMsisdn);
            CreatedAt = receipt.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            FiscalDate = receipt.FiscalDate.ToString("yyyy-MM-dd HH:mm:ss");
            FiscalId = receipt.FiscalId;
            City = receipt.City;
            Status = receipt.Status.ToString();
            Points = receipt.Points;

        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Msisdn { get; set; }
        public string FiscalId { get; set; }
        public string? City { get; set; }
        public string Status { get; set; }
        public int Points { get; set; }
        public string CreatedAt { get; set; }
        public string FiscalDate { get; set; }
        private string FormatMsisdn(string msisdn, bool fullMsisdn)
        {
            return fullMsisdn || msisdn.Length < 4 ? msisdn : msisdn.Substring(0, msisdn.Length - 4) + "XXXX";
        }
    }
}
