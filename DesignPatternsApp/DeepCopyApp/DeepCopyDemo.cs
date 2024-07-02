using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace DeepCopyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example to Understand Deep Copy
            //Creating Employee Object
            Employee emp1 = new Employee
            {
                Name = "Anurag",
                Department = "IT",
                EmpAddress = new Address() { address = "BBSR" }
            };
            //Creating a Clone Object from the Existing Object
            Employee emp2 = emp1.GetClone();
            //Changing Name Property of Clone Object Will Not Reflect the Existing Object
            emp2.Name = "Pranaya";
            //Changing Address Property of Clone Object Will Not Reflect the Changes in the Existing Object
            //This is because of Deep Copy
            //Both Clone and Existing Object have Memory locations for the Address object
            emp2.EmpAddress.address = "Mumbai";
            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);
            Console.Read();
        }
    }
    public class Employee
    {
        //Value type Property
        public string Name { get; set; }
        //Value type Property
        public string Department { get; set; }
        //Reference type Property
        public Address EmpAddress { get; set; }
        //Creating a Cloned Object of the Current Object
        public Employee GetClone()
        {
            Employee employee = (Employee)this.MemberwiseClone();
            //The following Statement will make this a Deep Copy
            //Now, Cloned and Existing Object have different Memory Locations for the Address Object
            employee.EmpAddress = EmpAddress.GetClone();
            return employee;
        }
    }
    public class Address
    {
        public string address { get; set; }
        //Creating a Cloned Object of the Current Object
        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }
}
