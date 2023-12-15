using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace AddressBook.Services;

public class MenuService
{
    private static readonly IFileService _fileService = new FileService();
    private static readonly IContactService _contactService = new ContactService(_fileService);

    public static void ShowMenu()
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("What do you want to do?");
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
                    Console.Clear();
                    AddContactOptions();
                    break;
                case "2":
                    Console.Clear();
                    RemoveContactOptions();
                    break;
                case "3":
                    Console.Clear();
                    GetSingleContactOptions();
                    break;
                case "4":
                    Console.Clear();
                    GetAllContactsOptions();
                    break;
                case "5":
                    Console.Clear();
                    CloseApplicationOptions();
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again");
                    Console.ReadKey();
                    break;

            }
        }
    }

    public static void AddContactOptions()
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

        _contactService.AddContact(contact);
    }

    public static void RemoveContactOptions()
    {
        Console.WriteLine("Remove Contact");
        Console.WriteLine("---------------");

        Console.WriteLine("Enter the email of the contact you want to remove");
        string email = Console.ReadLine()!;

        bool isRemoved = _contactService.RemoveContactByEmail(email);
        if (isRemoved)
        {
            Console.WriteLine("Contact removed successfully.");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }

    }

    public static void GetSingleContactOptions()
    {
        Console.WriteLine("Show Contact");
        Console.WriteLine("---------------");
        
        Console.WriteLine("Enter the name of the contact you want to see: ");
        string firstName = Console.ReadLine()!;
        IContact contact = _contactService.GetSingleContact(firstName);

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

    public static void GetAllContactsOptions()
    {
        var contacts = _contactService?.GetAllContacts() ?? new List<IContact>();

        Console.WriteLine("All Contacts");
        Console.WriteLine("---------------");

        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found");
            Console.WriteLine("\n");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Contact Info: {contact.Email} {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.Address} {contact.ZipCode} {contact.City}");
                Console.WriteLine("\n");
            }
        }
    }

    private static void CloseApplicationOptions()
    {
        Environment.Exit(0);
    }
}
