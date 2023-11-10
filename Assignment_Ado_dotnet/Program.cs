using System.Net;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.Extensions.Configuration;

namespace Assignment_Ado_dotnet
{
    internal class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {

            GetAppSettingsFile();
            //EmpDisplay();
            //update();
            //Delete();
            search();

        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Pro.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();

        }

        static void EmpDisplay()
        {



            Employee_poco p1 = new Employee_poco { Name = "Shubham", Salary = 1000000, Gender = "Male", Address = "Ch.Sambhajinagar", };
            DataLayer obj = new DataLayer(_iconfiguration);
            int a = obj.InsertData(p1);




            Console.WriteLine("----------------------------");

            List<Employee_poco> ls = obj.GetList();
            foreach (var x in ls)
                Console.WriteLine("{0}  {1}  {2}  {3} {4}", x.Id, x.Name, x.Salary, x.Gender, x.Address);
            ;
            Console.ReadLine();

        }

        static void update()
        {
            DataLayer obj = new DataLayer(_iconfiguration);
            obj.Update_Employee(new Employee_poco { Name = "Amruta", Salary = 200, Gender = "Female", Address = "Bhiloli" }, 6);

            Console.WriteLine("----------------------------");

            List<Employee_poco> ls = obj.GetList();
            foreach (var x in ls)
                Console.WriteLine("{0}  {1}  {2}  {3} {4}", x.Id, x.Name, x.Salary, x.Gender, x.Address);
            ;
            Console.ReadLine();
        }

        static void Delete()
        {
            DataLayer obj = new DataLayer(_iconfiguration);
            obj.Delete(1005 );

            List<Employee_poco> ls = obj.GetList();
            foreach (var x in ls)
                Console.WriteLine("{0}  {1}  {2}  {3} {4}", x.Id, x.Name, x.Salary, x.Gender, x.Address);
            ;
            Console.ReadLine();
        }

        static void search()
        {
            DataLayer obj = new DataLayer(_iconfiguration);

           Employee_poco s = obj.search(4);
            Console.WriteLine("{0} {1} {2} {3} {4}",s.Id, s.Name,s.Salary, s.Gender, s.Address);

        }
    }
}