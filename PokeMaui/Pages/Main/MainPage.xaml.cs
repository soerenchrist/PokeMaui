using Microsoft.Maui.Controls;
using System.Collections;

namespace PokeMaui.Pages.Main;

public partial class MainPage : ContentPage
{
    private readonly MainPageViewModel viewModel;

    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _ = this.viewModel.Search.ExecuteAsync();
    }
    private void CollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        if (Device.RuntimePlatform != Device.UWP)
        {
            return;
        }

        if (sender is CollectionView cv)
        {
            var count = ((ICollection)cv.ItemsSource).Count;
            if (e.LastVisibleItemIndex + 1 - count + cv.RemainingItemsThreshold >= 0)
            {
                if (cv.RemainingItemsThresholdReachedCommand.CanExecute(null))
                    cv.RemainingItemsThresholdReachedCommand.Execute(null);
            }
        }
    }
}

