using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using RestSharp;
using Microsoft.Extensions.DependencyInjection;
using PokeMaui.Services;
using PokeMaui.ViewModels;

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
			var restClient = new RestClient(baseUrl);
			builder.Services.AddSingleton<IRestClient>(restClient);
			builder.Services.AddSingleton<IPokemonApi, PokemonApi>();

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainPageViewModel>();

			return builder.Build();
		}
	}
}