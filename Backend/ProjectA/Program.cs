﻿using System;
using System.Text.Json;
using Backend.SharedLibrary;


namespace Backend.ProjectA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread.Sleep(100000);
            Console.WriteLine(Utilities.GetGreeting("ProjectA"));
            Console.WriteLine("Reading configuration...");

            // Assuming config.json is located relative to the application's base directory
            var basePath = AppContext.BaseDirectory;
            var configFilePath = Path.Combine(basePath, "Common/Configuration/config.json");
            Console.WriteLine("basePaht:" + basePath + ", ConfigFielPaht:" + configFilePath);

            //Thread.Sleep(100000);
            if (!File.Exists(configFilePath))
            {
                // Fallback path if not found, useful for Docker environments
                configFilePath = "/app/Common/Configuration/config.json";
            }

            if (File.Exists(configFilePath))
            {
                var json = File.ReadAllText(configFilePath);
                var config = JsonSerializer.Deserialize<Config>(json);
                Console.WriteLine($"Setting1: {config.AppSettings.Setting1}");
                Console.WriteLine($"Setting2: {config.AppSettings.Setting2}");

                // Adjust the data file path based on the configuration
                var dataFilePath = config.AppSettings.DataFilePath.Replace("\\", "/");
                if (!Path.IsPathRooted(dataFilePath))
                {
                    // Convert to absolute path if necessary
                    dataFilePath = Path.Combine(basePath, dataFilePath);
                }

                if (File.Exists(dataFilePath))
                {
                    var dataContent = File.ReadAllText(dataFilePath);
                    Console.WriteLine($"Data file content: {dataContent}");
                }
                else
                {
                    Console.WriteLine("Data file not found at: " + dataFilePath);
                }
            }
            else
            {
                Console.WriteLine("Configuration file not found at: " + configFilePath);
            }


        }
    }
    public class Config
    {
        public AppSettings AppSettings { get; set; }
    }

    public class AppSettings
    {
        public string Setting1 { get; set; }
        public string Setting2 { get; set; }
        public string DataFilePath { get; set; }
    }
}
