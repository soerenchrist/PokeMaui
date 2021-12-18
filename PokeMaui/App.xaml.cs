using Microsoft.Maui.Controls;
using PokeMaui.Pages.Main;
using Application = Microsoft.Maui.Controls.Application;

namespace PokeMaui
{
    public partial class App : Application
	{
		public App(MainPage page)
		{
			InitializeComponent();

			var nav = new NavigationPage(page);
			MainPage = nav;
		}
	}
}
