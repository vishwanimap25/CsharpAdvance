using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace SolidPrinciples
{

    //Interface Segregation Principle states that a class should not 
    //be forced to implement Interfaces that it does not use.
    internal class InterfaceSegrigation
    {

    }

    public interface IDrive
    {
        void Drive();
        void Fly();
    }
    public class FlyingCar : IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Drive car");
        }
        public void Fly()
        {
            Console.WriteLine("Fly car");
        }
    }
    public class Car : IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Drive car");
        }
        public void Fly()  //--> This violates the ISP, because 
                           //the unapplicable method is also being used in this class.
        {
            throw new NotImplementedException();
        }
    }
    //:::::::::::::::::::::::SOLUTION:::::::::::::::::::::::::::::::
    //TO solve this we can create multiple smaller interfaces, and can 
    //take multiple inheritance all the required becoz of interfaces

    public interface IDrive2
    {
        void Drive();
    }
    public interface IFly
    {
        void Fly();
    }
    public class Cars2 : IDrive2
    {
        public void Drive()
        {
            Console.WriteLine("I Drive");
        }
    }
    public class FlyingCars2 : IDrive2, IFly
    {
        public void Drive()
        {
            Console.WriteLine("I Drive");
        }
        public void Fly()
        {
            Console.WriteLine("I Fly");
        }
    }
}
