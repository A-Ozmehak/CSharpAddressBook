using Shared.Interfaces;
using Shared.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Shared.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    //private readonly IFileService _fileService = new FileService();
    public List<IContact> Contacts { get; private set; } = [];
    private readonly string _filePath = @"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json";

   
    public bool AddContact(IContact contact)
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

    public IContact GetSingleContact(string firstName)
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

    public IEnumerable<IContact> GetAllContacts()
    {
        try
        {
            var content = _fileService.GetContactsFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                Contacts = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return Contacts;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}
