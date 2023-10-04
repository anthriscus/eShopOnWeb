﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using Xunit;

namespace Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications;

public class CatalogFilterTextSpecification
{
    [Theory]
    [InlineData(null, null, null, 10)]
    [InlineData("foo", null, null, 5)]
    [InlineData("fxx", null, null, 0)]

    [InlineData(null, 1, null, 6)]
    [InlineData("foo", 1, null, 3)]

    [InlineData(null, 2, null, 4)]
    [InlineData("foo", 2, null, 2)]

    [InlineData(null, null, 1, 4)]
    [InlineData("foo", null, 1, 2)]

    [InlineData(null, null, 3, 2)]
    [InlineData("foo", null, 3, 1)]

    [InlineData(null, 1, 3, 2)]
    [InlineData("foo", 1, 3, 1)]

    [InlineData(null, 2, 3, 0)]
    [InlineData("foo", 2, 3, 0)]
    [InlineData("fx", 2, 3, 0)]

    public void MatchesExpectedNumberOfItems(string filterText, int? brandId, int? typeId, int expectedCount)
    {
        var spec = new eShopWeb.ApplicationCore.Specifications.CatalogFilterTextSpecification(filterText, brandId, typeId);

        var result = spec.Evaluate(GetTestItemCollection()).ToList();

        Assert.Equal(expectedCount, result.Count());
    }
    public List<CatalogItem> GetTestItemCollection()
    {
        return new List<CatalogItem>()
            {
                new CatalogItem(1, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(2, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(3, 1, "Description", "Name", 0, "FakePath"),
                new CatalogItem(1, 2, "Description", "Name", 0, "FakePath"),
                new CatalogItem(2, 2, "Description", "Name", 0, "FakePath"),

                new CatalogItem(1, 1, "Description", "I am FooBar Name", 0, "FakePath"),
                new CatalogItem(2, 1, "Description", "I am FooBar Name", 0, "FakePath"),
                new CatalogItem(3, 1, "Description", "I am FooBar Name", 0, "FakePath"),
                new CatalogItem(1, 2, "Description", "I am FooBar Name", 0, "FakePath"),
                new CatalogItem(2, 2, "Description", "I am FooBar Name", 0, "FakePath"),

            };
    }

}
