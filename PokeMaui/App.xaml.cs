using Application = Microsoft.Maui.Controls.Application;

namespace PokeMaui
{
    public partial class App : Application
	{
		public App(MainPage page)
		{
			InitializeComponent();

			MainPage = page;
		}
	}
}
