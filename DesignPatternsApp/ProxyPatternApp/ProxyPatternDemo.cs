using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatternApp
{
    //BankAccount(The actual object that manages the balance) :
    public class BankAccount
    {
        private decimal _balance;
        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            Console.WriteLine($"Depositing: ${amount}");
            _balance += amount;
            Console.WriteLine($"New Balance: ${_balance}");
        }
        public void Withdraw(decimal amount)
        {
            if (_balance >= amount)
            {
                Console.WriteLine($"Withdrawing: ${amount}");
                _balance -= amount;
                Console.WriteLine($"New Balance: ${_balance}");
            }
            else
            {
                Console.WriteLine($"Insufficient funds. Current Balance: ${_balance}");
            }
        }
    }
    //BankAccountProxy(The Synchronization Proxy) :
    public class BankAccountProxy
    {
        private readonly BankAccount _bankAccount;
        private readonly object _lock = new object();
        public BankAccountProxy(decimal initialBalance)
        {
            _bankAccount = new BankAccount(initialBalance);
        }
        public void SafeDeposit(decimal amount)
        {
            lock (_lock)
            {
                _bankAccount.Deposit(amount);
            }
        }
        public void SafeWithdraw(decimal amount)
        {
            lock (_lock)
            {
                _bankAccount.Withdraw(amount);
            }
        }
    }
    //Client Code
    //Testing Synchronization Proxy Design Pattern
    public class Program
    {
        public static void Main()
        {
            BankAccountProxy accountProxy = new BankAccountProxy(1000);
            // Multiple devices/instances trying to modify the account balance concurrently
            Task.Run(() => accountProxy.SafeDeposit(200));
            Task.Run(() => accountProxy.SafeWithdraw(500));
            Task.Run(() => accountProxy.SafeDeposit(300));
            Task.Run(() => accountProxy.SafeWithdraw(150));
            Console.ReadKey();
        }
    }
}
