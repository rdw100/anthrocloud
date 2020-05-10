using System;
using System.IO;
using AnthroCloud.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AnthroCloud.Tests
{
    /// <summary>
    /// Represents the database context or fixture necessary to run tests and evaluate outcomes.
    /// </summary>
#pragma warning disable DV2002 // Unmapped types
    public class TestAnthroCloudContext
#pragma warning restore DV2002 // Unmapped types
    {   
        private const string STORE = "appsettings.json";
        private const string APP = "AnthroCloud.API\\";
        private const string KEY = "ConnectionStrings";
        private const string VALUE = "AnthroCloudDatabaseMySql";
        private const string DIR = "..\\..\\..\\..\\";

        private static string _connectionString = string.Empty;

        public AnthroCloudContextMySql Context { get; set; }

        public TestAnthroCloudContext()
        {
            Context = Configure();
        }

        private AnthroCloudContextMySql Configure()
        {
            // Retrieve application settings file
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            String projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, DIR)); 
            String settingsPath = Path.Combine(projectPath + APP, STORE);            
            configurationBuilder.AddJsonFile(settingsPath, false);

            // Retrieve setting from key & value
            var root = configurationBuilder.Build();
            _connectionString = root.GetSection(KEY).GetSection(VALUE).Value;

            // Configure context with setting
            DbContextOptionsBuilder<AnthroCloudContextMySql> optionsBuilder = new DbContextOptionsBuilder<AnthroCloudContextMySql>();
            optionsBuilder.UseMySql(_connectionString);

            // Initialize context with setting
            AnthroCloudContextMySql context = new AnthroCloudContextMySql(optionsBuilder.Options);

            return context;
        }
    }
}
