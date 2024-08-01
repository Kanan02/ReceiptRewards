namespace ReceiptRewards.Domain.Responses;

public class ApiValueResponse<T> : ApiResponse 
{
    public ApiValueResponse(T value)
    {
        Value = value;
    }

    public ApiValueResponse()
    {
    }

    public ApiValueResponse(ApiError error) : base(error)
    {
    }

    public T Value { get; set; }
}

