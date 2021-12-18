using DynamicData;
using MvvmHelpers.Commands;
using PokeMaui.ViewModels;
using System.Collections.ObjectModel;

namespace PokeMaui.Pages.Main;

public class MainPageViewModel : ViewModelBase
{
    private SourceCache<PokemonHeader, string> pokemonsCache = new(x => x.Name);
    private readonly ReadOnlyObservableCollection<PokemonHeaderViewModel> pokemons;
    public ReadOnlyObservableCollection<PokemonHeaderViewModel> Pokemons => pokemons;

    public AsyncCommand Search { get; }

    private bool hasMore = true;
    private int offset = 0;
    private const int pageSize = 20;

    private readonly IPokemonApi api;

    public MainPageViewModel(IPokemonApi api)
    {
        Search = new AsyncCommand(ExecuteSearch);
        this.api = api;
        this.pokemonsCache
            .Connect()
            .Transform(x => new PokemonHeaderViewModel(x))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out this.pokemons)
            .Subscribe();
    }

    private async Task ExecuteSearch()
    {
        if (!this.hasMore)
            return;

        var paginatedList = await this.api.GetPokemons(pageSize, this.offset);
        this.hasMore = paginatedList.Next != null;
        this.offset += pageSize;

        this.pokemonsCache.AddOrUpdate(paginatedList.Results );
    }
}