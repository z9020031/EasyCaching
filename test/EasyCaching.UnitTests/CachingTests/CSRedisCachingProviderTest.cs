namespace EasyCaching.UnitTests
{
    using EasyCaching.Core;
    using EasyCaching.Core.Internal;
    using EasyCaching.CSRedis;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Xunit;

    public class CSRedisCachingProviderTest : BaseCachingProviderTest
    {
        public CSRedisCachingProviderTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddEasyCaching(option =>
            {
                option.UseCSRedis(config =>
                {
                    config.DBConfig = new CSRedisDBOptions
                    {
                        ConnectionStrings = new System.Collections.Generic.List<string>
                        {
                            "127.0.0.1:6379,defaultDatabase=13,poolsize=50"
                        }
                    };
                }, "redis1");
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            _provider = serviceProvider.GetService<IEasyCachingProvider>();
            _defaultTs = TimeSpan.FromSeconds(30);
        }
    }
}
