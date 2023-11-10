namespace MVC_Application.Models
{
    public interface ICustomer
    {
        IEnumerable<Customer_poco> GetAllCustomer();
    }
}
