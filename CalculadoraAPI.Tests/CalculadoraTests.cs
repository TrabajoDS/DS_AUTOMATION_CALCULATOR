using Xunit;
using CalculadoraAPI.Controllers;

namespace CalculadoraAPI.Tests;

public class CalculadoraTests
{
    // SUMAR
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

    [Fact]
    public void Sumar_CeroYNumero_ReturnsNumero()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Sumar(0, 7);

        Assert.Equal(7, resultado.Value);
    }

    [Fact]
    public void Sumar_NumerosGrandes_ReturnsSumaCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Sumar(1000000, 2000000);

        Assert.Equal(3000000, resultado.Value);
    }

    [Fact]
    public void Sumar_NumerosMixtos_ReturnsSumaCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Sumar(-5, 10);

        Assert.Equal(5, resultado.Value);
    }


    // RESTAR
    [Fact]
    public void Restar_DosNumeros_ReturnsRestaCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Restar(5, 3);

        Assert.Equal(2, resultado.Value);
    }

    [Fact]
    public void Restar_ResultadoNegativo_ReturnsCorrecto()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Restar(2, 5);

        Assert.Equal(-3, resultado.Value);
    }

    [Fact]
    public void Restar_ConCero_ReturnsMismoNumero()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Restar(4, 0);

        Assert.Equal(4, resultado.Value);
    }

    [Fact]
    public void Restar_NumerosGrandes_ReturnsRestaCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Restar(5000000, 2000000);

        Assert.Equal(3000000, resultado.Value);
    }

    [Fact]
    public void Restar_NumerosMixtos_ReturnsRestaCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Restar(-5, -10);
        
        Assert.Equal(5, resultado.Value);
    }

    // MULTIPLICAR
    [Fact]
    public void Multiplicar_DosNumeros_ReturnsMultiplicacionCorrecta()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Multiplicar(3, 4);

        Assert.Equal(12, resultado.Value);
    }

    [Fact]
    public void Multiplicar_PorCero_ReturnsCero()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Multiplicar(7, 0);

        Assert.Equal(0, resultado.Value);
    }

    [Fact]
    public void Multiplicar_NumerosNegativos_ReturnsPositivo()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Multiplicar(-3, -4);

        Assert.Equal(12, resultado.Value);
    }

    [Fact]
    public void Multiplicar_NegativoYPositivo_ReturnsNegativo()
    {
        var controlador = new CalculadoraController();

        var resultado = controlador.Multiplicar(-3, 4);
        
        Assert.Equal(-12, resultado.Value);
    }

}
