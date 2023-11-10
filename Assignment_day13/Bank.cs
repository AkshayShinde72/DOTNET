using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Assignment_day13
{
    internal class Bank
    {
        static void Main(String[] args) { 
        /*Account s1 = new Saving("Akshay", 10000);
        Console.WriteLine(s1.ToString());

         s1.withdraw(200);
         
         s1.Deposit(20000);
         Console.WriteLine(s1.ToString());*/

            List<Account>list= new List<Account>();
            try
            {
                list.Add(new Saving("Shubham", 100000) );

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(new Saving("Akshay", 200000));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(new Saving("Digvijay", 2055000));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(new Saving("Rt", 2000));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(new Saving("Sushil", 209000));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                list.Add(new Saving("Sushil", 209000));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].ToString());

            }

            Console.WriteLine("________________________________________");
            list[0].Deposit(1000);
            Console.WriteLine(list[0].ToString());

            Console.WriteLine("________________________________________");
            list[2].withdraw(2000);
            Console.WriteLine(list[2].ToString());

            Console.WriteLine("________________________________________");
       

            Console.WriteLine("Balance with adding intrest "+Saving.Payinterest((Saving)list[1]));
            Console.ReadKey();

        }
            
            
            
    }
}
