namespace Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints;

public class ListTextPagedCatalogItemRequest : BaseRequest
{
    public int PageSize { get; init; }
    public int PageIndex { get; init; }
    public int? CatalogBrandId { get; init; }
    public int? CatalogTypeId { get; init; }
    public string? TextFilter { get; init; }

    public ListTextPagedCatalogItemRequest(string? textFilter, int? pageSize, int? pageIndex, int? catalogBrandId, int? catalogTypeId)
    {
        PageSize = pageSize ?? 0;
        PageIndex = pageIndex ?? 0;
        CatalogBrandId = catalogBrandId;
        CatalogTypeId = catalogTypeId;
        TextFilter = textFilter;
    }
}
