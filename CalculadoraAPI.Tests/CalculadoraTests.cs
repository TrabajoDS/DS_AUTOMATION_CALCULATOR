using Xunit;
using CalculadoraAPI.Controllers;

namespace CalculadoraAPI.Tests;

public class CalculadoraTests
{
    [Fact]
    public void Sumar_DosNumeros_ReturnsSumaCorrecta()
    {       
        var controlador = new CalculadoraController();
        
        var resultado = controlador.Sumar(2, 3);

        Assert.Equal(5, resultado.Value);
    }

    [Fact]
    public void Sumar_Negativos_ReturnsResultadoCorrecto()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Sumar(-2, -3);

        Assert.Equal(-5, resultado.Value);
    }
}
