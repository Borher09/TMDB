using System.Text.Json.Serialization;

namespace ConsumoApi.Models;

public class MovieResponse
{
    [JsonPropertyName("results")]
    public List<Movie> Filmes { get; set; } = new();
}
