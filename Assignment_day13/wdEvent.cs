using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_day13
{
    internal class wdEvent
    {
        public static void Email(int id, double balance, string name)
        {
            Console.WriteLine("Email Sent");
            Console.WriteLine("amount is withdrawn from" + id + "Name of account holder is" + name + "current balance is" + balance);
        }

        public static void TextMessage(int id, double balance, string name)
        {
            Console.WriteLine("Message Sent");
            Console.WriteLine("amount is withdrawn from" + id + "Name of account holder is" + name + "current balance is" + balance);

        }
    }
}
