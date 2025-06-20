using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
    internal class SingleRespondibility
    {
            // Single Responsibility Principle states that a Class should have only one responsibility.

            //or Class should have only one responsibility to change
    }

    public class Employee
    {
        //own responsibility 
        public int CalculateSalary()
        {
            return 100000;
        }

        //own responsibility
        public string CalculateBonus()
        {
            return "IT";
        }


        //Extra Responsibility
        //--------This violates Single Responsibility Principle-----
        public void Save()
        {
            //save employees to database     --> violates SRP
        }
        //--------This violates Single Responsibility Principle-----
        //because, the employee has already a work of calulating, and can not assign 
        //another work to the same class.
    }



    //:::::::::::::::SOLUTION TO THIS::::::::::::::::::::::::::::::::
    //jUST CREATE TWO DIFFERENT CLASSES FOR EACH RESPONSIBILITY

    //(01)
    public class Employee2
    {
        public int CalculateSalary()
        {
            return 100000;
        }

        public string CalculateBonus()
        {
            return "IT";
        }
    }

    //(02)
    public class EmployeeResponsibility
    {
        public void Save()
        {
            //save employee deatils.
        }
    }
}
