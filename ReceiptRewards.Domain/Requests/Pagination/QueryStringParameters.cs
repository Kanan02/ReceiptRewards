using System.ComponentModel;

namespace ReceiptRewards.Domain.Requests.Pagination;

public abstract class QueryStringParameters
{
        
    
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    protected QueryStringParameters()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    protected QueryStringParameters(int? pageNumber, int? pageSize)
    {
        PageNumber = (int)(pageNumber < 1  ? 1 : pageNumber)!;
        PageSize = (int)(pageSize > 10 ? 10 : pageSize)!;
    }

}