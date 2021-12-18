namespace PokeMaui.Models;

public record PaginatedList<T>(int Count, string? Next, string? Previous, List<T> Results);
