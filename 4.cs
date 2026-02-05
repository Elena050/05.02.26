public class Cache<TKey, TValue>
{
    private readonly Dictionary<TKey, TValue> _cache = new();
    private readonly object _lock = new object();

    public TValue GetOrAdd(TKey key, Func<TKey, TValue> loader)
    {
        lock (_lock)
        {
            if (_cache.ContainsKey(key))
                return _cache[key];

            var value = loader(key);
            _cache[key] = value;
            return value;
        }
    }
}

public class ProductService
{
    private readonly Cache<int, Product> _cache = new();

    public Product GetProduct(int id)
    {
        return _cache.GetOrAdd(id, LoadFromDatabase);
    }

    private Product LoadFromDatabase(int id) { /* ... */ }
}
