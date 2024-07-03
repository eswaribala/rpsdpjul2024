namespace TemplateOrderPatternApp
{
    //Abstract Class(Template)
    public abstract class OrderProcessor
    {
        // The template method
        public void ProcessOrder()
        {
            ValidatePayment();
            DeductPayment();
            CheckStock();
            PackageProduct();
            Ship();
        }
        public void ValidatePayment()
        {
            Console.WriteLine("Validating payment details.");
        }
        public void DeductPayment()
        {
            Console.WriteLine("Deducting payment.");
        }
        public void CheckStock()
        {
            Console.WriteLine("Checking stock availability.");
        }
        // Abstract methods for steps that might vary across subclasses
        protected abstract void PackageProduct();
        protected abstract void Ship();
    }

    //Concrete Implementations:
    //For Perishable Goods
    public class PerishableGoodsOrder : OrderProcessor
    {
        protected override void PackageProduct()
        {
            Console.WriteLine("Packaging with refrigeration.");
        }
        protected override void Ship()
        {
            Console.WriteLine("Shipping with temperature control.");
        }
    }
    //For Digital Goods
    public class DigitalGoodsOrder : OrderProcessor
    {
        protected override void PackageProduct()
        {
            Console.WriteLine("Generating digital access key.");
        }
        protected override void Ship()
        {
            Console.WriteLine("Sending product download link via email.");
        }
    }

    // Testing the Template Method Design Pattern
    // Client Code
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Processing Perishable Goods Order:");
            OrderProcessor perishableOrder = new PerishableGoodsOrder();
            perishableOrder.ProcessOrder();
            Console.WriteLine("\nProcessing Digital Goods Order:");
            OrderProcessor digitalOrder = new DigitalGoodsOrder();
            digitalOrder.ProcessOrder();
            Console.ReadKey();
        }
    }
}