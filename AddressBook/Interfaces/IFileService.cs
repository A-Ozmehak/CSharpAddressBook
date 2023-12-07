namespace AddressBook.Interfaces;

public interface IFileService
{
    bool SaveContactToFile(string content);
    string GetContactsFromFile();
}
