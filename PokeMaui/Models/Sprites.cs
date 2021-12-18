using System.Text.Json.Serialization;

namespace PokeMaui.Models;

public class Sprites
{
    [JsonPropertyName("back_default")]
    public string? BackDefault { get; init; }
    [JsonPropertyName("back_female")]
    public string? BackFemale { get; init; }
    [JsonPropertyName("back_shiny")]
    public string? BackShiny { get; init; }
    [JsonPropertyName("front_default")]
    public string? FrontDefault { get; init; }
    [JsonPropertyName("front_female")]
    public string? FrontFemale { get; init; }
    [JsonPropertyName("front_shiny")]
    public string? FrontShiny { get; init; }
}