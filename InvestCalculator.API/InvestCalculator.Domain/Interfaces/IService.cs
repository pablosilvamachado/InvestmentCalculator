using InvestmentCalculator.Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Domain.Interfaces
{
    public interface IService
    {
        Task<ResultadoDto> Calcular(decimal valorInicial, int meses);

    }
}
