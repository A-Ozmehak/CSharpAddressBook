using AddressBook.Models;

namespace AddressBook.Interfaces;

public interface IContactService
{
    void AddContact(Contact contact);
    void RemoveContact(string FirstName, string LastName);
    Contact GetSingleContact(string FirstName);

    IEnumerable<Contact> GetAllContacts();
}
