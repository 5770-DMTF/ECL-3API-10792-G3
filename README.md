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

A aplicação utiliza **SQLite** como sistema de gestão de base de dados e **Entity Framework Core** como ORM para assegurar a comunicação entre a aplicação e os dados.

A ligação à base de dados é configurada através da classe `ApplicationDbContext`, que permite gerir as entidades e as respetivas relações.

### 7.1. Estrutura da base de dados

A base de dados é constituída por três tabelas principais:

- **Salas:** armazena a informação das salas, incluindo o código, a capacidade e o tipo.
- **Docentes:** armazena os dados dos docentes, nomeadamente o nome, o email e a área.
- **Reservas:** regista as reservas efetuadas, incluindo a sala, o docente, a data, a hora de início, a hora de fim e a finalidade.

### 7.2. Relações entre tabelas

Foram definidas as seguintes relações:

- **Salas – Reservas:** relação de um para muitos (1:N). Uma sala pode ter várias reservas, mas cada reserva está associada a uma única sala.
- **Docentes – Reservas:** relação de um para muitos (1:N). Um docente pode efetuar várias reservas, mas cada reserva pertence a um único docente.

As relações são asseguradas através das chaves primárias e estrangeiras.

### 7.3. Migrations

A estrutura da base de dados é gerida através de migrations do Entity Framework Core.

Foi criada a migration inicial `InitialCreate`, responsável pela criação das tabelas e das respetivas relações.

Para criar ou atualizar a base de dados, utilizar o seguinte comando na pasta `src/ReservaSalas`:

```dotnet ef database update```

### 7.4. Armazenamento

A base de dados é armazenada localmente no ficheiro `reservas.db`, localizado na pasta do projeto.

Este ficheiro está excluído do controlo de versões através do `.gitignore`, evitando a publicação dos dados locais no repositório GitHub.

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