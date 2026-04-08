using ConsumoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configuração do HttpClient com Injeção de Dependência
builder.Services.AddHttpClient("TmdbClient", client =>
{
    var settings = builder.Configuration.GetSection("TmdbSettings").Get<TmdbSettings>();
    client.BaseAddress = new Uri(settings?.BaseUrl ?? "");
    client.DefaultRequestHeaders.Authorization = 
        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", settings?.BearerToken);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movies}/{action=Index}/{id?}");

app.Run();