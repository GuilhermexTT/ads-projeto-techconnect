# TechConnect 2026

Evento de Tecnologia com foco em acessibilidade e inclusão.

## Estrutura do Projeto

```
/
├── frontend/                    # Arquivos do frontend
│   ├── pages/                   # Páginas HTML
│   │   ├── index.html          # Página inicial
│   │   ├── formulario.html     # Página de inscrição
│   │   └── programacao.html    # Página de programação
│   └── assets/                  # Recursos estáticos
│       ├── css/
│       │   └── styles.css      # Estilos CSS
│       ├── js/
│       │   └── script.js       # Scripts JavaScript
│       └── images/             # Imagens e ícones
│           ├── FundoProjetoMain.jpeg
│           ├── calendario.png
│           ├── relogio.png
│           └── ...
├── backend/                     # Arquivos do backend ASP.NET Core
│   ├── Controllers/            # Controladores da API
│   ├── Models/                 # Modelos de dados
│   ├── Views/                  # Views do ASP.NET Core
│   ├── back-end.sln           # Arquivo de solução
│   ├── TechConnectBackend.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   └── launchSettings.json
├── .git/                       # Controle de versão
└── README.md                   # Este arquivo
```

## Como executar

### Backend
1. Navegue até a pasta `backend/`
2. Execute `dotnet run`

### Frontend
1. Abra os arquivos HTML diretamente no navegador ou use um servidor local
2. Para desenvolvimento, use um servidor HTTP local (ex: Live Server no VS Code)

## Funcionalidades

- Design 100% responsivo
- Navegação intuitiva com menu hamburger
- Formulário de inscrição funcional
- Recursos de acessibilidade (Libras)
- Interface moderna e acessível

## Backend (ASP.NET Core)

### Funcionalidades do Backend
- Gerenciamento de Participantes
- Inscrições em eventos
- Emissão de Certificados de participação
- Área do participante para consultar e emitir certificados

### Modelos
- **Participante**: Dados do participante
- **Inscricao**: Inscrição em evento, vinculada a Participante
- **Certificado**: Certificado emitido para inscrição, com horas acadêmicas

### Como executar o Backend
1. Instale o .NET 8 SDK: https://dotnet.microsoft.com/download
2. Navegue até a pasta `backend/`
3. Restaure os pacotes: `dotnet restore`
4. Atualize o banco: `dotnet ef database update`
5. Execute: `dotnet run`

O backend estará disponível em http://localhost:9999