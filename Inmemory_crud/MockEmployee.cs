using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmemory_crud
{
    internal class MockEmployee : IEmployee
    {
        private static List<Employee> list;

        public MockEmployee()
        {
           list =new List<Employee>()
            {
                new Employee() { Id = 1, Name = "shubham", Salary = 800000, Gender = "Male", Address = "Solapur" },
                new Employee() { Id = 2, Name = "Akshay", Salary = 2200000, Gender = "Male", Address = "Kolhapur" },
                new Employee() { Id = 3, Name = "Ankita", Salary = 780000, Gender = "Female", Address = "Dubai" },
                new Employee() { Id = 4, Name = "Prasad", Salary = 450000, Gender = "Male", Address = "China" },
                new Employee() { Id = 5, Name = "Swami", Salary = 878900, Gender = "Male", Address = "Delhi" },
                new Employee() { Id = 6, Name = "Shweta", Salary = 400000, Gender = "Female", Address = "Nagpur" },
            };
        }

        public IEnumerable<Employee> GetAllEmployee()  //first method to return everuthing
        {
            return list;
        }

        public Employee GetEmployee(int id)
        {
            return list.FirstOrDefault(b => b.Id == id);
        }

        public Employee Add(Employee emp)
        {
            emp.Id=list.Max(b => b.Id)+1;
            list.Add(emp);
            return emp;

            
        }

        public Employee Update(Employee emp)
        {
            Employee a = list.FirstOrDefault(b => b.Id == emp.Id);
            if(emp != null)
            {
                a.Name=emp.Name;
                a.Salary = emp.Salary;
                a.Gender = emp.Gender;
                a.Address = emp.Address;

            }
            return a;

        }

        public Employee Delete(int id)
        {
           Employee a=list.FirstOrDefault(b => b.Id == id);
            if(a != null) 
            {
                list.Remove(a);

            }
            return a;
        }
    }
}
