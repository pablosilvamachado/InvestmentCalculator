@echo off

:: Navegar para o diretório do projeto e iniciar o servidor
cd InvestCalculator.API\InvestCalculator\

dotnet restore	
timeout /t 5 /nobreak > null

dotnet test ..\..\InvestCalculator.API\InvestCalculator.Tests\bin\Debug\net8.0\InvestmentCalculator.Tests.dll

timeout /t 5 /nobreak > null
dotnet run	 	