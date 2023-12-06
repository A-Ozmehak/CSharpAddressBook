using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services;

public class ContactService : IContactService
{
    private List<Contact> contacts = [];

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void RemoveContact(string firstName, string lastName)
    {
        string fullName = GetFullName(firstName, lastName);
        Contact contactToRemove = contacts.Find(x => GetFullName(x.FirstName, x.LastName) == fullName);

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
        }
    }

    public void GetAllContacts()
    {
        //return contacts;
    }

    public Contact GetSingleContact(string firstName)
    {
        return contacts.Find(x => x.FirstName == firstName)!;
    }

    public string GetFullName(string firstName, string lastName)
    {
        return firstName + lastName;
    }
}
