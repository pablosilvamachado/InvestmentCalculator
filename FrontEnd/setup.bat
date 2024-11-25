@echo off

cd FrontEnd\

set "pasta=node_modules\"

if not exist "%pasta%" (
    echo Instalando as dependências.
	npm install
	timeout /t 10 /nobreak > null
    ng serve
) 

timeout /t 10 /nobreak > null 

ng serve
