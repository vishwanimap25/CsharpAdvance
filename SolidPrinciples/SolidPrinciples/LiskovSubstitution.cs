using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    // Liskov Substitution Principle states that an object of an child class 
    //must be able to replace an object of the parent class without breaking the application.
    internal class LiskovSubstitution
    {

        Employees employee = new Employees();
        PermanentEmployee pemployee = new PermanentEmployee();
        ContractEmployee cemplyee = new ContractEmployee();

        public void newPrintForLSP()
        {

            Console.WriteLine(employee.CalculateSalary()); //1000
            Console.WriteLine(employee.CalculateBonus()); //1000
            Console.WriteLine(pemployee.CalculateSalary()); //2000
            Console.WriteLine(pemployee.CalculateBonus()); //2000
            Console.WriteLine(cemplyee.CalculateSalary()); //3000
            Console.WriteLine(cemplyee.CalculateBonus()); //thorow error
        }
    }

    //base/parent/super class
    public class Employees
    {
        public virtual int CalculateSalary()
        {
            return 10000;
        }
        public virtual int CalculateBonus()
        {
            return 10000;
        }
    }

    //derived/child/subclass
    public class PermanentEmployee : Employees
    {
        public override int CalculateSalary()
        {
            return 2000;
        }
        public override int CalculateBonus()
        {
            return 2000;
        }
    }


    public class ContractEmployee : Employees
    {
        public override int CalculateSalary()
        {
            return 3000;
        }
        public override int CalculateBonus()
        {
            throw new NotImplementedException(); 
            //--> This violates the LSP
            //in lsp you should not inherit from a class whose all 
            //all methods are not related to our class.
            //derived class will access all the methods in parent class
            //if some of them are not applicable, we have to throw to cast it out
            //and doing this violates the LSP.
            //So it is better to not to inherit from a class whose 
            //all method are not applicable.
        }
    }
}
