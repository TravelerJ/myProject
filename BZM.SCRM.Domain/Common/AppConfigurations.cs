using Abp.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common
{
    public static class AppConfigurations
    {
        private static readonly ConcurrentDictionary<string, IConfigurationRoot> ConfigurationCache;

        static AppConfigurations()
        {
            ConfigurationCache = new ConcurrentDictionary<string, IConfigurationRoot>();
        }
        public static IConfigurationRoot Get(string path, string environmentName = null,string jsonFileName= "appsettings")
        {
            var cacheKey = path + "#" + environmentName + "#" + jsonFileName;
            return ConfigurationCache.GetOrAdd(cacheKey,_=> BuildConfiguration(jsonFileName, path, environmentName));
        }
        private static IConfigurationRoot BuildConfiguration(string jsonFileName, string path, string environmentName = null)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile(jsonFileName + ".json", optional: true, reloadOnChange: true);
            if (!environmentName.IsNullOrWhiteSpace())
            {
                builder = builder.AddJsonFile($"{jsonFileName}.{environmentName}.json", optional: true);
            }
            builder = builder.AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
