# InvestmentCalculator

# Projeto para Cálculo do retorno de investimento em CDB por período.

Este projeto é uma aplicação completa que calcula o Valor Bruto e o Valor Líquido de um investimento em CDB, com base no valor inicial e no período (em meses) informado pelo usuário.

1. Frontend: Interface de usuário para entrada de dados e exibição dos resultados.

2. Backend: API em .NET para realizar os cálculos de rendimento e impostos.

3. Automação: Script setup.bat para simplificar o build e a execução do projeto.


## 📋Funcionalidades

Interface de usuário:

- Entrada de dados: Valor Inicial e Período (em meses).
- Exibição do resultado com:
- Valor Bruto.
- Valor Líquido (após impostos).
- Cálculo backend:
- Fórmula aplicada mês a mês para calcular o valor final.

- Dedução de impostos de acordo com o prazo:

Até 6 meses: 22.5%.

De 7 a 12 meses: 20.0%.

De 13 a 24 meses: 17.5%.

Acima de 24 meses: 15.0%.


##  🛠️Tecnologias

- Backend: .NET (ASP.NET Core)

- Frontend: Angular

- Automação: Script Batch para build e execução

## 🚀 Configuração do Projeto

- Pré-requisitos

Certifique-se de ter os seguintes softwares instalados:

1 .NET 8.0 SDK

2. Node.js e npm
   
3. Git

- Como baixar o projeto

Clone o repositório do GitHub:

```bash

git clone https://github.com/pablosilvamachado/InvestmentCalculator.git

```

Acesse a pasta principal:

```bash

cd InvestmentCalculator

```

Execute o script de setup:

```bash

setup.bat

```

 O que o setup.bat faz?

1. O script realiza os seguintes passos:

2. Restaura, testa e compila o projeto backend.

3. Instala as dependências do frontend.

4. Inicia simultaneamente o servidor backend e o frontend.

5. Abre automaticamente o sistema no navegador.

## 🖥️Uso

!. No navegador, acesse o endereço exibido no terminal (geralmente http://localhost:4200).


2. Informe o Valor Inicial e o Período (em meses) na interface.
  

3. Clique no botão para calcular e visualize os resultados.


## 🧑‍💻Estrutura do Projeto

cdb-calculator/

 ├── backend/       # API em .NET Core

 ├── frontend/      # Interface Angular

 ├── setup.bat      # Script de automação para setup do projeto

 └── README.md      # Documentação do projeto
 

##  📄Licença

Este projeto é licenciado sob a MIT License.


##  🙌Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir um Pull Request ou relatar problemas no repositório.
