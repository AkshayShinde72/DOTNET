using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmemory_crud
{
    internal interface IEmployee
    {
       
       public IEnumerable<Employee> GetAllEmployee();
       public Employee GetEmployee(int id);
       Employee Add(Employee employee);
       Employee Update(Employee employee);
       Employee Delete(int id);        

    }
}
