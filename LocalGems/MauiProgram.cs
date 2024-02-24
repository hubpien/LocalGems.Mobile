using CommunityToolkit.Maui;
using LocalGems.Services;
using LocalGems.View;
using LocalGems.ViewModels;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace LocalGems
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<AuthService>();
            builder.Services.AddSingleton<LoginPage, LoginPageViewModel>();
            builder.Services.AddSingleton<LoadingPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<ProfilPage>();
            builder.Services.AddTransient<ProfilViewModel>();

            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<DetailsViewModel>();

            builder.Services.AddTransient<ExplorePage>();
            builder.Services.AddTransient<ExploreViewModel>();
            
            builder.Services.AddTransient<FavoritesPage, FavoritesViewModel>();

            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();


            return builder.Build();
        }
    }
}
