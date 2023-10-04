using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class CatalogFilterTextPaginatedSpecification : Specification<CatalogItem>
{
    public CatalogFilterTextPaginatedSpecification(string filterText, int skip, int take, int? brandId, int? typeId)
        : base()
    {
        if (take == 0)
        {
            take = int.MaxValue;
        }
        Query
            .Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
            (!typeId.HasValue || i.CatalogTypeId == typeId) && 
            (string.IsNullOrWhiteSpace(filterText) || (!string.IsNullOrEmpty(i.Name) && i.Name.Contains(filterText, System.StringComparison.CurrentCultureIgnoreCase))) )
            .Skip(skip).Take(take);
    }
}
