using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ConsumoApi.Models;

namespace ConsumoApi.Controllers;

public class MoviesController : Controller
{
    private readonly HttpClient _httpClient;

    public MoviesController(IHttpClientFactory httpClientFactory)
    {
     
        _httpClient = httpClientFactory.CreateClient("TmdbClient");
    }

    public async Task<IActionResult> Index()
    {
        try 
        {
            var response = await _httpClient.GetAsync("movie/popular?language=pt-BR&page=1");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonSerializer.Deserialize<MovieResponse>(content);
                return View(dados?.Filmes ?? new List<Movie>());
            }
            
            return View(new List<Movie>());
        }
        catch (Exception)
        {
          
            return View(new List<Movie>());
        }
    }
}