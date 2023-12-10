namespace Shared.Interfaces;

public interface IContactService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    bool AddContact(IContact contact);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    bool RemoveContactByEmail(string email);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="FirstName"></param>
    /// <returns></returns>
    IContact GetSingleContact(string FirstName);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>

    IEnumerable<IContact> GetAllContacts();
}
