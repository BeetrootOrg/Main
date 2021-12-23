using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ConsoleApp.Services;

internal interface IKey
{
    string ToKey();
}

internal record StringKey(string _key) : IKey
{
    private readonly string _key = _key;
    public string ToKey() => _key;
}

internal interface ICacheClient
{
    Task Set<T>(IKey key, T value, CancellationToken token = default);
    Task<T> Get<T>(IKey key, CancellationToken token = default);
    Task<T> GetOrSet<T>(IKey key, Func<CancellationToken, ValueTask<T>> valueFunc, CancellationToken token = default);
}

internal class RedisCacheClient : ICacheClient
{
    private readonly IDatabase _database;
    private readonly ISerializer _serializer;
    private readonly IDeserializer _deserializer;
    private readonly TimeSpan? _ttl;

    public RedisCacheClient(IDatabase database, ISerializer serializer, IDeserializer deserializer, TimeSpan? ttl = null)
    {
        _database = database;
        _serializer = serializer;
        _deserializer = deserializer;
        _ttl = ttl;
    }

    public async Task Set<T>(IKey key, T value, CancellationToken token = default)
    {
        await using var serialized = await _serializer.Serialize(value, token);
        await _database.StringSetAsync(key.ToKey(), serialized.ToArray(), _ttl);
    }

    public async Task<T> Get<T>(IKey key, CancellationToken token = default)
    {
        var redisValue = await _database.StringGetAsync(key.ToKey());

        if (!redisValue.HasValue)
        {
            return default;
        }
        
        await using var stream = new MemoryStream(redisValue);
        return await _deserializer.Deserialize<T>(stream, token);
    }

    public async Task<T> GetOrSet<T>(IKey key, Func<CancellationToken, ValueTask<T>> valueFunc, CancellationToken token = default)
    {
        var value = await Get<T>(key, token);
        if (value is null)
        {
            value = await valueFunc(token);
            await Set(key, value, token);
        }

        return value;
    }
}