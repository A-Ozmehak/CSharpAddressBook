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
            GetAllContactsOptions();
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
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    Console.ReadKey();
                    break;

            }
        }
    }

    private void AddContactOptions()
    {

        Console.WriteLine("Add Contact");
        Console.WriteLine("---------------");
        
        Console.WriteLine("Add a firstname: ");
        string firstName = Console.ReadLine()!;

        Console.WriteLine("Add a lastname: ");
        string lastName = Console.ReadLine()!;

        Console.WriteLine("Add a email: ");
        string email = Console.ReadLine()!;

        Console.WriteLine("Add a phonenumber: ");
        int phoneNumber = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Add a address: ");
        string address = Console.ReadLine()!;

        Console.WriteLine("Add a city: ");
        string city = Console.ReadLine()!;

        Console.WriteLine("Add a zipcode: ");
        string zipCode = Console.ReadLine()!;

        _contactService.AddContact(new Contact(firstName, lastName, email, phoneNumber, address, zipCode, city));
    }

    private void RemoveContactOptions()
    {
        Console.WriteLine("Remove Contact");
        Console.WriteLine("---------------");
        
        Console.WriteLine("Enter the firstname of the contact you want to remove: ");
        string firstName = Console.ReadLine()!;
        Console.WriteLine("Enter the lastname of the contact you want to remove: ");
        var lastName = Console.ReadLine();

        _contactService.RemoveContact(firstName, lastName!);
        
    }

    private void GetSingleContactOptions()
    {
        Console.WriteLine("Show Contact");
        Console.WriteLine("---------------");
        
        Console.WriteLine("Enter the name of the contact you want to see: ");
        string firstName = Console.ReadLine()!;
        Contact contact = _contactService.GetSingleContact(firstName);

        if (contact == null)
        {
            Console.WriteLine("Can't find a contact with that name");
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
        IEnumerable<Contact> contacts = _contactService.GetAllContacts();

        Console.WriteLine("All Contacts");
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
                Console.WriteLine("\n\n");
            }
        }
    }

    private void CloseApplicationOptions()
    {
        Environment.Exit(0);
    }
}
