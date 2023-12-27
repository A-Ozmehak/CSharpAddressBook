using Shared.Services;

namespace AddressBook.Tests;

public class FileService_Tests
{
    [Fact]
    public void SaveContactToFileShould_SaveAContactToTheFile_ThenReturnTrue()
    {
        // Arrange
        FileService fileService = new FileService();
        string filePath = @"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContactToFile(filePath, content);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContactsFromFileShould_ReturnTrue_IfTheFileExists()
    {
        // Arrange
        FileService fileService = new FileService();
        string filePath = @"C:\Users\Anna\Documents\Repos\CSharp\CSharpAddressBook\addressBookContacts.json";
        string content = "Test content";

        // Act
        bool result = fileService.SaveContactToFile(filePath, content);

        // Assert
        Assert.True(result);
    }
}
