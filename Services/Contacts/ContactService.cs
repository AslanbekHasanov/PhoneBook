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

        public Contact AddContact(Contact contact)
        {
            return contact is null
                ? CreateAndLogInvalidContact() 
                : ValidateAndAddContact(contact);
        }

        public bool DeleteContact(string phone)
        {
            bool isDeleted = this.storageBroker.DeleteContact(phone);
            return isDeleted;
        }

        public void SowContacts()
        {
            Contact[] contacts = this.storageBroker.ReadAllContacts();

            foreach (Contact contact in contacts)
            {
                this.loggingBroker.LogInformation($"{contact.Id}. {contact.Name} - {contact.Phone}");
            }

            this.loggingBroker.LogInformation($"=== End of contacts ===");
        }

        private Contact CreateAndLogInvalidContact()
        {
            this.loggingBroker.LogError("Contact is invalid.");
            return new Contact();
        }

        private Contact ValidateAndAddContact(Contact contact)
        {
            if (contact.Id is 0
                || String.IsNullOrWhiteSpace(contact.Name)
                || String.IsNullOrWhiteSpace(contact.Phone))
            {
                this.loggingBroker.LogError("Contact details missing.");
                return new Contact();
            }
            else
            {
                return this.storageBroker.AddContact(contact);
            }
        }
    }

}
