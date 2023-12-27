using Shared.Models;
using Shared.Services;
using Moq;

namespace MauiAddressBook_Tests;

public class ContactService_Tests
{

    [Fact]
    public void AddContactShould_AddOneContactToContactsList_ThenReturnTrue()
    {
        // Arrange
        Contact contact = new Contact { FirstName = "Anna", LastName = "Ozmehak", Email = "anna.ozmehak@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", ZipCode = "41724", City = "Goteborg" };

        var mockData = new Mock<FileService>();
        ContactService contactService = new ContactService(mockData.Object);

        // Act
        bool result = contactService.AddContactToList(contact);

        // Assert
        Assert.True(result);
    }
}
