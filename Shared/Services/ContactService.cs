using Shared.Interfaces;
using Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService = new FileService();
    private List<IContact> _contacts = [];
    private readonly string _filePath = @"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json";

   
    public bool AddContact(IContact contact)
    {
        try
        {
            if (!_contacts.Any(name => name.FirstName == contact.FirstName))
            {
                _contacts.Add(contact);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }

 
    public bool RemoveContactByEmail(string email)
    {
        try
        {
            var contactToRemove = _contacts.FirstOrDefault(c => c.Email == email);
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);

                string json = JsonConvert.SerializeObject(_contacts, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
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

    public IContact GetSingleContact(string firstName)
    {
        try
        {
            GetAllContacts();

            var contact = _contacts.FirstOrDefault(x => x.FirstName == firstName);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<IContact> GetAllContacts()
    {
        try
        {
            var content = _fileService.GetContactsFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
