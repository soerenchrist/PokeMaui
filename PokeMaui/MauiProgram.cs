using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using PokeMaui.Pages.Main;
using Microsoft.Maui.Controls;

namespace PokeMaui
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
				});

			const string baseUrl = "https://pokeapi.co/api/v2/";

			builder
				.Services
				.AddRefitClient<IPokemonApi>()
				.ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainPageViewModel>();

			return builder.Build();
		}
	}
}