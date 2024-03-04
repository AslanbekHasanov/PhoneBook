// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

bool isCantinue = true;

do
{
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
        Console.WriteLine("Create phone book, Not Implemented");
    }
    if(command == 2)
    {
        Console.WriteLine("Update phone book, Not Implemented");
    }
    if (command == 3)
    {
        Console.WriteLine("Delet one phone book, Not Implemented");
    }
    if (command == 4)
    {
        Console.WriteLine("Read all phone book, Not Implemented");
    }
    if (command == 5)
    {
        Console.WriteLine("Read one phone book, Not Implemented");
    }

    Console.Write("Is your cantinue(yes / no): ");
    string nextCount = Console.ReadLine();

    if (nextCount.ToString().ToLower().Contains("no"))
    {
        isCantinue = false;
    }
} while (isCantinue);