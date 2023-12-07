using AddressBook.Interfaces;
using AddressBook.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBook.Services;

public class ContactService : IContactService
{
    private readonly FileService _fileService = new FileService(@"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json");
    private List<Contact> _contacts = [];

    public void AddContact(Contact contact)
    {
        try
        {
            if (!_contacts.Any(name => name.FirstName == contact.FirstName))
            {
                _contacts.Add(contact);
                _fileService.SaveContactToFile(JsonConvert.SerializeObject(_contacts));
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

    }

    public void RemoveContact(string firstName, string lastName)
    {
        var contactToRemove = _contacts.FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);
        if (contactToRemove != null)
        {
            _contacts.Remove(contactToRemove);
            var json = JsonConvert.SerializeObject(contactToRemove);
            _fileService.SaveContactToFile(json);
        }
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        try
        {
            var content = _fileService.GetContactsFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
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