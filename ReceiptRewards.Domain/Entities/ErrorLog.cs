using ReceiptRewards.Domain.Enums;

namespace ReceiptRewards.Domain.Entities;

public class ErrorLog : BaseEntity<int>
{
    public ErrorLog(string logType)
    {
        LogType = logType;
    }

    public string LogType { get; set; }
}