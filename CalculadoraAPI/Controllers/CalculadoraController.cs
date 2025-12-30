using Microsoft.AspNetCore.Mvc;

namespace CalculadoraAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculadoraController : ControllerBase
{
    [HttpGet("Sumar")]
    public ActionResult<int> Sumar(int a, int b)
    {
        return a + b;
    }
}
