using MAUIAddressBook.ViewModels;

namespace MAUIAddressBook.Pages;

public partial class ContactAddPage : ContentPage
{
	public ContactAddPage(ContactAddViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}