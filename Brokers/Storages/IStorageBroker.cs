﻿using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Brokers.Storages
{
    internal interface IStorageBroker
    {
        Contact AddContact(Contact contact);
        Contact[] ReadAllContacts();
        bool DeleteContact(string phone);
        bool UpdateContact(Contact contact);
        Contact ReadContact(string phone);
    }
}
