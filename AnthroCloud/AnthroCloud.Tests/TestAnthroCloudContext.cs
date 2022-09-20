using System;
using System.IO;
using AnthroCloud.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace AnthroCloud.Tests
{
    /// <summary>
    /// Represents the database context or fixture necessary to run tests and evaluate outcomes.
    /// </summary>
    public class TestAnthroCloudContext
    {
        private const string STORE = "appsettings.json";
        private const string APP = "AnthroCloud.API\\";
        private const string KEY = "ConnectionStrings";
        private const string VALUE = "AnthroCloudDatabaseMsSql";
        private const string DIR = "..\\..\\..\\..\\";
        private static string _connectionString = string.Empty;

        public AnthroCloudContext Context { get; set; }

        public TestAnthroCloudContext()
        {
            if (VALUE.ToString() == "AnthroCloudDatabaseMsSql")
            {
                Context = ConfigureMsSql();
            }
            else if (VALUE.ToString() == "AnthroCloudDatabaseMySql")
            {
                Context = ConfigureMySql();
            }
        }

        private static AnthroCloudContext ConfigureMySql()
        {
            // Retrieve application settings file
            ConfigurationBuilder configurationBuilder = new();
            String projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, DIR)); 
            String settingsPath = Path.Combine(projectPath + APP, STORE);            
            configurationBuilder.AddJsonFile(settingsPath, false);

            // Retrieve setting from key & value
            var root = configurationBuilder.Build();
            _connectionString = root.GetSection(KEY).GetSection(VALUE).Value;

            // Configure context with setting
            DbContextOptionsBuilder<AnthroCloudContext> optionsBuilder = new();
            optionsBuilder.UseMySql(_connectionString,
                    new MySqlServerVersion(new Version(5, 7, 29))
                    //,
                    //mySqlOptions => mySqlOptions
                    //    .CharSetBehavior(CharSetBehavior.NeverAppend)
                    );

            // Initialize context with setting
            AnthroCloudContext context = new(optionsBuilder.Options);

            return context;
        }

        private static AnthroCloudContext ConfigureMsSql()
        {
            // Retrieve application settings file
            ConfigurationBuilder configurationBuilder = new();
            String projectPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, DIR));
            String settingsPath = Path.Combine(projectPath + APP, STORE);
            configurationBuilder.AddJsonFile(settingsPath, false);

            // Retrieve setting from key & value
            var root = configurationBuilder.Build();
            _connectionString = root.GetSection(KEY).GetSection(VALUE).Value;

            // Configure context with setting
            DbContextOptionsBuilder<AnthroCloudContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer(_connectionString);

            // Initialize context with setting
            AnthroCloudContext context = new(optionsBuilder.Options);

            return context;
        }
    }
}
