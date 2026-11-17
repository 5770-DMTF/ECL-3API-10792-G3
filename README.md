# Gestão de Reservas de Salas

## 1. Identificação do grupo

- **Escola:** Escola do Comércio de Lisboa
- **Curso:** 3.º API – Programador Informático
- **Módulo:** UFCD 10792 – Desenvolvimento de Aplicações Web em ASP.NET Core MVC
- **Grupo:** 3
- **Formandos:** Diogo e Danilo
- **Projeto:** Gestão de Reservas de Salas
- **Ano letivo:** 2026/2027

## 2. Objetivo do projeto

O projeto consiste no desenvolvimento de uma aplicação Web para gerir reservas de salas.
A aplicação pretende facilitar a organização da utilização das salas pelos docentes, permitindo gerir salas, docentes e reservas, evitando conflitos de horários e sobreposições de reservas para a mesma sala.

## 3. Tecnologias utilizadas

- **C#:** Linguagem de programação utilizada no desenvolvimento da aplicação. 
- **ASP.NET Core MVC:** Framework utilizada para desenvolver a aplicação Web, seguindo o padrão Model-View-Controller.  
- **Razor:** Tecnologia utilizada para criar as páginas e interfaces da aplicação.
- **Entity Framework Core:** ORM utilizado para gerir o acesso e a persistência dos dados.
- **SQLite:** Sistema de gestão de base de dados utilizado para armazenar a informação.
- **HTML e CSS:** Utilizados para estruturar e estilizar as páginas.
- **Git e GitHub:** Utilizados para controlo de versões e armazenamento do código.
- **GitHub Codespaces:** Ambiente de desenvolvimento utilizado para programar e executar o projeto.
    

## 4. Pré-requisitos

Para executar o projeto, são necessários:

- Conta GitHub com acesso ao repositório. 
- Acesso à Internet.  
- Navegador Web atualizado.  
- .NET 8 SDK.  
- Git (caso a execução seja feita num ambiente local).
    

No GitHub Codespaces, o ambiente de desenvolvimento é preparado através do ficheiro `.devcontainer/devcontainer.json`.

## 5. Estrutura do projeto

O repositório está organizado da seguinte forma:

```
ECL-3API-10792-G3/
│
├── .devcontainer/
│   └── devcontainer.json
│
├── src/
│   └── ReservaSalas/
│       ├── Controllers/
│       ├── Models/
│       ├── Views/
│       ├── wwwroot/
│       ├── Program.cs
│       └── ReservaSalas.csproj
│
├── docs/
├── database/
│
├── .gitignore
└── README.md
```

- **src:** Contém o código-fonte da aplicação. 
- **docs:** Destina-se ao relatório técnico e às imagens do projeto.  
- **database:** Destina-se aos scripts e à documentação da base de dados.  
- **.devcontainer:** Contém a configuração do ambiente de desenvolvimento.

## 6. Instalação e execução

### 6.1. Obter o projeto

Clonar o repositório através do seguinte comando:

```
git clone https://github.com/5770-DMTF/ECL-3API-10792-G3
```

Entrar na pasta da aplicação:

```
cd src/ReservaSalas
```

### 6.2. Preparar o projeto

Restaurar as dependências:

```
dotnet restore
```

Compilar o projeto:

```
dotnet build
```

### 6.3. Executar a aplicação

Iniciar a aplicação através do seguinte comando:

```
dotnet run --no-launch-profile --urls http://0.0.0.0:5000
```

No GitHub Codespaces, a aplicação ficará disponível através da porta 5000. No painel **Ports**, selecionar **Open in Browser** para abrir a aplicação no navegador.

## 7. Base de dados

O projeto utiliza SQLite para armazenar os dados relativos às salas, docentes e reservas.
A base de dados será gerida através do Entity Framework Core, utilizando migrations para criar e atualizar a estrutura das tabelas.

## 8. Funcionalidades previstas

A aplicação deverá permitir:

- Consultar, adicionar, alterar e eliminar salas.   
- Consultar, adicionar, alterar e eliminar docentes.
- Criar novas reservas.
- Alterar e cancelar reservas existentes.
- Filtrar reservas por sala, docente e dia.
- Validar os horários das reservas.
- Impedir sobreposições de reservas para a mesma sala.
- Consultar a ocupação diária de cada sala.
    

## 9. Segurança e validação

A aplicação deverá incluir validações dos dados introduzidos nos formulários e regras de negócio verificadas no servidor.
Serão também implementadas medidas de proteção contra CSRF nos formulários que alterem dados, tratamento de erros e proteção das credenciais utilizadas na configuração da aplicação.

## 10. Autores

Projeto desenvolvido por Danilo e Diogo, no âmbito da UFCD 10792 – Desenvolvimento de Aplicações Web em ASP.NET Core MVC, da Escola do Comércio de Lisboa.