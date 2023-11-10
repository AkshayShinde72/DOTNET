using Microsoft.AspNetCore.Mvc;
using MVC_Application.Models;

namespace MVC_Application.Controllers
{
    public class CustomerController1 : Controller
    {
        ICustomer _cusromerrrp;

        public CustomerController1(ICustomer customerrrp)
        {
            _cusromerrrp = customerrrp;
        }
        public IActionResult Index()
        {
            var CustomerList = _cusromerrrp.GetAllCustomer();
            return View(CustomerList);
        }
        
    }
}
