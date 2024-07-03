#nullable disable
namespace StrategyPatternApp
{
    // Strategy Interface
    // The IPaymentStrategy Interface declares the method Pay that is common to all supported versions of the algorithm.
    // The Context is going to use this IPaymentStrategy Interface to call the algorithm defined by Concrete Strategies.
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }
    // Concrete Strategy A
    // The following CreditCardPaymentStrategy Class implements the IPaymentStrategy Interface and 
    // Implement the Pay Method. 
    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " using Credit Card");
        }
    }

    // Concrete Strategy B
    // The following DebitCardPaymentStrategy class implements the IPaymentStrategy Interface and 
    // Implement the Pay Method. 
    public class DebitCardPaymentStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " using Debit Card");
        }
    }

    // Concrete Strategy C
    // The following CashPaymentStrategy class implement the IPaymentStrategy Interface and 
    // Implement the Pay Method. 
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Customer pays Rs " + amount + " By Cash");
        }
    }

    // The Context Provides the interface which is going to be used by the Client.
    public class PaymentContext
    {
        // The Context has a reference to the Strategy object.
        // The Context does not know the concrete class of a strategy. 
        // It should work with all strategies via the Strategy interface.
        private IPaymentStrategy PaymentStrategy;
        // The Client will set what PaymentStrategy to use by calling this method at runtime
        public void SetPaymentStrategy(IPaymentStrategy strategy)
        {
            PaymentStrategy = strategy;
        }
        // The Context delegates the work to the Strategy object instead of
        // implementing multiple versions of the algorithm on its own.
        public void Pay(double amount)
        {
            PaymentStrategy.Pay(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ask the user to Select the Payment Type
            Console.WriteLine("Please Select Payment Type : \n1 For CreditCard \n2 For DebitCard \n3 For Cash");
            int SelectedPaymentType = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Payment type is : " + SelectedPaymentType);
            Console.WriteLine("\nPlease enter Amount to Pay : ");
            double Amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Amount is : " + Amount);
            //Create an Instance of the PaymentContext class
            PaymentContext context = new PaymentContext();
            //Based on the Payment Type Selected by user at Runtime,
            //Create the Appropriate Payment Strategy Instance and call the SetPaymentStrategy method
            if (SelectedPaymentType == (int)PaymentType.CreditCard)
            {
                context.SetPaymentStrategy(new CreditCardPaymentStrategy());
            }
            else if (SelectedPaymentType == (int)PaymentType.DebitCard)
            {
                context.SetPaymentStrategy(new DebitCardPaymentStrategy());
            }
            else if (SelectedPaymentType == (int)PaymentType.Cash)
            {
                context.SetPaymentStrategy(new CashPaymentStrategy());
            }
            else
            {
                Console.WriteLine("You Select an Invalid Option");
            }
            //Finally, call the Pay Method
            context.Pay(Amount);
            Console.ReadKey();
        }
    }
    public enum PaymentType
    {
        CreditCard = 1,  // 1 for CreditCard
        DebitCard = 2,   // 2 for DebitCard
        Cash = 3, // 3 for Cash
    }
}