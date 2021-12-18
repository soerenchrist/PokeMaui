using System.Windows.Input;

namespace PokeMaui.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    private string name = "Ditto";
    public string Name
    {
        get => this.name;
        set => SetProperty(ref this.name, value);
    }

    private ICommand? search;
    private readonly IPokemonApi api;

    public ICommand Search => this.search ??= new DelegateCommand(ExecuteSearch);

    public MainPageViewModel(IPokemonApi api)
    {
        this.api = api;
    }

    private async void ExecuteSearch()
    {
        var pokemon = await this.api.GetPokemonByName(this.Name);
        
    }
}
