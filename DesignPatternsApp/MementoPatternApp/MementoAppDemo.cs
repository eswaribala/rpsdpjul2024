using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPatternApp
{
    //TransactionMemento - This will store the state of the account.
    public class TransactionMemento
    {
        public decimal Balance { get; }
        public TransactionMemento(decimal balance)
        {
            this.Balance = balance;
        }
    }
    //BankAccount - Represents a bank account. 
    //It can create a memento and restore its state from a memento.
    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        public TransactionMemento CreateMemento()
        {
            return new TransactionMemento(Balance);
        }
        public void RestoreFromMemento(TransactionMemento memento)
        {
            this.Balance = memento.Balance;
        }
    }
    //TransactionHistory - Manages the saved states of the account.
    public class TransactionHistory
    {
        private Stack<TransactionMemento> _history = new Stack<TransactionMemento>();
        public void SaveState(BankAccount account)
        {
            _history.Push(account.CreateMemento());
        }
        public TransactionMemento UndoTransaction()
        {
            return _history.Pop();
        }
    }

    // Testing the Memento Design Pattern
    // Client Code
    public class Client
    {
        public static void Main()
        {
            BankAccount account = new BankAccount(1000.00M);
            TransactionHistory history = new TransactionHistory();
            account.Deposit(200);
            history.SaveState(account);  // Balance: 1200
            account.Withdraw(100);
            history.SaveState(account);  // Balance: 1100
            account.Withdraw(50);
            history.SaveState(account);  // Balance: 1050
            // Oops! That last withdrawal was a mistake. Let's undo it.
            account.RestoreFromMemento(history.UndoTransaction());
           // account.RestoreFromMemento(history.UndoTransaction());
            //account.RestoreFromMemento(history.UndoTransaction());
            Console.WriteLine($"Current Balance: ${account.Balance}");
            // Outputs: Current Balance: $1050.00
            Console.ReadKey();
        }
    }
}
