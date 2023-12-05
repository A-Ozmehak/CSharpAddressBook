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

    public void RemoveContact(Contact contact)
    {
           contacts.Remove(contact);
    }

    public void GetSingleContact(Contact contact)
    {
        contacts.Find(contact);
    }

    public void GetAllContacts()
    {
        contacts.ToList();
    }
}
