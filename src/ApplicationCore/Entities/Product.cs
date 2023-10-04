using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Entities;
// some extra spoofing products for interactive testing layout.
public class Product
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int ProductId { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int CatalogTypeId { get; set; }
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int CatalogBrandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal Price { get; set; }
}
