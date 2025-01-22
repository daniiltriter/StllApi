using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Stll.Domain.Abstractions;

namespace Stll.Domain.Services;

public class MemoryProvider<TEntity> : IMemoryProvider<TEntity> where TEntity : class, IEntity
{
    private readonly IDistributedCache _cache;
    public MemoryProvider(IDistributedCache cache)
    {
        _cache = cache;
    }
    
    public async Task<TEntity> TakeAsync(ulong id)
    {
        var key = $"{nameof(TEntity).ToLower()}:{id}";
        var cachedJson = await _cache.GetStringAsync(key);
        var notCached = string.IsNullOrWhiteSpace(cachedJson);
        if (notCached)
        {
            return default;
        }

        return JsonSerializer.Deserialize<TEntity>(cachedJson);
    }

    public async Task PutAsync(TEntity entity)
    {
        var key = $"{nameof(TEntity).ToLower()}:{entity.Id}";
        // TODO: Create JSON Converter service
        var jsonEntity = JsonSerializer.Serialize(entity);
        await _cache.SetStringAsync(key, jsonEntity);
    }
}