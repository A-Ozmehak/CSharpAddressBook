namespace Shared.Interfaces;

public interface IContact
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string Email { get; set; }
    int PhoneNumber { get; set; }
    string Address { get; set; }
    string City { get; set; }
    string ZipCode { get; set; }
}
