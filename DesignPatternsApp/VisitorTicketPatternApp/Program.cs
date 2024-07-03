namespace VisitorTicketPatternApp
{
    // Element Interface
    public interface IVisitor
    {
        void Accept(ITicketVisitor ticketVisitor);
    }
    // Concrete Elements
    public class Adult : IVisitor
    {
        public void Accept(ITicketVisitor ticketVisitor)
        {
            ticketVisitor.AssignTicketPrice(this);
        }
    }
    public class Child : IVisitor
    {
        public void Accept(ITicketVisitor ticketVisitor)
        {
            ticketVisitor.AssignTicketPrice(this);
        }
    }
    public class Senior : IVisitor
    {
        public void Accept(ITicketVisitor ticketVisitor)
        {
            ticketVisitor.AssignTicketPrice(this);
        }
    }
    // Visitor Interface
    public interface ITicketVisitor
    {
        void AssignTicketPrice(Adult adult);
        void AssignTicketPrice(Child child);
        void AssignTicketPrice(Senior senior);
    }
    // Concrete Visitor for Standard Ticket
    public class StandardTicket : ITicketVisitor
    {
        public void AssignTicketPrice(Adult adult)
        {
            Console.WriteLine("Standard Ticket Price for Adult: $50");
        }
        public void AssignTicketPrice(Child child)
        {
            Console.WriteLine("Standard Ticket Price for Child: $25");
        }
        public void AssignTicketPrice(Senior senior)
        {
            Console.WriteLine("Standard Ticket Price for Senior: $40");
        }
    }
    // Concrete Visitor for VIP Ticket
    public class VIPTicket : ITicketVisitor
    {
        public void AssignTicketPrice(Adult adult)
        {
            Console.WriteLine("VIP Ticket Price for Adult: $80");
        }
        public void AssignTicketPrice(Child child)
        {
            Console.WriteLine("VIP Ticket Price for Child: $50");
        }
        public void AssignTicketPrice(Senior senior)
        {
            Console.WriteLine("VIP Ticket Price for Senior: $70");
        }
    }
    // Concrete Visitor for Holiday Special Ticket
    public class HolidaySpecialTicket : ITicketVisitor
    {
        public void AssignTicketPrice(Adult adult)
        {
            Console.WriteLine("Holiday Special Ticket Price for Adult: $60");
        }
        public void AssignTicketPrice(Child child)
        {
            Console.WriteLine("Holiday Special Ticket Price for Child: $30");
        }
        public void AssignTicketPrice(Senior senior)
        {
            Console.WriteLine("Holiday Special Ticket Price for Senior: $50");
        }
    }
    // Testing the Visitor Design Pattern
    // Client Code
    public class Client
    {
        public static void Main()
        {
            IVisitor[] parkVisitors = new IVisitor[] {
                new Adult(),
                new Child(),
                new Senior()
            };
            ITicketVisitor standardTicket = new StandardTicket();
            ITicketVisitor vipTicket = new VIPTicket();
            ITicketVisitor holidayTicket = new HolidaySpecialTicket();
            Console.WriteLine("=== Standard Ticket Prices ===");
            foreach (var visitor in parkVisitors)
            {
                visitor.Accept(standardTicket);
            }
            Console.WriteLine("\n=== VIP Ticket Prices ===");
            foreach (var visitor in parkVisitors)
            {
                visitor.Accept(vipTicket);
            }
            Console.WriteLine("\n=== Holiday Special Ticket Prices ===");
            foreach (var visitor in parkVisitors)
            {
                visitor.Accept(holidayTicket);
            }
            Console.ReadKey();
        }
    }
}