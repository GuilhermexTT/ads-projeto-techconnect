# TechConnect Backend

Backend em C# ASP.NET Core para o sistema TechConnect.

## Funcionalidades

- Gerenciamento de Participantes
- Inscrições em eventos
- Emissão de Certificados de participação
- Área do participante para consultar e emitir certificados

## Modelos

- **Participante**: Dados do participante
- **Inscricao**: Inscrição em evento, vinculada a Participante
- **Certificado**: Certificado emitido para inscrição, com horas acadêmicas

## Como executar

1. Instale o .NET 8 SDK: https://dotnet.microsoft.com/download
2. Restaure os pacotes: `dotnet restore`
3. Atualize o banco: `dotnet ef database update`
4. Execute: `dotnet run`

O site estará em http://localhost:9999

## Integração com Frontend

O frontend HTML pode linkar para as rotas do backend, como /Inscricao/Create para inscrição.