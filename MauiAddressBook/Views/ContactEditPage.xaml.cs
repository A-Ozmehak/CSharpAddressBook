using MauiAddressBook.ViewModels;

namespace MauiAddressBook.Views;

public partial class ContactEditPage : ContentPage
{
	public ContactEditPage(ContactEditViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}