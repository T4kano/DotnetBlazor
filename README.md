---

# DotnetBlazor Application

Este projeto é uma aplicação web desenvolvida com **Blazor** e **Entity Framework Core**. A aplicação permite gerenciar entidades como balanças e câmeras, com suporte para operações CRUD e validações.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server ou SQLite](https://www.sqlite.org/download.html) (dependendo da configuração)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) ou [Visual Studio Code](https://code.visualstudio.com/)

## Configuração do Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/t4kano/dotnetblazor.git
   cd dotnetblazor
   ```

2. Restaure os pacotes NuGet:
   ```bash
   dotnet restore
   ```

3. Configure a conexão com o banco de dados no arquivo `appsettings.json` (na pasta `DotnetBlazor.Web`):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=DotnetBlazorDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

   > Se preferir usar SQLite, altere a string de conexão para:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Data Source=DotnetBlazor.db"
     }
   }
   ```

4. Execute as migrações do banco de dados para criar as tabelas:
   ```bash
   dotnet ef database update
   ```

## Executando a Aplicação

1. Para rodar a aplicação em modo de desenvolvimento, use o comando:
   ```bash
   dotnet run --project DotnetBlazor.Web
   ```

2. Abra seu navegador e acesse:
   ```
   https://localhost:5001
   ```

## Estrutura do Projeto

- **DotnetBlazor.Domain**: Contém as entidades do domínio como `Balance` e `Camera`.
- **DotnetBlazor.Infrastructure**: Contém os repositórios e a configuração do banco de dados.
- **DotnetBlazor**: Contém a interface de usuário Blazor e a camada de apresentação.

## Funcionalidades

- Gerenciamento de **Balanças** e **Câmeras** (CRUD).
- Validações de formulários usando **FluentValidation**.
- Relacionamentos **many-to-many** entre Balanças e Câmeras.
- Exibição e seleção de Câmeras associadas a Balanças.

## Comandos Importantes

- **Executar o projeto**:
  ```bash
  dotnet run --project DotnetBlazor.Web
  ```

- **Aplicar migrações**:
  ```bash
  dotnet ef migrations add NomeDaMigracao
  dotnet ef database update
  ```

- **Restaurar pacotes**:
  ```bash
  dotnet restore
  ```

## Contribuição

1. Faça um fork do repositório.
2. Crie uma nova branch:
   ```bash
   git checkout -b minha-nova-funcionalidade
   ```
3. Faça commit das suas mudanças:
   ```bash
   git commit -m 'Adiciona nova funcionalidade'
   ```
4. Envie suas mudanças para a branch:
   ```bash
   git push origin minha-nova-funcionalidade
   ```
5. Abra um Pull Request.

---
