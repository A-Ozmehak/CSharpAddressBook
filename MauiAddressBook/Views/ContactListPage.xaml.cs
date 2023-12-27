using MauiAddressBook.ViewModels;

namespace MauiAddressBook.Views;

public partial class ContactListPage : ContentPage
{
    private readonly ContactListViewModel _viewModel;
    public ContactListPage(ContactListViewModel viewModel)
	{
		InitializeComponent();
        _viewModel = viewModel;
		BindingContext = viewModel;

        FirstNameEntry.TextChanged += FirstNameEntry_TextChanged;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _viewModel.LoadContacts();
    }

    private void FirstNameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string firstName = e.NewTextValue;
        _viewModel.UpdateContactList(firstName);
    }
}