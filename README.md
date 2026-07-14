# ☕ PROJETO PANHA

Projeto simples desenvolvido em **C#** utilizando a plataforma **.NET**.

O sistema tem como objetivo realizar o cadastro e o gerenciamento de informações relacionadas à panha de café.

---

## 📌 OBJETIVO DO PROJETO

O Projeto Panha permite registrar informações como:

* Nome da panha;
* Data;
* Descrição;
* Quantidade de litros;
* Medida;
* Valor;
* Informações relacionadas ao serviço realizado.

---

## 🛠️ TECNOLOGIAS UTILIZADAS

* C#
* .NET
* ASP.NET Core Web API
* Entity Framework Core
* Swagger
* SQLite ou MySQL
* Git
* GitHub
* GitHub Codespaces

---

## 📂 ESTRUTURA DO PROJETO

```text
ProjetoPanha/
├── Controllers/
├── Models/
├── Data/
├── Migrations/
├── Properties/
├── appsettings.json
├── Program.cs
├── ProjetoPanha.csproj
└── README.md
```

---

## 📋 MODELO DA PANHA

Exemplo de entidade utilizada no projeto:

```csharp
public class Panha
{
    public int PanhaId { get; set; }

    public string Nome { get; set; }

    public DateTime Data { get; set; }

    public string Descricao { get; set; }

    public decimal Valor { get; set; }

    public decimal Medida { get; set; }

    public decimal Litros { get; set; }
}
```

---

## ▶️ COMO EXECUTAR O PROJETO

Primeiro, abra o terminal e entre na pasta do projeto:

```bash
cd ProjetoPanha
```

Restaure os pacotes:

```bash
dotnet restore
```

Execute o projeto:

```bash
dotnet run
```

No GitHub Codespaces, utilize:

```bash
dotnet run --urls="http://0.0.0.0:5000"
```

Depois, abra a porta `5000` na aba **PORTS**.

---

## 🌐 ACESSAR O SWAGGER

Após iniciar o projeto, acesse:

```text
http://localhost:5000/swagger
```

No GitHub Codespaces, abra o endereço gerado para a porta `5000` e adicione:

```text
/swagger
```

Exemplo:

```text
https://nome-do-codespace-5000.app.github.dev/swagger
```

---

## 🗄️ BANCO DE DADOS

O projeto pode utilizar SQLite ou MySQL.

Exemplo de conexão com SQLite:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=panha.db"
  }
}
```

Exemplo de conexão com MySQL:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=panha;User=root;Password=;"
  }
}
```

---

## 🔄 MIGRATIONS

Para criar uma migration:

```bash
dotnet ef migrations add InicioBanco
```

Para atualizar o banco de dados:

```bash
dotnet ef database update
```

Para listar as migrations:

```bash
dotnet ef migrations list
```

---

## 📡 PRINCIPAIS ROTAS DA API

Exemplos de rotas:

```text
GET /api/panha
GET /api/panha/{id}
POST /api/panha
PUT /api/panha/{id}
DELETE /api/panha/{id}
```

---

## 🧪 EXEMPLO DE CADASTRO

Exemplo de JSON para cadastrar uma panha:

```json
{
  "nome": "Panha do Sítio",
  "data": "2026-07-14",
  "descricao": "Panha realizada no talhão 1",
  "valor": 250.00,
  "medida": 10,
  "litros": 600
}
```

---

## 📚 FINALIDADE EDUCACIONAL

Este projeto foi desenvolvido para praticar:

* Programação em C#;
* Desenvolvimento de Web API;
* Criação de classes;
* Uso de controllers;
* Operações CRUD;
* Conexão com banco de dados;
* Entity Framework Core;
* Swagger;
* Versionamento com Git e GitHub.

---

## 👨‍💻 AUTOR

**Gabriel Gonçalves Ruas**

Projeto desenvolvido para fins de estudo e aprendizagem em programação C# e .NET.
