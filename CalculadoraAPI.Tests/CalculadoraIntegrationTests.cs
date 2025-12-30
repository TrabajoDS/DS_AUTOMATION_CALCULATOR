using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CalculadoraAPI.Tests;

public class CalculadoraIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculadoraIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Theory]
    [InlineData(2, 3, 5)]
    [InlineData(-4, 1, -3)]
    public async Task SumarEndpoint_DevuelveResultadoEsperado(int a, int b, int esperado)
    {
        var response = await _client.GetAsync($"/Calculadora/Sumar?a={a}&b={b}");
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(esperado, resultado);
    }

}
