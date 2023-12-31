﻿using Microsoft.Extensions.Configuration;

namespace customer_adiodotnet
{
    internal class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            GetAppSettingsFile();
            Console.WriteLine(Directory.GetCurrentDirectory());
            PrintProduct();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) 
            .AddJsonFile("Customer.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void PrintProduct()
        {
            Productlayer obj = new Productlayer(_iconfiguration);
            obj.Products();
            obj.product_insert();
            obj.Products();
        }
    }
}