using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;

namespace MySocialNetwork.Tests
{
    public static class ConfigurationHelper
    {
        public static IConfiguration Configurations => _configurations.Value;
        private static readonly Lazy<IConfiguration> _configurations = new Lazy<IConfiguration>(GetConfigurations);

        private static IConfiguration GetConfigurations()
        {
            var configs = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();


            return configs;
        }
    }
}
