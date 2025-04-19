using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCRUDloading
{
    internal class Generic
    {
        public static void Examples()
        {
            //generic collections -> Type safe
            int[] arr = new int[3];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            //arr[3] = 4;

            //we can only store the type of data, that we declared.
            List<int> myNumber = new List<int>(); 
            myNumber.Add(1);
            myNumber.Add(2);
            myNumber.Add(322);
            //myNumber.Add("vishwa"); -> this will not store, bcoz it's type safe and also has auto-resizinig
            //and it's comile time 

            //non-generic collections -> Not typesafe, variable length(auto-resizing)
            ArrayList al = new ArrayList(3);
            al.Add("vishwa");
            al.Add(234);
            al.Add('a');
            Console.WriteLine("capacity of arrlist before: " + al.Capacity);
            al.Add(4.32);
            al.Add(arr);
            Console.WriteLine("capacity of arrlist after: " + al.Capacity);

        }
    }
}
