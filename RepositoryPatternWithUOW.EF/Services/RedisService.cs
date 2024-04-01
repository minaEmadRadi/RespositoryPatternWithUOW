using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Services;

using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUOW.Core.Interfaces;
using StackExchange.Redis;
using System.Threading.Tasks;

public class RedisService : IRedisService
{
    private readonly IConnectionMultiplexer _redisConnection;
    private readonly TimeSpan _defaultExpirationTime;

    public RedisService(IConnectionMultiplexer redisConnection, IConfiguration configuration)
    {
        _redisConnection = redisConnection;
        var expirationInSeconds = int.Parse(configuration["RedisCacheSettings:DefaultTTL"]);
        _defaultExpirationTime = TimeSpan.FromSeconds(expirationInSeconds);
    }
    public RedisService(IConnectionMultiplexer redisConnection)
    {
        _redisConnection = redisConnection;
    }

    public async Task SetStringAsync(string key, string value)
    {
        var db = _redisConnection.GetDatabase();
        await db.StringSetAsync(key, value, _defaultExpirationTime);
    }

    public async Task<string> GetStringAsync(string key)
    {
        var db = _redisConnection.GetDatabase();
        return await db.StringGetAsync(key);
    }
}
