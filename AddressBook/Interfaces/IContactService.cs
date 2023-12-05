using AddressBook.Models;

namespace AddressBook.Interfaces;

public interface IContactService
{
    void AddContact(Contact contact);
    void RemoveContact(Contact contact);
    void GetSingleContact(Contact contact);
    void GetAllContacts();
}
