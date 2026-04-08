using System.Text.Json.Serialization;

namespace ConsumoApi.Models;

public class Movie
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Titulo { get; set; } = string.Empty;

    [JsonPropertyName("overview")]
    public string Sinopse { get; set; } = string.Empty;

    [JsonPropertyName("release_date")]
    public string DataLancamento { get; set; } = string.Empty;

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = string.Empty;

    [JsonPropertyName("vote_average")]
    public double Nota { get; set; }


    public string FullPosterUrl => $"https://image.tmdb.org/t/p/w500{PosterPath}";
}