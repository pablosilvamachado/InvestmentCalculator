@echo off

@echo "---------------------Projeto InvestCalculator-------------------------"

@echo "---------------------Compilando e executando Front End-------------------------"

start FrontEnd\setup.bat

@echo "---------------------Compilando o projeto de testes-------------------------"

set "pasta=InvestCalculator.API\InvestCalculator.Tests\bin\"

if not exist "%pasta%" (
		start InvestCalculator.API\InvestCalculator.Tests\setup.bat
		timeout /t 15 /nobreak > null
)

@echo "---------------------Compilando e executando Back End-------------------------"
start InvestCalculator.API\InvestCalculator\setup.bat

@echo "---------------------Esperando Finalização do Poocesso-------------------------"
timeout /t 30 /nobreak > null

@echo "---------------------Chamando Browse com Aplicação-------------------------"
start chrome "http://localhost:4200/"


@echo "Projeto InvestCalculator Compilado"

