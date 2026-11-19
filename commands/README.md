# 1. Comandos .NET

| Comando | O que faz |
|---|---|
| `dotnet --version` | Mostra a versão do SDK .NET instalada. |
| `dotnet --list-sdks` | Lista todos os SDKs .NET instalados. |
| `dotnet --info` | Apresenta informações sobre o ambiente .NET instalado. |
| `dotnet new mvc -n ReservaSalas --framework net8.0` | Cria um novo projeto ASP.NET Core MVC com .NET 8. |
| `dotnet restore` | Descarrega e prepara as dependências do projeto. |
| `dotnet build` | Compila o projeto e verifica se existem erros. |
| `dotnet run --no-launch-profile --urls http://0.0.0.0:5000` | Executa a aplicação na porta 5000. |
| `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.0` | Instala o fornecedor SQLite para o Entity Framework Core. |

# 2. Comandos de navegação e gestão de ficheiros

| Comando | O que faz |
|---|---|
| `pwd` | Mostra o caminho da pasta atual. |
| `ls` | Lista os ficheiros e pastas do diretório atual. |
| `ls -a` | Lista todos os ficheiros e pastas, incluindo os ocultos. |
| `cd ReservaSalas` | Entra na pasta ReservaSalas, caso esteja no diretório que a contém. |
| `cd src/ReservaSalas` | Entra na pasta do projeto a partir da raiz do repositório. |

# 3. Comandos do Entity Framework Core

| Comando | O que faz |
|---|---|
| `dotnet tool install --global dotnet-ef --version 8.0.0` | Instala a ferramenta de linha de comandos do Entity Framework Core, permitindo gerir migrations e a base de dados. |
| `dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0` | Instala o pacote necessário para utilizar as ferramentas de desenvolvimento do Entity Framework Core. |
| `dotnet ef migrations add InitialCreate` | Cria a primeira migration com base nos Models e na configuração do DbContext. |
| `dotnet ef database update` | Aplica as migrations e cria ou atualiza a estrutura da base de dados. |
| `dotnet ef migrations list` | Apresenta a lista de migrations existentes no projeto. |

**Nota:** Os comandos do Entity Framework Core devem ser executados dentro da pasta do projeto que contém o ficheiro `.csproj`.