using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Xml.Linq;

namespace Inmemory_crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HR_Application");
            Console.WriteLine("_____________________________________________");
            MockEmployee db=new MockEmployee();
            Console.WriteLine("SHOW EMPLOYEE LIST --->");
            Display(db);

            Console.WriteLine("_____________________________________________");

            Console.WriteLine("GET EMPLOYEE WITH ID--->");
            Employee e = db.GetEmployee(2);
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", e.Id, e.Name, e.Salary, e.Gender, e.Address);

            Console.WriteLine("_____________________________________________");
            Console.WriteLine("ADD EMPLOYEE --->");
            db.Add(new Employee() { Id = 7, Name = "Maaria", Salary = 700000, Gender = "Female", Address = "Kolhapur" });
            Display(db);
            Console.WriteLine("_____________________________________________");

            Console.WriteLine("UPDATE EMPLOYEE --->");
            db.Update(new Employee() { Id = 4, Name = "Swapnil", Salary = 100000, Gender = "Male", Address = "Nashik" });
            Display(db);
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("DELETE EMPLOYEE --->");
            db.Delete(3);
            Display(db);
            Console.WriteLine("_____________________________________________");
        }

        public static void Display(MockEmployee db)
        {
            foreach(Employee e in db.GetAllEmployee())
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",e.Id,e.Name,e.Salary,e.Gender,e.Address);
            }

        }


    }
}