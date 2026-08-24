# 📚 Bookstore API

API REST desenvolvida em C# e ASP.NET Core para gerenciamento de livros, aplicando conceitos de arquitetura em camadas, injeção de dependência, validação de dados e boas práticas no desenvolvimento de APIs.

Os dados da aplicação são armazenados em memória. Isso significa que os livros cadastrados durante a execução da aplicação não são persistidos em um banco de dados. Ao reiniciar a aplicação, todos os dados cadastrados são perdidos.

## 🚀 Tecnologias

* C#
* .NET 8
* ASP.NET Core Web API
* Swagger
* Git
* REST API

## 📋 Funcionalidades

* Listar todos os livros
* Buscar livro por ID
* Cadastrar novo livro
* Atualizar livro
* Excluir livro

## 🔗 Endpoints

### 📖 Listar livros

```http
GET /api/books
```

Retorna todos os livros cadastrados.

### 🔎 Buscar livro por ID

```http
GET /api/books/{id}
```

Retorna um livro específico a partir do seu identificador (ID).

### ➕ Cadastrar livro

```http
POST /api/books
```

Exemplo de requisição:

```json
{
  "title": "Orgulho e Preconceito",
  "author": "Jane Austen",
  "genre": 2,
  "price": 67.90,
  "stock": 10
}
```

### ✏️ Atualizar livro

```http
PUT /api/books/{id}
```

Exemplo:

```json
{
  "title": "Orgulho e Preconceito",
  "author": "Jane Austen",
  "genre": 2,
  "price": 67.90,
  "stock": 15
}
```

### 🗑️ Excluir livro

```http
DELETE /api/books/{id}
```

Remove um livro a partir do seu ID.

## 🏷️ Valores do campo `genre`
 
| Valor | Gênero        |
| ----- | ------------- |
| `1`   | Ação          |
| `2`   | Romance       |
| `3`   | Fantasia      |
| `4`   | Ficção        |
| `5`   | Suspense      |
| `6`   | Aventura      |
| `7`   | Biografia     |

## 📌 Respostas HTTP

| Código                      | Descrição                                     |
| --------------------------- | --------------------------------------------- |
| `200 OK`                    | Livros consultados com sucesso                |
| `201 Created`               | Livro criado com sucesso                      |
| `204 No Content`            | Livro atualizado ou excluído com sucesso      |
| `400 Bad Request`           | Dados da requisição inválidos                 |
| `404 Not Found`             | Livro não encontrado                          |
| `500 Internal Server Error` | Erro interno do servidor                      |


## ▶️ Como executar o projeto

### Pré-requisitos

Antes de começar, certifique-se de ter instalado:

* [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
* Git
* Visual Studio ou Visual Studio Code

### Clonando o projeto

```bash
git clone <URL_DO_REPOSITORIO>
```

Entre na pasta do projeto:

```bash
cd <NOME_DA_PASTA>
```

### Restaurando as dependências

```bash
dotnet restore
```

### Executando a aplicação

```bash
dotnet run
```

A API estará disponível na porta informada pelo terminal.

## 📚 Objetivo do projeto

Este projeto faz parte dos meus estudos em desenvolvimento **Back-end com C# e .NET**, com foco em:

* Desenvolvimento de APIs REST
* ASP.NET Core
* C#
* Injeção de dependência
* Separação de responsabilidades
* Validação de dados
* HTTP Status Codes
* Swagger
* Boas práticas de desenvolvimento

## 👩‍💻 Desenvolvido por

**Rhayane Fabres**

Projeto desenvolvido para fins de estudo e portfólio.
