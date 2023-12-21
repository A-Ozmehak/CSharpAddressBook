using MAUIAddressBook.Pages;
using MAUIAddressBook.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUIAddressBook
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ContactAddPage>();
            builder.Services.AddSingleton<ContactListPage>();
            builder.Services.AddSingleton<ContactListViewModel>();
            builder.Services.AddSingleton<ContactAddViewModel>();

            return builder.Build();
        }
    }
}
