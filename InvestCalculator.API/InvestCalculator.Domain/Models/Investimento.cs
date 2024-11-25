using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Investimento(decimal valorInicial, int meses, decimal aporteMensal)
        {
            _valorInicial = valorInicial;
            _meses = meses;
            _aporteMensal = aporteMensal;
        }
    }
}
