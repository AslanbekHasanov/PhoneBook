using PhoneBook.Brokers.Loggings;
using PhoneBook.Brokers.Storages;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.Contacts
{
    internal class ContactService: IContactService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;
        public ContactService()
        {
            this.storageBroker = new FileStorageBroker();
            this.loggingBroker = new LoggingBroker();
        }

        public Contact AddContact(Contact contact) =>
            storageBroker.AddContact(contact);
    }

}
