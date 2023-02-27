using static Skills.Domain.Consts.DomainConsts;

namespace Skills.Shared.V1.Request.Queries;

public class PaginationQuery
{
    public PaginationQuery()
    {
        PageNumber = 0;//to const?
        PageSize = PageElements.Mid;
    }

    public PaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize < PageElements.Max ? pageSize : PageElements.Max;
    }

    public required int  PageNumber { get; init; }

    public required int PageSize { get; init; }
}
