public class ProductFilter
{
    public IEnumerable<Product> Filter(
        IEnumerable<Product> products,
        FilterOptions options)
    {
        var result = products;

        if (options.MinPrice.HasValue)
            result = result.Where(p => p.Price >= options.MinPrice.Value);
        if (options.MaxPrice.HasValue)
            result = result.Where(p => p.Price <= options.MaxPrice.Value);
        if (!string.IsNullOrEmpty(options.Category))
            result = result.Where(p => p.Category == options.Category);
        if (options.MinStock.HasValue)
            result = result.Where(p => p.Stock >= options.MinStock.Value);

        result = ApplySorting(result, options.SortBy);
        return result;
    }

    private IEnumerable<Product> ApplySorting(IEnumerable<Product> products, SortOption sortBy)
    {
        return sortBy switch
        {
            SortOption.Name => products.OrderBy(p => p.Name),
            SortOption.PriceAsc => products.OrderBy(p => p.Price),
            SortOption.PriceDesc => products.OrderByDescending(p => p.Price),
            _ => products
        };
    }
}

public class FilterOptions
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string Category { get; set; }
    public int? MinStock { get; set; }
    public SortOption SortBy { get; set; }
}

public enum SortOption
{
    None,
    Name,
    PriceAsc,
    PriceDesc
}
