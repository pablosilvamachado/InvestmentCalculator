using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models;
using InvestmentCalculator.Domain.Models.DTO;


namespace InvestmentCalculator.Domain.Entities.Cdb
{
    public class CdbManager : IManager
    {
        private readonly ICalculatorEngine _engine;

        public CdbManager(ICalculatorEngine engine)
        {
            _engine = engine;
        }

        public async Task<ResultadoDto> Calcular(decimal valorInicial, int meses)
        {
            var entity = await _engine.Calcular(valorInicial, meses);
            return entity;
        }
    }
}
