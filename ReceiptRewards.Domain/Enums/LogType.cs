namespace ReceiptRewards.Domain.Enums;

public enum LogType
{
    Undefined,
    FailedRegistration, 
    FailedLogin,
    FiscalAlreadyScanned,
    FiscalScannedByAnotherUser,
    FailedFiscalScan,
    SuccessfulRegistration
}