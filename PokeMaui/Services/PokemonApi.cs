using RestSharp;

namespace PokeMaui.Services;

public class PokemonApi : IPokemonApi
{
    private readonly IRestClient restClient;

    public PokemonApi(IRestClient restClient)
    {
        this.restClient = restClient;
    }

    public async Task<Pokemon> GetPokemonByName(string name)
    {
        var request = new RestRequest($"pokemon/{name}");
        var response = await this.restClient.ExecuteAsync<Pokemon>(request);

        return response.Data;
    }
}
