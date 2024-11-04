# E-commerce microservices

Biblioteca.Api é uma API Web ASP.NET Core projetada para gerenciar um sistema de biblioteca. 
A API fornece endpoints para autenticação de usuários, gerenciamento de livros, reservas de livros 
e gerenciamento de usuários. Esta documentação irá orientá-lo na configuração e uso da API.


## Principais Funcionalidades

Auth
- Registrar um novo usuário.
- Registrar um novo usuário administrador.
- Autenticar um usuário e gerar um token JWT.

Book
- Recuperar uma lista de todos os livros.
- Adicionar um novo livro.
- Recuperar detalhes de um livro específico pelo ID.
- Atualizar detalhes de um livro específico pelo ID.
- Excluir um livro específico pelo ID.

BookReservation
- Recuperar uma lista de todas as reservas de livros.
- Recuperar detalhes de uma reserva de livro específica pelo ID.
- Recuperar uma lista de reservas de livros para o usuário autenticado.
- Criar uma nova reserva de livro para um livro específico.
- Fechar uma reserva de livro específica pelo ID.

<hr>

<br>

## Clonando o Repositório

```bash
git clone https://github.com/uFelps/biblioteca-api.git
cd biblioteca-api
```

### Rodando o Docker-Compose

```bash
docker-compose up
```
