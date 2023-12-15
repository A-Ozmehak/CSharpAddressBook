using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;
using System.Collections.ObjectModel;

namespace MAUIAddressBook.ViewModels;

public partial class ContactAddViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public ContactAddViewModel(ContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();
    }


    [ObservableProperty]
    private Shared.Models.Contact _addContactForm = new();

    [ObservableProperty]
    private ObservableCollection<Shared.Models.Contact> _contacts = [];

    [RelayCommand]
    public void AddContactToList()
    {
        if (AddContactForm != null)
        {
            var result = _contactService.AddContact(AddContactForm);
            if (result)
            {
                UpdateContactList();
                AddContactForm = new();
            }
        }
    }

    [RelayCommand]
    public void RemoveContactFromList(Shared.Models.Contact contact)
    {
        if (contact != null)
        {
            var result = _contactService.RemoveContactByEmail(contact.Email);
            if (result)
            {
                UpdateContactList();
            }
        }
    }

    public void UpdateContactList()
    {
        Contacts = new ObservableCollection<Shared.Models.Contact>((IEnumerable<Shared.Models.Contact>)_contactService.Contacts.Select(contact => contact).ToList());
    }


    [RelayCommand]
    private async Task NavigateToContactList()
    {
        await Shell.Current.GoToAsync("ContactListPage");
    }
}
