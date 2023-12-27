using System.Diagnostics;

namespace Shared.Services;

public class FileService
{
    /// <summary>
    /// Opens and reads the text in the file and deserializes it into a list of contacts
    /// </summary>
    /// <param name="filePath">The path where the file is</param>
    /// <returns>A list of contacts from the file</returns>
    public string GetContactsFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return string.Empty;

    }

    /// <summary>
    /// Writes the provided content to a file at the specified path
    /// </summary>
    /// <param name="filePath">The path where the file is to be written</param>
    /// <param name="content">The content to be written to the file</param>
    /// <returns>True if successful, false otherwise</returns>
    public bool SaveContactToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
