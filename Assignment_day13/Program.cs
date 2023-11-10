
using static System.Formats.Asn1.AsnWriter;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System.Data;

/*Q1.Create Console Appplication for Bank Of Baroda.
Create a  abstract class Account having member
a. Id [Let your application generate id, it is readonly]
b.Name[write getter, setter Method Give Validation Length of  name can not be less then 2 and greater then 15]
c.Balance[write getter, setter, you can not set value  outside class other than child class]
It has two methods
1. public abstract withdraw(double amt);
2. public void Deposit(double amt) { }
This method will increase amount in balance.
Create two child class SavingAccount and CurrentAccount.
In CurrentAccount user can have negative balance.
In SavingAccount minimum balance of 1000 need to maintain. Declare const double  minbala=1000
When use withdraw money they should get SMS and EMAIL about new balance and amount withdrawn.
 When you run application it should display name of bank. 
Create List of Account class and store child Object.
Do transaction and ensure user can not withdraw more then the balance. Also ensure it maintain minimum balance of 1000 in Saving Account.
In SavingAccount write public static double Payinterest(Employee e) this method will return interest amount  and increase the balance  If data is in-validation then your application should throw exception
 Your application should allow you to create only 5 object.
Your application should handle all exception.
Write user Define Exception for insufficient balance[If user try to withdraw more then minbalance in Saving Account] This class will print user name and transaction detail in a file.
In Account class Create event. When use withdraw money it should send SMS and E-mail [Complete Publisher subscriber design pattern]*/



namespace Assignment_day13
{
    public delegate void wd(int  x, double bal, string nm);
    public abstract class Account
    {
        public event wd somevnt;
        private readonly int id;
        static int getid=1;
        private String name;
        protected double balance;
        public const double minbala = 1000;       
        public abstract void withdraw(double amt);

        public String Name
        {
            get { return name; }

            
            set {
                if (value.Length > 2 && value.Length < 15)
                    name = value;

                else
                    throw new Exception("Entered name is wrong");
            }
}

        public Double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public int Id
        {
            get { return id; }

        }

        public Account(string name, double balance)
        {
            if (getid >5)
                throw new Exception("five accounts are completed not allowed to next accounts");

            else
            this.id = getid++;

            
                Name = name;
            

            Balance = balance;
        }
        static Account()
        {
            Console.WriteLine("LaxmiKrupa Co.Operative Bank,Kolhapur");
        }

        public void Deposit(double amt)
        {
            if (amt > 0)
                balance += amt;
        }

        public override string ToString()
        {
            return ($"id ={Id} name={Name} balance={Balance}");
        }

       public void OnWithdraw(int i, double bal, string nm)
       {
            somevnt+= wdEvent.Email;
            somevnt += wdEvent.TextMessage;


            if (somevnt != null)            somevnt(i,bal, nm);
        }

       



    }





}

