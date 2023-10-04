using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class CatalogFilterTextSpecification : Specification<CatalogItem>
{
    public CatalogFilterTextSpecification(string filterText, int? brandId, int? typeId)
    {
        Query.Where(i => (!brandId.HasValue || i.CatalogBrandId == brandId) &&
            (!typeId.HasValue || i.CatalogTypeId == typeId) && 
            (string.IsNullOrWhiteSpace(filterText) || (!string.IsNullOrEmpty(i.Name) && i.Name.Contains(filterText,System.StringComparison.CurrentCultureIgnoreCase))) );
    }
}

