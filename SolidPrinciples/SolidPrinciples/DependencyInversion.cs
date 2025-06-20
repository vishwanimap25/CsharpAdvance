using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    //The Dependency Inversion Principle states that a 
    //high-level class must not depend upon a lower-level class.
    internal class DependencyInversion
    {
    }

    public class DataAccessLayer   //---> High-level class
    {
        public void AddCustomer(string name) //---> low level class
        {
            //add customer to the database
            //Filelogger logger = new Filelogger();
            //logger.Log("customer added :" + name);
        }
    }
}
