using Refit;

namespace PokeMaui.Services.Interfaces;

public interface IPokemonApi
{
    [Get("/pokemon/{name}")]
    Task<PokemonHeader> GetPokemonByName(string name);

    [Get("/pokemon?limit={limit}&offset={offset}")]
    Task<PaginatedList<PokemonHeader>> GetPokemons(int limit, int offset);
}
