using Refit;
using Refit.Insane.PowerPack.Caching;

namespace PokeMaui.Services.Interfaces;

public interface IPokemonApi
{
    [Get("/pokemon/{name}")]
    Task<Pokemon> GetPokemonByName([RefitCachePrimaryKey] string name);

    [Get("/pokemon/{id}")]
    Task<Pokemon> GetPokemon([RefitCachePrimaryKey] int id);

    [Get("/pokemon?limit={limit}&offset={offset}")]
    Task<PaginatedList<PokemonResource>> GetPokemons(int limit, int offset);
}
