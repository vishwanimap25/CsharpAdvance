using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class OpenClosed
    {
        //Open Closed Principle states that software entities(Classes, modules)
        //should be open for extension, but closed for modification.
    }

    public class Account
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
        public double CalculteInterest(string accountType)
        {
            if(accountType == "saving")
            {
                return Balance * 0.3;
            }else
            {                   //--> This violates OCP
                return Balance * 0.5;
            }
        }
    }

    //:::::::::::::SOLUTION:::::::::::::::::::::::
    //-> SRP is pre-requsite for this, so apply SRP first

    public class Account2
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Balance { get; set; }
    }

    //we can create a interface to take instead of this.

    interface IAccount 
    {
        double CalculateInterest(Account2 account2);
    }

    public class SavingAccount : IAccount 
    {
        public double CalculateInterest(Account2 account2)
        {
            return account2.Balance * 0.3;
        }
    }

    public class CurrentAccount : IAccount
    {
        public double CalculateInterest(Account2 account2)
        {
            return account2.Balance * 0.5;
        }
    }

    //We can create an many class as we want, 
    // and this will not even affect the rest of the project too.
    //This way entities are open for extention and closed for modification.
}
