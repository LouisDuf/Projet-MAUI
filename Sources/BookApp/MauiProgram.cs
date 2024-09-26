using BookApp.Composants;
using BookApp.Pages;
using BookApp.ViewModel;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Model;
using SimpleRatingControlMaui;
using StubLib;
using VMWrapper;

namespace BookApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseSimpleRatingControl()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ILibraryManager, LibraryStub>();
            builder.Services.AddSingleton<IUserLibraryManager, UserLibraryStub>();
            builder.Services.AddSingleton<BooksViewModel>();
            builder.Services.AddSingleton<FilterViewModel>();
            builder.Services.AddSingleton<DetailBookViewModel>();
            builder.Services.AddSingleton<ViewModelDetailProvider>();

            builder.Services.AddSingleton<ViewModelNavigation>();
            builder.Services.AddSingleton<ViewModelMenu>();

            builder.Services.AddSingleton<DetailBook>();
            builder.Services.AddSingleton<GroupCollection>();
            builder.Services.AddSingleton<CollectionFiltrage>();
            builder.Services.AddSingleton<Filtrage>();
            builder.Services.AddSingleton<Tous>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<EmpruntsPrets>();

            return builder.Build();
        }
    }
}
