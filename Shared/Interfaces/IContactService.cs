namespace Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// Add a contact
    /// </summary>
    /// <param name="contact">The contact to be added</param>
    /// <returns>True if the contact was added successfully, false otherwise</returns>
    bool AddContact(IContact contact);

    /// <summary>
    /// Remove a contact
    /// </summary>
    /// <param name="email">Removes a contact by email</param>
    /// <returns>The contact if found, null otherwise</returns>
    bool RemoveContactByEmail(string email);

    /// <summary>
    /// Get one contact 
    /// </summary>
    /// <param name="FirstName">Find a contact by entering a firstname</param>
    /// <returns>Shows the contact information otherwise null</returns>
    IContact GetSingleContact(string FirstName);

    /// <summary>
    /// Get all contacts
    /// </summary>
    /// <returns>Show all contacts otherwise null</returns>
    IEnumerable<IContact> GetAllContacts();
}
