using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPatternApp
{
    // This is the Base Component interface that defines operations
    // that can be altered by decorators
    public interface Pizza
    {
        string MakePizza();
    }
    // Concrete Components provide default implementations of the operations.
    public class PlainPizza : Pizza
    {
        //The following MakePizza method returns the default Pizza
        public string MakePizza()
        {
            return "Plain Pizza";
        }
    }

    //Inherited from the Base Component Interface
    public abstract class PizzaDecorator : Pizza
    {
        //Create a Field to store the existing Pizza Object
        protected Pizza pizza;
        //Initializing the Field using Constructor
        //While Creating an instance of the PizzaDecorator (Instance of the Child Class that Implements PizzaDecorator abstract class)
        //We need to pass the existing pizza object which we want to decorate
        public PizzaDecorator(Pizza pizza)
        {
            //Store that existing pizza object in the pizza variable
            this.pizza = pizza;
        }
        //Providing Implementation for Pizza Interface i.e. MakePizza Method
        //Here, we are just calling the Concrete Component ManufactureCar Method using the existing pizza object
        //We are making this Method Virtual to allow the Child Concrete Decorator classes to override
        public virtual string MakePizza()
        {
            return pizza.MakePizza();
        }
    }

    //The following Concrete Decorator class will add Chicken to Existing Pizza
    public class ChickenPizzaDecorator : PizzaDecorator
    {
        //Pass the existing pizza while creating the Instance of ChickenPizzaDecorator
        //Also pass the same existing pizza object to the base constructor
        public ChickenPizzaDecorator(Pizza pizza) : base(pizza)
        {
        }
        //Overriding the MakePizza method to Chicken
        public override string MakePizza()
        {
            //First Call the Concrete Components MakePizza Method and then the AddChicken method
            return pizza.MakePizza() + AddChicken();
        }
        private string AddChicken()
        {
            return ", Chicken added";
        }
    }
    //The following Concrete Decorator class will add Vegetables to the Existing Pizza
    public class VegPizzaDecorator : PizzaDecorator
    {
        //Pass the existing pizza object while creating the Instance of VegPizzaDecorator class
        //Also pass the same existing pizza object to the base class constructor
        public VegPizzaDecorator(Pizza pizza) : base(pizza)
        {
        }
        //Overriding the MakePizza method to Vegetables
        public override string MakePizza()
        {
            //First Call the Concrete Components MakePizza Method and then the AddVegetables method
            return pizza.MakePizza() + AddVegetables();
        }
        private string AddVegetables()
        {
            return ", Vegetables added";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Create an instance of Concrete Component
            PlainPizza plainPizzaObj = new PlainPizza();
            //Calling the MakePizza method will create the pizza without chicken and vegetables
            string plainPizza = plainPizzaObj.MakePizza();
            Console.WriteLine(plainPizza);
            //Adding Chicken to the Plain Pizza
            //Create an instance PizzaDecorator class and 
            //pass existing plainPizzaObj as a parameter to the Constructor which we want to decorate
            PizzaDecorator chickenPizzaDecorator = new ChickenPizzaDecorator(plainPizzaObj);
            //Calling the MakePizza Method using the chickenPizzaDecorator object will add Chicken to the existing Plain Pizza
            string chickenPizza = chickenPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + chickenPizza + "' using ChickenPizzaDecorator");
            //The Process is the same for adding vegetables to the existing pizza
            VegPizzaDecorator vegPizzaDecorator = new VegPizzaDecorator(plainPizzaObj);
            string vegPizza = vegPizzaDecorator.MakePizza();
            Console.WriteLine("\n'" + vegPizza + "' using VegPizzaDecorator");
            Console.Read();
        }
    }
}
