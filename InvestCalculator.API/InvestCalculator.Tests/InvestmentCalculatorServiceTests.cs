

using InvestmentCalculator.Application;
using InvestmentCalculator.Domain.Entities.Cdb;
using InvestmentCalculator.Domain.Interfaces;
using InvestmentCalculator.Domain.UserCases;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using Xunit;

namespace CdbCalculator.Tests
{
    public class InvestmentCalculatorServiceTests
    {

        private readonly IService? _service = null;


        public InvestmentCalculatorServiceTests()
        {
            var service = new ServiceCollection();

            service.AddScoped<ICalculatorEngine, CalculatorEngine>();
            service.AddScoped<IManager, CdbManager>();
            service.AddScoped<IService, InvestmentCalculatorService>();
            service.AddScoped<IInvestimento, Cdb>();

            var provider = service.BuildServiceProvider();
           
            _service = provider.GetService<IService?>();
        }

        [Fact]
        public async Task  CalcularCdb_ValoresInicialInvalidos()
        {
            // Arrange

            decimal valorInicial = 0.00m;
            int meses = 1;

            // Act
            var resultado =await  _service.Calcular(valorInicial, meses);

            // Assert
            Assert.True(resultado.Status == 1);
            Assert.True(resultado.Error ==  "O valor inicial deve ser maior que zero.");
        }

        [Fact]
        public async Task CalcularCdb_ValoresPeriodoInvalidos()
        {
            // Arrange

            decimal valorInicial = 1000m;
            int meses = 1;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);

            // Assert
            Assert.True(resultado.Status == 1);
            Assert.True(resultado.Error == "O período deve ser maior que 1.");
        }


        [Fact]
        public async Task CalcularCdb_DeveRetornarValorFinalCorreto()
        {
            // Arrange
           
            decimal valorInicial = 1000m;
            int meses = 12;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);

            // Assert
            Assert.True(resultado.ValorFinalBruto > valorInicial);          
            Assert.Equal(Math.Round(resultado.ValorFinalBruto - resultado.ValorFinalLiquido, 1, MidpointRounding.ToEven), Math.Round(resultado.Imposto, 1, MidpointRounding.ToEven));
           
        }

        [Fact]
        public async Task CalcularCdb_DeveVerificarOvalorImpostoEmPorcentagemAteSeisMeses()
        {
          
            // Arrange
            decimal valorInicial = 1000m;
            int meses = 5;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);
            Assert.Equal(22.5m, Math.Round(resultado.Imposto / (resultado.ValorFinalBruto - valorInicial) * 100, 1, MidpointRounding.ToEven));

        }

        [Fact]
        public async Task CalcularCdb_DeveVerificarOvalorImpostoEmPorcentagemAteDozeMeses()
        {

            // Arrange
            decimal valorInicial = 1000m;
            int meses = 11;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);
            Assert.Equal(20.0m, Math.Round(resultado.Imposto / (resultado.ValorFinalBruto - valorInicial) * 100, 1, MidpointRounding.ToEven));


        }

        [Fact]
        public async Task CalcularCdb_DeveVerificarOvalorImpostoEmPorcentagemAteVinteQuatroMeses()
        {

            // Arrange
            decimal valorInicial = 1000m;
            int meses = 23;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);
            Assert.Equal(17.5m, Math.Round(resultado.Imposto / (resultado.ValorFinalBruto - valorInicial) * 100, 1, MidpointRounding.ToEven));
        }

        [Fact]
        public async Task  CalcularCdb_DeveVerificarOvalorImpostoEmPorcentagemAcimaVinteQuatroMeses()
        {

            // Arrange
            decimal valorInicial = 1000m;
            int meses = 29;

            // Act
            var resultado = await _service.Calcular(valorInicial, meses);
            Assert.Equal(15.0m, Math.Round(resultado.Imposto / (resultado.ValorFinalBruto - valorInicial) * 100, 1, MidpointRounding.ToEven));


        }
    }
}
