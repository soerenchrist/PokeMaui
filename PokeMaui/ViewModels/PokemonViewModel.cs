using PokeMaui.Util;

namespace PokeMaui.ViewModels;

public class PokemonViewModel : ViewModelBase
{
    private readonly Pokemon pokemon;

    public string Name => this.pokemon.Name.Capitalize();
    public string MainType => this.pokemon.Types.FirstOrDefault()?.Type.Name.Capitalize() ?? "";
    public string? Front => this.pokemon.Sprites.FrontDefault;
    public string? Back => this.pokemon.Sprites.BackDefault;

    public PokemonViewModel(Pokemon pokemon)
    {
        this.pokemon = pokemon;
    }
}
