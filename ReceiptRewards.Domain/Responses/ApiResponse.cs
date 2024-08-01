namespace ReceiptRewards.Domain.Responses;

public class ApiResponse
{
    public ApiResponse()
    {
        Errors = new List<ApiError>();
    }

    public ApiResponse(ApiError error) : this()
    {
        Errors.Add(error);
    }

    public bool Success => Errors == null || Errors.Count() == 0;
    public List<ApiError> Errors { get; set; }
}

public class ApiError
{
    public ApiError()
    {
    }

    public ApiError(string error,string errorCode) : this()
    {
        ErrorMsg = error;
        ErrorCode = errorCode;
    }

    public string ErrorMsg { get; set; }
    public string ErrorCode { get; set; }
}

