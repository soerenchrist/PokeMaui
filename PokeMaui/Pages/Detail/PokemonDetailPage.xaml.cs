using Microsoft.Maui.Controls;
using PokeMaui.ViewModels;
using System.Collections;

namespace PokeMaui.Pages.Main;

public partial class PokemonDetailPage : ContentPage
{
    private readonly PokemonViewModel viewModel;

    public PokemonDetailPage(PokemonViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
		BindingContext = viewModel;
	}
}

