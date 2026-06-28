# Employee Management API

A production-ready ASP.NET Core 10 Web API demonstrating modern backend development practices including Repository Pattern, Entity Framework Core, JWT Authentication, FluentValidation, Global Exception Handling, Docker, SQL Server, and Swagger.

---

## Features

- ASP.NET Core 10 Web API
- Entity Framework Core
- SQL Server
- Repository Pattern
- Dependency Injection
- JWT Authentication
- FluentValidation
- Global Exception Middleware
- Swagger/OpenAPI
- Docker Support
- Docker Compose
- Migrations

---

## Technologies

- ASP.NET Core 10
- C#
- Entity Framework Core
- SQL Server 2018
- Docker
- Docker Compose
- Swagger
- JWT Authentication
- FluentValidation

---

## Project Structure

```
EmployeeManagement
│
├── Controllers
├── Models
├── Repository
├── Interfaces
├── DTO
├── Validations
├── Exception_Middleware
├── Migrations
├── Program.cs
├── Dockerfile
├── docker-compose.yml
└── appsettings.json
```

---

## API Features

Employee CRUD

- Get Employees
- Get Employee by Id
- Create Employee
- Update Employee
- Delete Employee

Authentication

- JWT Token Generation
- JWT Authorization

Validation

- Employee Create Validation
- Employee Update Validation

Exception Handling

- Global Exception Middleware

---

## Clone Repository

```bash
git clone https://github.com/YourUserName/EmployeeManagement.git
```

```
cd EmployeeManagement
```

---

## Running without Docker

### Prerequisites

- Visual Studio 2022
- .NET 10 SDK
- SQL Server

Update connection string in

```
appsettings.Development.json
```

Example

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=Employee_Management;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Apply migrations

```bash
dotnet ef database update
```

Run

```bash
dotnet run
```

Swagger

```
http://localhost:8080/swagger
```

(or the port shown in launchSettings.json)

---------------------------------------------------------------

## Running using Docker

### Prerequisites

- Docker Desktop

Start containers

```bash
docker compose up --build
```

The application automatically

- creates database
- applies migrations
- starts SQL Server
- starts Web API

Swagger

```
http://localhost:8081/swagger/index.html
```

Stop containers

```bash
docker compose down
```

---

## Database

SQL Server is hosted inside Docker.

The application automatically executes

```csharp
db.Database.Migrate();
```

during startup.

No manual database creation is required.

---

## Authentication

Generate JWT Token

```
GET /api/Employees/token
```

Use the returned token in Swagger

```
Bearer <token>
```

---

## API Endpoints

| Method | Endpoint |
|----------|--------------------------|
| GET | /api/Employees |
| GET | /api/Employees/{employeeid} |
| POST | /api/Employees |
| PUT | /api/Employees/{employeeid} |
| DELETE | /api/Employees/{employeeid} |
| GET | /api/Employees/token |

---

## Docker Commands

Build

```bash
docker compose build
```

Start

```bash
docker compose up
```

Stop

```bash
docker compose down
```

View running containers

```bash
docker ps
```

View logs

```bash
docker logs employee_api
```

---


