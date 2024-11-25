
using InvestmentCalculator.Domain.Entities.Cdb;
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models.DTO;

namespace InvestmentCalculator.Domain.UserCases
{
    public class CdbCalculatorEngine : ICalculatorEngine
    {
        public CdbCalculatorEngine()
        {
            
        }

        public async Task<ResultadoDto> Calcular(decimal valorInicial, int meses)
        {
            var entity = Cdb.Create(valorInicial, meses);

            var ValorFinal = await entity.CalcularValorFinal();
            var ValorImposto = await entity.CalcularImposto();
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
