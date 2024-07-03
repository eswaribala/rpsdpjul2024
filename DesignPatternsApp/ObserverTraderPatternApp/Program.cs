namespace ObserverTraderPatternApp
{
    public class Program
    {
        public static void Main()
        {
            Stock HSBLStock = new Stock("HSBL", 150.00);
            Trader Pranaya = new Trader("Pranaya");
            Trader Kumar = new Trader("Kumar");
            Trader Rout = new Trader("Rout");
            //Register Traders
            HSBLStock.RegisterTrader(Pranaya);
            HSBLStock.RegisterTrader(Kumar);
            HSBLStock.RegisterTrader(Rout);
            //UnRegister
            HSBLStock.UnregisterTrader(Kumar);
            // Simulate a price change
            HSBLStock.Price = 152.50;
            Console.ReadKey();
        }
    }
    // Observer Interface
    public interface ITrader
    {
        void Update(Stock stock);
    }
    // Concrete Observer: Trader
    public class Trader : ITrader
    {
        public string Name { get; set; }
        public Trader(string name)
        {
            Name = name;
        }
        public void Update(Stock stock)
        {
            Console.WriteLine($"Notifying {Name} of {stock.Symbol}'s price change to {stock.Price}");
        }
    }
    // Subject Interface
    public interface IStockTicker
    {
        void RegisterTrader(ITrader trader);
        void UnregisterTrader(ITrader trader);
        void Notify();
    }
    // Concrete Subject: Stock
    public class Stock : IStockTicker
    {
        private List<ITrader> _traders = new List<ITrader>();
        public string Symbol { get; private set; }
        private double _price;
        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            _price = price;
        }
        public double Price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }
        public void RegisterTrader(ITrader trader)
        {
            _traders.Add(trader);
        }
        public void UnregisterTrader(ITrader trader)
        {
            _traders.Remove(trader);
        }
        public void Notify()
        {
            foreach (var trader in _traders)
            {
                trader.Update(this);
            }
        }
    }
}