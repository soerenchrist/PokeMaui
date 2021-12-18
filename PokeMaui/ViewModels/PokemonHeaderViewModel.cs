using PokeMaui.Util;

namespace PokeMaui.ViewModels;

public class PokemonHeaderViewModel
{
    private readonly PokemonHeader pokemon;

    public string Name => this.pokemon.Name.Capitalize();

    public PokemonHeaderViewModel(PokemonHeader pokemon)
    {
        this.pokemon = pokemon;
    }
}
