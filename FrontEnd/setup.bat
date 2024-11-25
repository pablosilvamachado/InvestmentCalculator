@echo off

set "pasta=node_modules\"

if not exist "%pasta%" (
    echo Instalando as dependências.
	npm install  
) else (
    echo dependencias já instaladas.
)

timeout /t 15 /nobreak > null 

ng serve
