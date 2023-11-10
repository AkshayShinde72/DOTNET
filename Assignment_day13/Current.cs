using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_day13
{
    public class Current : Account
    {

       
            public override void withdraw(double amt) 
            {
               Balance -= amt;
               OnWithdraw(Id, Balance, Name);
            }

            public Current(string name, double balance) : base(name, balance)
            {

            }

        
    }

}

