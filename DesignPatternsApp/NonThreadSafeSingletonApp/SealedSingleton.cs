using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonThreadSafeSingletonApp
{
  
   
        public sealed class Singleton
        {
            //This variable value will be increment by 1 each time the object of the class is created
            private static int Counter = 0;

            //This variable is going to store the Singleton Instance
            private static Singleton Instance = null;

            //The following Static Method is going to return the Singleton Instance
            public static Singleton GetInstance()
            {
                //If the variable instance is null, then create the Singleton instance 
                //else return the already created singleton instance
                //This version is not thread-safe
                if (Instance == null)
                {
                    Instance = new Singleton();
                }

                //Return the Singleton Instance
                return Instance;
            }

            //Constructor is Private means, from outside the class we cannot create an instance of this class
            //But within the class, we can create an instance
            private Singleton()
            {
                //Each Time the Constructor is called, increment the Counter value by 1
                Counter++;
                Console.WriteLine("Counter Value " + Counter.ToString());
            }

            //The following can be accessed from outside of the class by using the Singleton Instance
            public void PrintDetails(string message)
            {
                Console.WriteLine(message);
            }

            //Creating Nested Derived Class inheriting from Singleton Class
           // public class DerivedSingleton : Singleton
           // {
           // }
        }
    
}
