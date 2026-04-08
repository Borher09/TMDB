using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ConsumoApi.Models;

namespace ConsumoApi.Controllers;

public class PokemonController : Controller
{
    private readonly HttpClient _httpClient;

    public PokemonController()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://pokeapi.co/api/v2/")
        };
    }

    public async Task<IActionResult> Index()
    {
        // Vamos buscar as informações do Pikachu como exemplo principal
        var pikachu = await GetPokemonAsync("pikachu");
        var charmander = await GetPokemonAsync("charmander");
        var squirtle = await GetPokemonAsync("squirtle");
        var bulbasaur = await GetPokemonAsync("bulbasaur");

        var pokemons = new List<Pokemon> { pikachu, charmander, squirtle, bulbasaur };
        
        return View(pokemons);
    }

    private async Task<Pokemon> GetPokemonAsync(string name)
    {
        var response = await _httpClient.GetAsync($"pokemon/{name}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pokemon>(content);
        }
        return null;
    }
}
