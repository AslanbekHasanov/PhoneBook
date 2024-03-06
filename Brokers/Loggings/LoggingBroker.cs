using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Brokers.Loggings
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInformation(string message) =>
            Console.WriteLine(message);

        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }

        public void LogError(Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(exception.Message);
            Console.ResetColor();
        }

        
    }
}
