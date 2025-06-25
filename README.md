# ErroLoggerAPI

API e Dashboard para monitoramento e registro de erros de aplicações.

## ✨ Tecnologias utilizadas

- ASP.NET Core (C#)
- MongoDB
- Electron (Frontend do dashboard)
- Node.js

## 🚀 Como rodar o projeto

### Pré-requisitos
- .NET 7.0 ou superior
- Node.js
- Docker (para o MongoDB)

### Backend (API)
```bash
cd ErroLoggerAPI
dotnet run
```

### MongoDB
```bash
docker-compose up -d
```

### Dashboard (Electron)
```bash
cd ElectronDashboard
npm install
npm start
```

## 📦 Funcionalidades

- Registro de erros via API
- Visualização dos erros no Dashboard
- Integração com MongoDB
- Paginação no Dashboard

## 🛡️ Licença

MIT
