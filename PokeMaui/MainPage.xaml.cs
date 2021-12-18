using Microsoft.Maui.Controls;
using PokeMaui.ViewModels;

namespace PokeMaui
{
    public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}
