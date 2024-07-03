using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoCartApp
{
    public class CartMemento
    {
        public List<string> Items { get; private set; }
        public CartMemento(List<string> items)
        {
            this.Items = new List<string>(items);
        }
    }
    //ShoppingCart - Represents the current cart and its items.
    public class ShoppingCart
    {
        public List<string> Items { get; private set; } = new List<string>();
        public void AddItem(string item)
        {
            Items.Add(item);
        }
        public CartMemento Save()
        {
            return new CartMemento(Items);
        }
        public void Restore(CartMemento memento)
        {
            Items = new List<string>(memento.Items);
        }
    }
    //CartHistory - Manages and keeps track of saved states of the cart.
    public class CartHistory
    {
        private Stack<CartMemento> _history = new Stack<CartMemento>();
        public void Save(ShoppingCart cart)
        {
            _history.Push(cart.Save());
        }
        public CartMemento GetLastSavedState()
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
            ShoppingCart cart = new ShoppingCart();
            CartHistory history = new CartHistory();
            cart.AddItem("Laptop");
            cart.AddItem("Mouse");
            // User saves the current cart state before applying a promo code
            history.Save(cart);
            // A promo code automatically adds a free "USB stick"
            cart.AddItem("USB stick");
            Console.WriteLine($"Current Cart Items: {string.Join(", ", cart.Items)}");
            // Outputs: Current Cart Items: Laptop, Mouse, USB stick
            // User doesn't want the free USB stick and decides to revert to the previous state
            cart.Restore(history.GetLastSavedState());
            Console.WriteLine($"Restored Cart Items: {string.Join(", ", cart.Items)}");
            // Outputs: Restored Cart Items: Laptop, Mouse
            Console.ReadKey();
        }
    }
}
