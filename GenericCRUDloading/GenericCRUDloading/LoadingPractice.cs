using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace GenericCRUDloading
{
    internal class LoadingPractice
    {
        
    }

    //Eager Loading
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

   



}
