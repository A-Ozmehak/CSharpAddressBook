
using Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Shared.Services;

public class ContactService
{
    private readonly FileService _fileService;

    public ContactService(FileService fileService)
    {
        _fileService = fileService;
    }

    public List<Contact> Contacts { get; private set; } = [];
    private readonly string _filePath = @"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json";

    public event EventHandler? ContactUpdated;

    public bool AddContact(Contact contact)
    {
        try
        {
            Contacts.Add(contact);

            string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            _fileService.SaveContactToFile(_filePath, json);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }

    public bool RemoveContactByEmail(string email)
    {
        try
        {
            var contactToRemove = Contacts.FirstOrDefault(c => c.Email == email);
            if (contactToRemove != null)
            {
                Contacts.Remove(contactToRemove);

                string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                _fileService.SaveContactToFile(_filePath, json);
                return true;

            }
            else
            {
                Console.WriteLine("Contact not found.");
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public Contact GetSingleContact(string firstName)
    {
        try
        {
            GetAllContacts();

            var contact = Contacts.FirstOrDefault(x => x.FirstName == firstName);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        try
        {
            var content = _fileService.GetContactsFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                Contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return Contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool AddContactToList(Contact contact)
    {
        try
        {
            Contacts.Add(contact);

            string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            _fileService.SaveContactToFile(_filePath, json);
            ContactUpdated?.Invoke(this, new EventArgs());

            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public IEnumerable<Contact> GetContacts()
    {
        try
        {
            var content = _fileService.GetContactsFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                Contacts = JsonConvert.DeserializeObject<List<Contact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return Contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool RemoveContactFromList(string email)
    {
        try
        {
            var contactToRemove = Contacts.FirstOrDefault(c => c.Email == email);
            if (contactToRemove != null)
            {
                Contacts.Remove(contactToRemove);

                string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
                _fileService.SaveContactToFile(_filePath, json);
                ContactUpdated?.Invoke(this, new EventArgs());

                return true;
            }
            else
            {
                Console.WriteLine("Contact not found.");
                return false;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public void Update(Contact contact)
    {
        var addressBookItem = Contacts.FirstOrDefault(i => i.FullName == contact.FullName);
        if (addressBookItem != null)
        {
            addressBookItem = contact;

            string json = JsonConvert.SerializeObject(Contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            _fileService.SaveContactToFile(_filePath, json);

            ContactUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
