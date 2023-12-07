using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services;

public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();

    // Menu that runs the method depending on the users input
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

    // Add a contact options that reads the input values and adds it to the Contact
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

    // Remove a contact options
    // Checks if the contact exists, the length is longer then 2 
    private void RemoveContactOptions()
    {
        Console.WriteLine("Remove Contact");
        Console.WriteLine("---------------");

        Console.WriteLine("Enter the full name (firstname and lastname) of the contact you want to remove");

        var fullName = Console.ReadLine()!;
        if (string.IsNullOrEmpty(fullName))
        {
            Console.WriteLine("Invalid input. Enter a full name (firstname lastname)");
            return;
        }

        var nameParts = fullName.Split(' ');
        if (nameParts.Length != 2) 
        {
            Console.WriteLine("Invalid input. Please enter a full name (firstname lastname)");
            return;
        }
     
        var firstName = nameParts[0];
        var lastName = nameParts[1];

        var contact = _contactService.GetSingleContact(firstName);
        if (contact == null || contact.LastName != lastName) 
        {
            Console.WriteLine("Can't find a contact with that name");
            return;
        }

        _contactService.RemoveContact(firstName, lastName);
    }

    // Prints out a contact
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

    // Loops out all the contact
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
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Contact Info: {contact.Email} {contact.PhoneNumber}");
                Console.WriteLine($"Address: {contact.Address} {contact.ZipCode} {contact.City}");
                Console.WriteLine("\n");
            }
        }
    }

    // Closes the application
    private void CloseApplicationOptions()
    {
        Environment.Exit(0);
    }
}
