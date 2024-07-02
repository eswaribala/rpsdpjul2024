using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazySingletonApp
{
    public class LazySingleton
    {
        //This variable value will be increment by 1 each time the object
        //of the class is created
        private static int Counter = 0;
        // The private static instance ensures lazy initialization.
        private static readonly Lazy<LazySingleton> instance = new Lazy<LazySingleton>(() => new LazySingleton());
        // Private constructor to prevent direct instantiation.
        private LazySingleton()
        {
            // Initialization code here
            //Each Time the Constructor is called, increment the Counter value by 1
            Counter++;
            Console.WriteLine("Counter Value " + Counter.ToString());
        }
        //The following Static Method is going to return the Singleton Instance
        public static LazySingleton GetInstance()
        {
            return instance.Value;
        }
        //The following method can be accessed from outside of the class by using the Singleton Instance
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
        static void Main(string[] args)
        {
            //The following Code will Invoke both methods Parallely using two different
            //Threads
            Parallel.Invoke(
                //Let us Assume PrintTeacherDetails method is Invoked by Thread-1
                () => PrintTeacherDetails(),
                //Let us Assume PrintStudentDetails method is Invoked by Thread-2
                () => PrintStudentDetails()
                );
            Console.ReadLine();
        }
        private static void PrintTeacherDetails()
        {
            //Thread-1 Calling the GetInstance() Method of the Singleton class
            LazySingleton fromTeacher = LazySingleton.GetInstance();
            fromTeacher.PrintDetails("From Teacher");
        }
        private static void PrintStudentDetails()
        {
            //At the same time, Thread-2 also Calling the GetInstance() Method of the Singleton Class
            LazySingleton fromStudent = LazySingleton.GetInstance();
            fromStudent.PrintDetails("From Student");
        }
    }
}
