using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;
using System.Collections.ObjectModel;

namespace MauiAddressBook.ViewModels
{
    public partial class ContactAddViewModel : ObservableObject
    {
        private readonly ContactService _contactService;

        public ContactAddViewModel(ContactService contactService)
        {
            _contactService = contactService;

            foreach (Shared.Models.Contact contact in _contactService.GetContacts())
            {
                ContactList.Add(contact);
            }
        }

        [ObservableProperty]
        private Shared.Models.Contact _addContactForm = new();

        [ObservableProperty]
        private ObservableCollection<Shared.Models.Contact> _contactList = [];

        /// <summary>
        /// Asynchronously adds a new contact to the contact list if the contact form is valid.
        /// </summary>
        [RelayCommand]
        private async Task AddContact()
        {
            if (AddContactForm != null && !string.IsNullOrWhiteSpace(AddContactForm.FirstName) && !string.IsNullOrWhiteSpace(AddContactForm.LastName))
            {
                var result = _contactService.AddContactToList(AddContactForm);
                if (result)
                {
                    AddContactForm = new();
                    await Shell.Current.GoToAsync("..");
                }
            }
        }
    }
}
