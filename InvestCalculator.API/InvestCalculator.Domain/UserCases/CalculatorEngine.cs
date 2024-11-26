
using InvestmentCalculator.Domain.Entities.Cdb;
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models.DTO;

namespace InvestmentCalculator.Domain.UserCases
{
    public class CalculatorEngine : ICalculatorEngine
    {
        private readonly IInvestimento _Investimento;

       
        public CalculatorEngine(IInvestimento investimento)
        {
            _Investimento = investimento;
        }

        public async Task<ResultadoDto> Calcular(decimal valorInicial, int meses)
        {
            decimal ValorImposto = 00m;

            var entity = _Investimento.Create(valorInicial, meses);

            var ValorFinal = await entity.CalcularValorFinal();

            if (entity.CalculaImposto)
            {
                 ValorImposto = await entity.CalcularImposto();
            }

            var liquido = await entity.CalcularLiquido();

            return new ResultadoDto
            {
                ValorFinalBruto = ValorFinal,
                Imposto = ValorImposto,
                ValorFinalLiquido = liquido
            };
        }    
    }
}
