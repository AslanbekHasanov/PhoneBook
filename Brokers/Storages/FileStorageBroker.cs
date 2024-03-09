using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Brokers.Storages
{
    internal class FileStorageBroker : IStorageBroker
    {
        private const string FilePath = "../../../Assets/Contacts.txt";
        private bool isDelete;

        public FileStorageBroker() 
        {
            isDelete = false;
            EnsureFileExists();
        }

        public Contact AddContact(Contact contact)
        {
            string contactLine = $"{contact.Id}*{contact.Name}*{contact.Phone}\n";
            File.AppendAllText(FilePath, contactLine);

            return contact;
        }

        public bool DeleteContact(string phone)
        {
            string[] contactLines = File.ReadAllLines(FilePath);

            for (int itaration = 0; itaration < contactLines.Length; itaration++)
            {
                string contactLine = contactLines[itaration];
                string[] contactProperties = contactLine.Split('*');

                if (contactProperties[2].Contains(phone))
                {
                    isDelete = true;
                    contactLines[itaration] = null;
                    break;
                }
            }

            if (IsDeleteFile() is true)
            {
                for (int itaration = 0; itaration < contactLines.Length; itaration++)
                {
                    if (contactLines[itaration] is not null)
                    {
                        File.AppendAllText(FilePath, $"{contactLines[itaration]}\n");
                    }
                }
                return true;
            }
            return false;
        }

        public Contact[] ReadAllContacts()
        {
            string[] contactLines = File.ReadAllLines(FilePath);

            Contact[] contacts = new Contact[contactLines.Length];
            for(int itaration = 0; itaration  < contactLines.Length; itaration++)
            {
                string contactLine = contactLines[itaration];
                string[] contactProperties = contactLine.Split('*');

                Contact contact = new Contact()
                {
                    Id = Convert.ToInt32(contactProperties[0]),
                    Name = contactProperties[1],
                    Phone = contactProperties[2]
                };

                contacts[itaration] = contact;
            }

            return contacts;
        }

        public bool UpdateContact(Contact contact)
        {
            string[] contactLines = File.ReadAllLines(FilePath);

            for (int itaration = 0; itaration < contactLines.Length; itaration++)
            {
                string contactLine = contactLines[itaration];
                string[] contactProperties = contactLine.Split('*');

                if (contactProperties[0].Contains(contact.Id.ToString()))
                {
                    contactProperties[1] = contact.Name;
                    contactProperties[2] = contact.Phone;
                    return true;
                }
            }
            return false;
        }

        private bool IsDeleteFile()
        {
            if (isDelete is true) 
            {
                File.Delete(FilePath);
                File.Create(FilePath).Close();
                return true;
            }
            return false;
        }

        private void EnsureFileExists()
        {
            bool fileExists = File.Exists(FilePath);

            if (fileExists is false)
            {
                File.Create(FilePath).Close();
                
            }
        }
    }
}
