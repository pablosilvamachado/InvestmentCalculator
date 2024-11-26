using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Domain.Models
{
    public interface IInvestimento
    {
        Task<decimal> CalcularValorFinal();

        Task<decimal> CalcularImposto();

        Task<decimal> CalcularLiquido();
    } 
}
