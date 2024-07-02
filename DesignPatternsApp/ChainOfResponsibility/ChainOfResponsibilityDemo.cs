using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace ChainOfResponsibility
{
    //Expense Object
    public class Expense
    {
        public double Amount { get; set; }
        public Expense(double amount)
        {
            Amount = amount;
        }
    }
    //Abstract Handler
    public abstract class ApprovalHandler
    {
        protected ApprovalHandler nextHandler;
        public void SetNext(ApprovalHandler handler)
        {
            nextHandler = handler;
        }
        public abstract void ApproveRequest(Expense expense);
    }

    //Concrete Handlers
    public class Manager : ApprovalHandler
    {
        public override void ApproveRequest(Expense expense)
        {
            if (expense.Amount < 1000)
            {
                Console.WriteLine($"Manager Approved Expense of ${expense.Amount}");
            }
            else if (nextHandler != null)
            {
                nextHandler.ApproveRequest(expense);
            }
        }
    }
    public class Director : ApprovalHandler
    {
        public override void ApproveRequest(Expense expense)
        {
            if (expense.Amount >= 1000 && expense.Amount < 10000)
            {
                Console.WriteLine($"Director Approved Expense of ${expense.Amount}");
            }
            else if (nextHandler != null)
            {
                nextHandler.ApproveRequest(expense);
            }
        }
    }
    public class CEO : ApprovalHandler
    {
        public override void ApproveRequest(Expense expense)
        {
            if (expense.Amount >= 10000)
            {
                Console.WriteLine($"CEO Approved Expense of ${expense.Amount}");
            }
            else
            {
                Console.WriteLine($"Expense of ${expense.Amount} Could Not Be Approved.");
            }
        }
    }

    //Client Code
    public class Program
    {
        static void Main()
        {
            // Setup Approval Chain
            var manager = new Manager();
            var director = new Director();
            var ceo = new CEO();
            manager.SetNext(director);
            director.SetNext(ceo);
            // Test chain
            var expense1 = new Expense(500);
            var expense2 = new Expense(5000);
            var expense3 = new Expense(15000);
            var expense4 = new Expense(25000);
            manager.ApproveRequest(expense1);
            manager.ApproveRequest(expense2);
            manager.ApproveRequest(expense3);
            manager.ApproveRequest(expense4);
            Console.ReadLine();
        }
    }
}
