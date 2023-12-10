namespace Shared.Interfaces;

internal interface IFileService
{
    /// <summary>
    /// Save content to a specificed filepath.
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg.c.\projects\myfile.json)</param>
    /// <param name="content">enter your content as a string</param>
    /// <returns>returns true if saved, else false if failed</returns>
    bool SaveContactToFile(string filePath, string content);

    /// <summary>
    /// Get content as string from a specified filepath
    /// </summary>
    /// <param name="filePath">enter the filepath witrh extension (eg.c.\projects\myfile.json)</param>
    /// <returns>returns file content as string if file exists, else returns null</returns>
    string GetContactsFromFile(string filePath);
}
