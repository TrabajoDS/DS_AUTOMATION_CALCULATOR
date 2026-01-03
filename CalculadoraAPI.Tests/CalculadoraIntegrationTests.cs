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
    [InlineData(0, 0, 0)]
    public async Task SumarEndpoint_DevuelveResultadoEsperado(int a, int b, int esperado)
    {
        var response = await _client.GetAsync($"/Calculadora/Sumar?a={a}&b={b}");
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(5, 3, 2)]
    [InlineData(0, 0, 0)]
    public async Task RestarEndpoint_DevuelveResultadoEsperado(int a, int b, int esperado)
    {
        var response = await _client.GetAsync($"/Calculadora/Restar?a={a}&b={b}");
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(4, 3, 12)]
    [InlineData(-2, 3, -6)]
    [InlineData(0, 5, 0)]
    public async Task MultiplicarEndpoint_DevuelveResultadoEsperado(int a, int b, int esperado)
    {
        var response = await _client.GetAsync($"/Calculadora/Multiplicar?a={a}&b={b}");
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(esperado, resultado);
    }

    [Fact]
    public async Task DividirEndpoint_ConDivisionValida_DevuelveResultado()
    {
        var response = await _client.GetAsync("/Calculadora/Dividir?a=10&b=2");
        response.EnsureSuccessStatusCode();

        var resultado = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(5, resultado);
    }

    [Fact]
    public async Task DividirEndpoint_ConDivisionPorCero_DevuelveBadRequest()
    {
        var response = await _client.GetAsync("/Calculadora/Dividir?a=10&b=0");
        var response = await _client.GetAsync("/Calculadora/Dividir?a=10&b=0");
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }



}
