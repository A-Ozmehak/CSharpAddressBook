using AddressBook.Interfaces;
using AddressBook.Models;

namespace AddressBook.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = [];

    public void AddContact(Contact contact)
    {
        _contacts.Add(contact);
    }

    public void RemoveContact(Contact contact)
    {
        string fullName = GetFullName(firstName, lastName);
        Contact contactToRemove = _contacts.Find(x => GetFullName(x.FirstName, x.LastName) == fullName);

        if (contactToRemove != null)
        {
            _contacts.Remove(contactToRemove);
        }
    }

    public List<Contact> GetAllContacts()
    {
        return _contacts;
    }

    public Contact GetSingleContact(string firstName)
    {
        return _contacts.Find(x => x.FirstName == firstName)!;
    }

    public string GetFullName(string firstName, string lastName)
    {
        return firstName + lastName;
    }
}
