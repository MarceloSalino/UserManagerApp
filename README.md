# 🧑‍💻 UserManagerApp

Aplicação web desenvolvida em **ASP.NET Core MVC (.NET 9)** para gerenciamento de usuários, utilizando **Clean Architecture**, **Entity Framework Core**, **jQuery AJAX** e **AdminLTE**.

---

## 🚀 Tecnologias utilizadas

* .NET 9
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* AutoMapper
* Serilog (logs de erro)
* jQuery + AJAX
* AdminLTE (template UI)

---

## 📁 Estrutura do Projeto

```
UserManagerApp
│
├── Domain          → Entidades e interfaces
├── Application     → Serviços, DTOs e AutoMapper
├── Infrastructure  → EF Core, Repositórios e Logs
├── Web             → Controllers, Views e Frontend
```

---

## ⚙️ Pré-requisitos

Antes de executar, você precisa ter instalado:

* [.NET 9 SDK](https://dotnet.microsoft.com/download)
* SQL Server (ou SQL Server Express)
* Visual Studio 2022 (ou VS Code)

---

## 🗄️ Configuração do Banco de Dados

1. Abra o arquivo:

```
UserManagerApp.Web/appsettings.json
```

2. Configure a connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=UserManagerDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> 💡 Se usar SQL Express:

```
Server=localhost\\SQLEXPRESS
```

---

## 🧬 Criar banco de dados

No terminal ou Package Manager Console:

```bash
dotnet ef database update \
--project UserManagerApp.Infrastructure \
--startup-project UserManagerApp.Web
```

Isso irá:

* Criar o banco `UserManagerDb`
* Criar a tabela `Usuario`

---

## ▶️ Executar a aplicação

No terminal:

```bash
dotnet run --project UserManagerApp.Web
```

Ou pelo Visual Studio:

* Defina o projeto **UserManagerApp.Web** como inicial
* Pressione `F5`

---

## 🌐 Acessar no navegador

A aplicação abrirá automaticamente em:

```
https://localhost:xxxx/usuario
```

---

## 📌 Funcionalidades

### 👤 Usuários

* ✔ Listar usuários
* ✔ Cadastrar novo usuário
* ✔ Editar usuário existente
* ✔ Excluir usuário

---

## 💬 Chat de ajuda

A aplicação possui um chat inteligente que:

* Responde dúvidas de uso
* Baseado em arquivo local de ajuda (`help.json`)
* Interface flutuante

---

## 🧠 Arquitetura

O projeto segue os princípios de:

* Clean Architecture
* SOLID
* Separação de responsabilidades

---

## ⚠️ Logs

Os erros são registrados com **Serilog**:

```
/logs/error-YYYYMMDD.txt
```

---
