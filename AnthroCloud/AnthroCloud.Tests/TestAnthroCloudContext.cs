using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using AnthroCloud.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace AnthroCloud.Tests
{
    /// <summary>
    /// Represents the database context or fixture necessary to run tests and evaluate outcomes.
    /// </summary>
#pragma warning disable DV2002 // Unmapped types
    public class TestAnthroCloudContext
#pragma warning restore DV2002 // Unmapped types
    {
        private static string _connectionString = string.Empty;
        private const string APP_PATH = "AnthroCloud.API\\";
        
        public AnthroCloudContextMySql Context { get; set; }

        public TestAnthroCloudContext()
        {
            Context = Configure();
        }

        private AnthroCloudContextMySql Configure()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            String projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\")); 
            String settingsPath = Path.Combine(projectPath + APP_PATH, "appsettings.json");            
            configurationBuilder.AddJsonFile(settingsPath, false);

            var root = configurationBuilder.Build();
            _connectionString = root.GetSection("ConnectionStrings").GetSection("AnthroCloudDatabaseMySql").Value;

            var optionsBuilder = new DbContextOptionsBuilder<AnthroCloudContextMySql>();
            optionsBuilder.UseMySql(_connectionString);
            AnthroCloudContextMySql context = new AnthroCloudContextMySql(optionsBuilder.Options);

            return context;
        }
    }
}
