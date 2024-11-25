using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Domain.Models.DTO
{
    public class InvestmentDto
    {
        public decimal valorInicial { get; set; }
        public int meses { get; set; } = 0;
    }
}
