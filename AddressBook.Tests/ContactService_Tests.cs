using System.ComponentModel.DataAnnotations;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using Moq;
using Castle.Core.Resource;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AddressBook.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactShould_AddOneContactToContactsList_ThenReturnTrue()
    {
        // Arrange
        IContact contact = new Contact { FirstName = "Anna", LastName = "Ozmehak", Email = "anna.ozmehak@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", ZipCode = "41724", City = "Goteborg" };

        var mockData = new Mock<IFileService>();
        IContactService contactService = new ContactService(mockData.Object);

        // Act
        bool result = contactService.AddContact(contact);

        // Assert
        Assert.True(result);
    }

    /*[Fact]
    public void RemoveContactByEmailShould_RemoveAContactFromContactsList_ThenReturnTrue()
    {
        // Arrange
        var contacts = new List<IContact>
        {
            new Contact { FirstName = "Anna", LastName = "Ozmehak", Email = "anna.ozmehak@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", ZipCode = "41724", City = "Goteborg" },
            new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", City = "Goteborg", ZipCode = "41724" }
        };

        string json = JsonConvert.SerializeObject(contacts, Formatting.None,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContactsFromFile(It.IsAny<string>())).Returns(json);

        IContactService contactService = new ContactService(mockFileService.Object);

        // Act
        var result = contactService.RemoveContactByEmail("anna.ozmehak@gmail.com");

        // Assert
        Assert.True(result);
        //Assert.True(!result);

    }*/

    [Fact]
    public void GetSingleContactShould_GetAContactFromContactsList_ThenReturnListOfContacts()
    {
        // Arrange
        var contacts = new List<IContact>
        {
            new Contact { FirstName = "Anna", LastName = "Ozmehak", Email = "anna.ozmehak@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", ZipCode = "41724", City = "Goteborg" },
            new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", City = "Goteborg", ZipCode = "41724" }
        };

        string json = JsonConvert.SerializeObject(contacts, Formatting.None,
              new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContactsFromFile(It.IsAny<string>())).Returns(json);

        IContactService contactService = new ContactService(mockFileService.Object);

        // Act
        var result = contactService.GetSingleContact("Anna");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Anna", result.FirstName);
    }

    [Fact]
    public void GetAllContactsShould_GetAllContactFromContactsList_ThenReturnListOfContacts()
    {
        // Arrange
        var contacts = new List<IContact> { new Contact { FirstName = "Anna", LastName = "Ozmehak", Email = "anna.ozmehak@gmail.com", PhoneNumber = 0793555635, Address = "Gustaf dalensgatan 24", City = "Goteborg", ZipCode = "41724" } };
        string json = JsonConvert.SerializeObject(contacts, Formatting.None,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContactsFromFile(It.IsAny<string>())).Returns(json);

        IContactService contactService = new ContactService(mockFileService.Object);

        // Act
        IEnumerable<IContact> result = contactService.GetAllContacts();

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}
