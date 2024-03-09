// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------
using PhoneBook.Brokers.Storages;
using PhoneBook.Models;
using PhoneBook.Services.Contacts;
using System;

bool isCantinue = true;

do
{
    IContactService contactService = new ContactService();

    Console.Clear();
    Console.WriteLine("Welcome to, Phone Book");
    Console.WriteLine("1. Create phone book");
    Console.WriteLine("2. Update phone book");
    Console.WriteLine("3. Delete one phone book");
    Console.WriteLine("4. Read all phone book");
    Console.WriteLine("5. Read one phone book");

    Console.Write("Enter your command(1,2,3...): ");
    int command = Convert.ToInt32(Console.ReadLine());

    if (command == 1)
    {
        Contact contact = new Contact();
        Console.Write("Enter your id: ");
        contact.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your name: ");
        contact.Name = Console.ReadLine();
        Console.Write("Enter your phone: ");
        contact.Phone = Console.ReadLine();

        contactService.AddContact(contact);
    }
    if(command == 2)
    {
        Contact contact = new Contact();
        Console.Write("Enter your id: ");
        contact.Id = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your name: ");
        contact.Name = Console.ReadLine();
        Console.Write("Enter your phone: ");
        contact.Phone = Console.ReadLine();

        contactService.UpdateContact(contact);
    }
    if (command == 3)
    {
        Console.Write("Enter your phone(f: (122-2222-222)): ");
        string phone = Console.ReadLine();

        contactService.DeleteContact(phone);
    }
    if (command == 4)
    {
        contactService.SowContacts();
    }
    if (command == 5)
    {
        Console.Write("Enter yuor phone(i: 111-1111-111): ");
        string phone = Console.ReadLine();

        contactService.ReadContact(phone);
    }

    Console.Write("Is your cantinue(yes / no): ");
    string nextCount = Console.ReadLine();

    if (nextCount.ToString().ToLower().Contains("no"))
    {
        isCantinue = false;
    }
} while (isCantinue);