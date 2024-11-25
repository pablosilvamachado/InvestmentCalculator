
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace InvestCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentCalculatorController : ControllerBase
    {
        private readonly IService _Service;

        public InvestmentCalculatorController(IService service)
        {
            _Service = service;
        }

        [HttpPost("calcular")]
        [ProducesResponseType(typeof(ResultadoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Calcular([FromBody] InvestmentDto valores)
        {
            try
            {
                if (valores.valorInicial <= 0)
                    throw new ArgumentException("O valor inicial deve ser maior que zero.");

                if (valores.meses <= 1)
                    throw new ArgumentException("O período deve ser maior que 1.");

                var resultado = await _Service.Calcular(valores.valorInicial, valores.meses);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                var result =  new ResultadoDto
                {
                    ValorFinalBruto = 0,
                    Imposto = 0,
                    ValorFinalLiquido = 0,
                    Status = 1,
                    Error = ex.Message
                };

                return  Ok(result);
            }
        }
    }
}
