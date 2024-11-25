
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models.DTO;


namespace InvestmentCalculator.Application
{
    public class InvestmentCalculatorService : IService
    {
        private readonly IManager _manager;

        public InvestmentCalculatorService(IManager InvestmentCalculatorManager)
        {
            _manager = InvestmentCalculatorManager;
        }

        public async Task<ResultadoDto> Calcular(decimal valorInicial, int meses)
        {
            try
            {
                if (valorInicial <= 0)
                    throw new ArgumentException("O valor inicial deve ser maior que zero.");

                if (meses <= 1)
                    throw new ArgumentException("O período deve ser maior que 1.");

                var resultado = await _manager.Calcular(valorInicial, meses);

                return resultado;

            }
            catch (Exception ex)
            {
                return new ResultadoDto
                {
                    ValorFinalBruto = 0,
                    Imposto = 0,
                    ValorFinalLiquido = 0,
                    Status = 1,
                    Error = ex.Message
                };
            }
        }
    }
}
