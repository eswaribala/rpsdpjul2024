using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerFactoryApp
{
    //Define the Product Interface
    public interface ILogger
    {
        void Log(string message);
    }
    //Concrete Implementations for the Products
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Console: " + message);
        }
    }
    public class FileLogger : ILogger
    {
        private string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void Log(string message)
        {
            File.AppendAllText(_filePath, "File: " + message + Environment.NewLine);
        }
    }
    // You can also add other loggers like DatabaseLogger, CloudLogger, etc.
    //Factory Class to Produce the Products
    public static class LoggerFactory
    {
        public static ILogger CreateLogger(string type)
        {
            switch (type.ToLower())
            {
                case "console":
                    return new ConsoleLogger();
                case "file":
                    return new FileLogger("log.txt");
                // For simplicity, file path is hardcoded
                // You can extend here with other logger types
                default:
                    throw new ArgumentException("Invalid logger type");
            }
        }
    }

    // Testing the Factory Design Pattern
    public class Program
    {
        public static void Main()
        {
            ILogger logger;
            logger = LoggerFactory.CreateLogger("console");
            logger.Log("This is a console log!");
            logger = LoggerFactory.CreateLogger("file");
            logger.Log("This message is written to a file.");
            // The beauty of this approach is that the client code remains unchanged
            // even if we introduce new logger types in the future.
            Console.ReadKey();
        }
    }
}
