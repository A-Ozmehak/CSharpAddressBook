using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services;

public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();
    public void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("Your Address Book");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Remove Contact");
            Console.WriteLine("3. Get Single Contact");
            Console.WriteLine("4. Get All Contacts");
            Console.WriteLine("5. Close Application");
            Console.WriteLine();
            Console.WriteLine("Choose an option: ");

            var option = Console.ReadLine();


            switch (option)
            {
                case "1":
                    AddContactOptions();
                    break;
                case "2":
                    RemoveContactOptions();
                    break;
                case "3":
                    GetSingleContactOptions();
                    break;
                case "4":
                    GetAllContactsOptions();
                    break;
                case "5":
                    CloseApplicationOptions();
                    return;

            }
        }
    }

    private void AddContactOptions()
    {
        IContact contact = new Contact();

        Console.WriteLine("Add Contact");
        Console.WriteLine("---------------");

        Console.WriteLine("Add a firstname: ");
        contact.FirstName = Console.ReadLine()!;

        Console.WriteLine("Add a lastname: ");
        contact.LastName = Console.ReadLine()!;

        Console.WriteLine("Add a email: ");
        contact.Email = Console.ReadLine()!;

        Console.WriteLine("Add a phonenumber: ");
        contact.PhoneNumber = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Add a address: ");
        contact.Address = Console.ReadLine()!;

        Console.WriteLine("Add a city: ");
        contact.City = Console.ReadLine()!;

        Console.WriteLine("Add a zipcode: ");
        contact.ZipCode = Console.ReadLine()!;

        //var res = _contactService.AddContact(contact);
    }

    private void RemoveContactOptions()
    {
        Console.WriteLine("Remove Contact");
        Console.WriteLine("Enter the email of the user you want to remove: ");
        var email = Console.ReadLine();
        
    }

    private void GetSingleContactOptions()
    {
        Console.WriteLine("Show Contact");
        Console.WriteLine("---------------");
        Console.WriteLine("Enter the name of the contact you want to see: "); 
       
        string firstName = Console.ReadLine()!;
        Contact contact = _contactService.GetSingleContact(firstName);

        if (!res.Any())
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{contact.Email} {contact.PhoneNumber}");
            Console.WriteLine($"{contact.Address} {contact.ZipCode} {contact.City}");
            Console.WriteLine("\n\n");
        }
        
    }

    private void GetAllContactsOptions()
    {
        List<Contact> contacts = _contactService.GetAllContacts();

        Console.WriteLine("Get All Contacts");
        Console.WriteLine("---------------");

        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{contact.Email} {contact.PhoneNumber}");
                Console.WriteLine($"{contact.Address} {contact.ZipCode} {contact.City}");
            }
        }
    }

    private void CloseApplicationOptions()
    {
        Environment.Exit(0);
    }
}
