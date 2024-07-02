using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace DesignPatternsApp
{
    public class PrivateSingleton
    {
        //This variable value will be increment by 1 each time the object of the class is created
        private static int Counter = 0;
        //This variable is going to store the Singleton Instance
        private static PrivateSingleton Instance;
        //The following Static Method is going to return the Singleton Instance
        public static PrivateSingleton GetInstance()
        {
            //If the variable instance is null, then create the Singleton instance 
            //else return the already created singleton instance
            //This version is not thread-safe
            if (Instance == null)
            {
                Instance = new PrivateSingleton();
            }
            //Return the Singleton Instance
            return Instance;
        }
        //Constructor is Private means, from outside the class we cannot create an instance of this class
        private PrivateSingleton()
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
        public class DerivedSingleton : PrivateSingleton
        {
        }
    }
    /*
     * Error CS0122 ‘Singleton.Singleton()’ is inaccessible due to its protection level
     
     
    public class DerivedSingleton : PrivateSingleton
    {
    }
    */
}
