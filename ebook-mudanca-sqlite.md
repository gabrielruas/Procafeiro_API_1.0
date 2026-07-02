# Migrando o projeto `procafeiro` de SQL Server para SQLite

## Introdução

Este eBook documenta a migração do projeto ASP.NET Core `procafeiro` de SQL Server para SQLite. A troca inclui atualização de pacotes, configuração de contexto EF, ajustes nas migrations e criação do banco SQLite.

## Objetivo

- Substituir `Microsoft.EntityFrameworkCore.SqlServer` por `Microsoft.EntityFrameworkCore.Sqlite`
- Atualizar a configuração para usar uma conexão SQLite via `appsettings.json`
- Ajustar o `DbContext` para injeção de dependência
- Modificar as migrations para schema compatível com SQLite
- Aplicar o banco SQLite com `dotnet ef database update`

## Por que usar SQLite?

- SQLite é leve e não precisa de servidor separado
- Ideal para desenvolvimento local e testes rápidos
- O arquivo do banco pode ser facilmente versionado ou compartilhado
- Reduz dependências em máquinas que não têm SQL Server

## Arquivos alterados

- `procafeiro.csproj`
- `appsettings.json`
- `Program.cs`
- `DataAccess/Contexto.cs`
- `Migrations/20260625132007_INICIO_DATABASE.cs`
- `Migrations/20260625132007_INICIO_DATABASE.Designer.cs`
- `Migrations/ContextoModelSnapshot.cs`

## Passo a passo da migração

### 1. Atualizar as dependências

No arquivo `procafeiro.csproj`, removemos o pacote do SQL Server e adicionamos o pacote SQLite:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6" />
```

Também mantivemos:

```xml
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="6" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="6" />
```

### 2. Configurar a conexão em `appsettings.json`

Adicionamos a string de conexão SQLite:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=procafeiro.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. Ajustar a inicialização em `Program.cs`

Alteramos a configuração do `DbContext` para usar SQLite:

```csharp
using DataAccess;
using DataAccess.Repositorios;
using DataAccess.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPanhaRepositorio, PanhaRepositorio>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

### 4. Adaptar `DataAccess/Contexto.cs`

O `DbContext` foi alterado para receber `DbContextOptions<Contexto>` via construtor:

```csharp
using Microsoft.EntityFrameworkCore;
using Dominio;

namespace DataAccess;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public DbSet<Panha> Panha { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PanhaConfiguration());
    }
}
```

### 5. Ajustar migrations para SQLite

As migrations existentes continham referências SQL Server. Foi necessário trocar tipos e extensões específicas:

- `int` → `INTEGER`
- `nvarchar(max)` → `TEXT`
- `datetime2` → `TEXT`
- `SqlServer:Identity` → `Sqlite:Autoincrement`
- remover `SqlServerModelBuilderExtensions` e `SqlServerPropertyBuilderExtensions`

Exemplo de alteração em `Migrations/20260625132007_INICIO_DATABASE.cs`:

```csharp
migrationBuilder.CreateTable(
    name: "Panhas",
    columns: table => new
    {
        IdPanha = table.Column<int>(type: "INTEGER", nullable: false)
            .Annotation("Sqlite:Autoincrement", true),
        NomeColobarador = table.Column<string>(type: "TEXT", nullable: true),
        Nmedidas = table.Column<int>(type: "INTEGER", nullable: false),
        Nlitros = table.Column<int>(type: "INTEGER", nullable: false),
        Data = table.Column<DateTime>(type: "TEXT", nullable: false)
    },
    constraints: table =>
    {
        table.PrimaryKey("PK_Panhas", x => x.IdPanha);
    });
```

### 6. Construir e aplicar a migração

Executamos os seguintes comandos:

```bash
dotnet restore
dotnet build
dotnet ef database update
```

Após `dotnet ef database update`, o arquivo `procafeiro.db` foi criado e o banco SQLite foi populado com a tabela `Panhas`.

## Comandos úteis

### Instalar dependências e compilar

```bash
dotnet restore
dotnet build
```

### Atualizar banco de dados SQLite

```bash
dotnet ef database update
```

### Se precisar recriar o banco e aplicar novamente

```bash
dotnet ef database drop --force
dotnet ef database update
```

### Se precisar criar nova migration após mudanças no modelo

```bash
dotnet ef migrations add NomeDaMigration
```

## Resultado final

Após a migração:

- O projeto não depende mais de SQL Server
- O aplicativo usa SQLite local em `procafeiro.db`
- As migrations foram adaptadas para o provedor SQLite
- O build do projeto foi concluído com sucesso

## Observações

- O SQLite é ideal para desenvolvimento local, testes e protótipos
- Se você quiser usar diferentes bancos em ambientes distintos, adicione `appsettings.Development.json` e `appsettings.Production.json` com conexões separadas
- Se existirem dados no SQL Server que precisem ser migrados, será preciso exportar/importar manualmente ou usar uma ferramenta de migração de dados

---

## Apoio técnico

Se quiser, posso também gerar um PDF a partir deste Markdown ou criar um README mais enxuto para o repo.
