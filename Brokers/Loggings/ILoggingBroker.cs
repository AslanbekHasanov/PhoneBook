using System;

namespace PhoneBook.Brokers.Loggings
{
    internal interface ILoggingBroker
    {
        void LogInformation(string message);
        void LogError(string userMessage);
        void LogError(Exception exception);
    }
}
