using System.Data;
using Microsoft.Extensions.Configuration;

namespace Assignment_day14_disconnected
{
    internal class Program
    {
        private static IConfiguration _iconfiguration;

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Pro1.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }

        static void PrintProduct()
        {
            var empdal = new EmpDAL(_iconfiguration);
            var dt = empdal.GetList();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                    Console.Write(row[col] + " ");
                Console.WriteLine("----------------------------------");

            }

           // empdal.addindataset();
           //empdal.deletebyid(4);

        }
            static void Main(string[] args)
        {
            GetAppSettingsFile();
            PrintProduct();

            
        }
    }
}