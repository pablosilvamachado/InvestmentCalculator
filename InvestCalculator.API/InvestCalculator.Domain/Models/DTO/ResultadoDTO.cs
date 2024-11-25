using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentCalculator.Domain.Models.DTO
{
    public class ResultadoDto
    {
        public decimal ValorFinalBruto { get; set; }
        public decimal Imposto { get; set; }
        public decimal ValorFinalLiquido { get; set; }
        public byte Status { get; set; } = 0;
        public string Error { get; set; } = string.Empty;
    }
}
