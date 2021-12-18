using DynamicData;
using MvvmHelpers.Commands;
using PokeMaui.ViewModels;
using System.Collections.ObjectModel;

namespace PokeMaui.Pages.Main;

public class MainPageViewModel : ViewModelBase
{
    private SourceCache<Pokemon, string> pokemonsCache = new(x => x.Name);
    private readonly ReadOnlyObservableCollection<PokemonViewModel> pokemons;
    public ReadOnlyObservableCollection<PokemonViewModel> Pokemons => pokemons;

    private bool isLoading = false;
    public bool IsLoading
    {
        get => isLoading;
        private set => this.RaiseAndSetIfChanged(ref isLoading, value);
    }

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
            .Transform(x => new PokemonViewModel(x))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out this.pokemons)
            .Subscribe();

    }

    private Task ExecuteSearch()
    {
        return Task.Run(async () =>
        {
            if (!this.hasMore || IsLoading)
                return;
            IsLoading = true;
            var paginatedList = await this.api.GetPokemons(pageSize, this.offset);
            this.hasMore = paginatedList.Next != null;
            this.offset += pageSize;

            var tasks = new Task<Pokemon>[paginatedList.Results.Count];
            for (int i = 0; i < paginatedList.Results.Count; i++)
            {
                tasks[i] = this.api.GetPokemonByName(paginatedList.Results[i].Name);
            }

            var pokemons = await Task.WhenAll(tasks);

            this.pokemonsCache.AddOrUpdate(pokemons);
            IsLoading = false;
        });
    }
}