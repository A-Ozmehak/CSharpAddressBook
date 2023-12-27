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

    /// <summary>
    /// Adds a contact to the list
    /// </summary>
    /// <param name="contact">The contact that is added</param>
    /// <returns>True if the contact was added, otherwise false</returns>
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

    /// <summary>
    /// Removes a contact from the contact list
    /// </summary>
    /// <param name="email">The email of the contact to be removed</param>
    /// <returns>True if the contact was successfully removed, false otherwise</returns>
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

    /// <summary>
    /// Get one contact from the list
    /// </summary>
    /// <param name="firstName">The first name of the contact that is shown</param>
    /// <returns>The contact information, otherwise null</returns>
    public Contact GetSingleContact(string firstName)
    {
        try
        {
            GetContacts();

            var contact = Contacts.FirstOrDefault(x => x.FirstName == firstName);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
 
    /// <summary>
    /// Gets all the contacts in the list
    /// </summary>
    /// <returns>All the contact, otherwise null</returns>
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

   
    /// <summary>
    /// Updates the list of contacts
    /// </summary>
    /// <param name="contact">The contact that is to be updated</param>
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
