using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.Models;

namespace InvestmentCalculator.Domain.Entities.Cdb
{
    public class Cdb :  IInvestimento
    {
        private const decimal Cdi = 0.009m;
        private const decimal Tb = 1.08m;
        private const bool imposto = true;
        private decimal _valorFinalBruto { get; set; } = 00m;
        private decimal _imposto { get; set; } = 0;

        private decimal _valorInicial { get; set; } = 0m;
        private int _meses { get; set; } = 0;
       
        public IInvestimento Create(decimal valorInicial, int meses)
        {
            if (valorInicial <= 0)
                throw new ArgumentException("O valor inicial deve ser maior que zero.");

            if (meses <= 1)
                throw new ArgumentException("O período deve ser maior que 1.");


            var @investiment = new Cdb()
            {
                _valorInicial = Math.Round(valorInicial, 2, MidpointRounding.AwayFromZero),
                _meses = meses,
            };
            
            return @investiment;
        }

        public bool CalculaImposto => imposto;

        public async Task<decimal> CalcularValorFinal()
        {
            _valorFinalBruto = _valorInicial;

            for (int i = 0; i < _meses; i++)
            {
                _valorFinalBruto *= 1 + Cdi * Tb;
            }
            await Task.Delay(0);

            _valorFinalBruto = Math.Round(_valorFinalBruto, 2, MidpointRounding.AwayFromZero);

            return _valorFinalBruto;
        }

        private async Task<decimal> TaxaImposto()
        {
            decimal _taxaImposto = 0m;

            if (_meses <= 6)
                _taxaImposto = 22.5m;
            else if (_meses <= 12)
                _taxaImposto = 20.0m;
            else if (_meses <= 24)
                _taxaImposto = 17.5m;
            else
                _taxaImposto = 15.0m;

            await Task.Delay(0);

            return _taxaImposto;
        }

        public async Task<decimal> CalcularImposto()
        {
            var _taxaImposto = await TaxaImposto();

            decimal desconto = _taxaImposto / 100 * (_valorFinalBruto - _valorInicial);

            _imposto = Math.Round(desconto, 2, MidpointRounding.AwayFromZero);

            return _imposto;
        }

        public async Task<decimal> CalcularLiquido()
        {
            var _valorFinalLiquido = _valorFinalBruto - _imposto;

            await Task.Delay(0);

            return _valorFinalLiquido;
        }      
    }
}