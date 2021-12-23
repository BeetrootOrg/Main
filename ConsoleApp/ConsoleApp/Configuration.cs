using System;

namespace ConsoleApp;

internal class Configuration
{
    public string SlackToken { get; set; }
    public string RedisConnectionString { get; set; }
    public TimeSpan? Ttl { get; set; }
}