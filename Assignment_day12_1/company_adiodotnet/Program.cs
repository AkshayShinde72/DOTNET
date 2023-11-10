using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace company_adiodotnet
{
    public class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            GetAppsettingsFile();
            PrintProduct();
         }
        static void GetAppsettingsFile()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();

        }

        static void PrintProduct()
        {
            Productlayer obj = new Productlayer(_iconfiguration);
            obj.Products();
        }
       


    }
}