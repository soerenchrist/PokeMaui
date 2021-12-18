namespace PokeMaui.Models;

public record Pokemon(int Id, bool IsDefault, Sprites Sprites, List<PokemonTypeAssignment> Types, string Name,  int BaseExperience, int Height, int weight);
