@echo off

@echo "---------------------Projeto CDBInvest-------------------------"

@echo "---------------------Compilando e executando Front End-------------------------"

start FrontEnd\setup.bat

@echo "---------------------Compilando e executando Back End-------------------------"
start InvestCalculator.API\InvestCalculator\setup.bat


@echo "---------------------Esperando Finalização do Poocesso-------------------------"
timeout /t 20 /nobreak > null

@echo "---------------------Chamando Browse com Aplicação-------------------------"
start chrome "http://localhost:4200/"


@echo "Projeto CDBInvest Compilado"

