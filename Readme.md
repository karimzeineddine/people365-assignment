# TodoApi

**Description**: A simple REST API for managing todo items with CRUD operations (Create, Read, Update, Delete) using ASP.NET Core, Entity Framework Core, and SQLite.

**Table of Contents**:
- [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Contributing](#contributing)
  
## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/username/repository-name.git
   cd repository-name
   dotnet restore
   dotnet run

## **Usage**:
- TodoApi provides endpoints to manage todo items. Use tools like Postman or a REST client to interact with the API at http://localhost:5187.

- Endpoints:
- Get All Todos: GET http://localhost:5187/api/todoitems
- Create a Todo: POST http://localhost:5187/api/todoitems with JSON body { "Name": "Todo", "IsComplete": false }
- Update a Todo: PUT http://localhost:5187/api/todoitems/{id} with JSON body { "Name": "Updated Todo", "IsComplete": true }
- Delete a Todo: DELETE http://localhost:5187/api/todoitems/{id}

## **Features**:
- RESTful API using ASP.NET Core.
- SQLite database integration.
- Authentication with JSON Web Tokens (JWT).
- CRUD operations for Todo items.
- In-memory testing with unit tests.

## **Contributing**
- Contributions are welcome! To contribute to TodoApi:
  
- Fork the repository.
- Create a new branch
  git checkout -b feature-branch
- Make your changes and commit (git commit -m 'Add feature').
- Push to the branch (git push origin feature-branch).
- Open a pull request.
