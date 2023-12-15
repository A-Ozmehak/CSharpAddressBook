using MAUIAddressBook.ViewModels;

namespace MAUIAddressBook.Pages;

public partial class ContactListPage : ContentPage
{
	public ContactListPage(ContactListViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}