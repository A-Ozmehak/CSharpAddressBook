using MauiAddressBook.ViewModels;

namespace MauiAddressBook.Views;

public partial class ContactAddPage : ContentPage
{
	public ContactAddPage(ContactAddViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}