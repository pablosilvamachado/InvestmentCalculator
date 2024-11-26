

namespace InvestmentCalculator.Domain.Models
{
    public class Investimento
    {
        protected decimal _valorInicial { get; set; } = 0m;
        protected int _meses { get; set; } = 0;
        protected decimal _aporteMensal { get; set; } = 0m;


        public Investimento()
        {
            
        }

        public Investimento(decimal valorInicial, int meses)
        {
            _valorInicial = valorInicial;
            _meses = meses;
        }

        public Investimento(decimal valorInicial, int meses, decimal aporteMensal)
        {
            _valorInicial = valorInicial;
            _meses = meses;
            _aporteMensal = aporteMensal;
        }
    }
}
