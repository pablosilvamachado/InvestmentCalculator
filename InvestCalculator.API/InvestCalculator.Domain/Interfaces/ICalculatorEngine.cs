using InvestmentCalculator.Domain.Models;
using InvestmentCalculator.Domain.Models.DTO;


namespace InvestmentCalculator.Domain.Interfaces
{
    public interface ICalculatorEngine
    {
        Task<ResultadoDto> Calcular(decimal valorInicial, int meses);
    }
}

