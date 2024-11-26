using InvestmentCalculator.Domain.Entities.Cdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Domain.Interfaces
{
    public interface IInvestimento
    {
        bool CalculaImposto { get; }

        IInvestimento Create(decimal valorInicial, int meses);       

        Task<decimal> CalcularValorFinal();

        Task<decimal> CalcularImposto();

        Task<decimal> CalcularLiquido();
    }
}
