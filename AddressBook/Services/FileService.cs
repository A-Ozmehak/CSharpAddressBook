using AddressBook.Interfaces;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace AddressBook.Services;

public class FileService(string filePath) : IFileService
{
    private readonly string _filePath = filePath; 

    // Checks if the file exists and then gets the contact from the file
    public string GetContactsFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    // Saves the contact to the file
    public bool SaveContactToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);

            }
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
