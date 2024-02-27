# API-SIGNALR

## Descrição
Este projeto é uma Web API que utiliza o SignalR para fornecer funcionalidades de notificação em tempo real.

## Pré-requisitos
- [ASP.NET Core 8.0](https://dotnet.microsoft.com/download)
- [SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/get-started)

## Configuração
1. Clone o repositório: `git clone https://github.com/ruancampelo/API-SIGNALR.git`
2. Abra o projeto no Visual Studio ou no seu editor de código preferido.

## Instalação
1. Restaure as dependências: `dotnet restore`
2. Configure a Connection String no arquivo `appsettings.json` apontando para o caminho do arquivo Chinook.db, localizado na pasta `Infraestrutura/Data`.
   Exemplo:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=./Infraestrutura/Data/Chinook.db"
   }

![Logo do React](https://i.imgur.com/ImJeA6k.png)

