using AddressBook.Interfaces;

namespace AddressBook.Models;

public class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int PhoneNumber { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string ZipCode { get; set; } = null!;

    public Contact(string firstName, string lastName, string email, int phoneNumber, string address, string city, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        City = city;
        ZipCode = zipCode;
    }
}
