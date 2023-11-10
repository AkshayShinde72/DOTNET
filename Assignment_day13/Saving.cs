using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_day13
{
    internal class Saving : Account
    {
        public static double Rateofintrest=0.7;
        public override void withdraw(double amt)
        {


            double bal=Balance - amt;
            if (bal > minbala)
            {
                Balance -= amt;
                OnWithdraw(Id, Balance, Name);


            }
            else
                throw new Exception("Balance is lower than minimum balance unable to withdraw");

        }

        public Saving(string name, double balance) : base(name, balance)
        {

        }

        public static double Payinterest(Saving e)
        {
            e.Balance *= Rateofintrest;
            return e.Balance;

        }

    }
}
