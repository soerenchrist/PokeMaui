namespace PokeMaui.Services.Interfaces;

public interface IPokemonApi
{
    Task<Pokemon> GetPokemonByName(string name);
}
