namespace MVC_Application.Models
{
    public class CustomerService:ICustomer
    {
        private static List<Customer_poco> _customerList;

        public CustomerService()
        {
            _customerList = new List<Customer_poco>()
            {
                new Customer_poco() {Id=1,Name="Akshay", Mobile_Number = "9733773224", Bill_Amount = 5500},
                new Customer_poco() {Id=2,Name="Ajinkya",Mobile_Number="8832123455",Bill_Amount=5000},
                new Customer_poco() {Id=3,Name="Amit",Mobile_Number="9345227658",Bill_Amount=6000},
                new Customer_poco() {Id=4,Name="Akash",Mobile_Number="9345223455",Bill_Amount=8000},
                new Customer_poco(){Id=5,Name="Aarti",Mobile_Number="934522342",Bill_Amount=5400}
            };


        }



        public IEnumerable<Customer_poco> GetAllCustomer()
        {
            return _customerList;
        }
    }
}
