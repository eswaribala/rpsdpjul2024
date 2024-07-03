#nullable disable
namespace VisitorPatternApp
{
    // Element Interface
    interface IProduct
    {
        void Accept(IProductVisitor visitor);
    }
    // Concrete Elements
    class Book : IProduct
    {
        public double Price { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class Electronic : IProduct
    {
        public double Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    class Grocery : IProduct
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public void Accept(IProductVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    // Visitor Interface
    interface IProductVisitor
    {
        void Visit(Book book);
        void Visit(Electronic electronic);
        void Visit(Grocery grocery);
    }
    // Concrete Visitor for calculating discounts
    class DiscountVisitor : IProductVisitor
    {
        public double DiscountedPrice { get; private set; } = 0;
        public void Visit(Book book)
        {
            DiscountedPrice = book.Price * 0.90;  // 10% discount for books
        }
        public void Visit(Electronic electronic)
        {
            DiscountedPrice = electronic.Price * 0.95;  // 5% discount for electronics
        }
        public void Visit(Grocery grocery)
        {
            DiscountedPrice = grocery.Price;  // No discount for groceries
        }
    }
    // Concrete Visitor for displaying descriptions
    class DescriptionVisitor : IProductVisitor
    {
        public void Visit(Book book)
        {
            Console.WriteLine($"Book: {book.Title}, ISBN: {book.ISBN}");
        }
        public void Visit(Electronic electronic)
        {
            Console.WriteLine($"Electronic: {electronic.Brand} {electronic.Model}");
        }
        public void Visit(Grocery grocery)
        {
            Console.WriteLine($"Grocery: {grocery.Name}, Expires on: {grocery.ExpiryDate.ToShortDateString()}");
        }
    }
    // Testing the Visitor Design Pattern
    // Client Code
    public class Client
    {
        public static void Main()
        {
            IProduct book = new Book { Price = 100, ISBN = "123456", Title = "Design Patterns" };
            IProduct laptop = new Electronic { Price = 1000, Brand = "Dell", Model = "XPS 15" };
            IProduct apple = new Grocery { Price = 2, Name = "Apple", ExpiryDate = DateTime.Now.AddDays(10) };
            var discountVisitor = new DiscountVisitor();
            var descriptionVisitor = new DescriptionVisitor();
            book.Accept(discountVisitor);
            Console.WriteLine($"Discounted Price of Book: ${discountVisitor.DiscountedPrice}");
            book.Accept(descriptionVisitor);
            laptop.Accept(discountVisitor);
            Console.WriteLine($"Discounted Price of Laptop: ${discountVisitor.DiscountedPrice}");
            laptop.Accept(descriptionVisitor);
            apple.Accept(discountVisitor);
            Console.WriteLine($"Discounted Price of Apple: ${discountVisitor.DiscountedPrice}");
            apple.Accept(descriptionVisitor);
            Console.ReadKey();
        }
    }
}