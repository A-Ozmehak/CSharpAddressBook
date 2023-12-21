using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MAUIAddressBook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToAddContact()
    {
        await Shell.Current.GoToAsync("ContactAddPage");
    }
}
