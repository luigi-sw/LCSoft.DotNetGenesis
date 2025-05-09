# LC.DotNetGenesis

> [!CAUTION]
> These templates are **highly opinionated by design**.
>
> While they aim to enforce strict and recognized architectural rules and patterns (such as Clean Architecture, DDD, Hexagonal, etc.), they also reflect my personal preferences and interpretations of these patterns.
> This includes specific decisions around:
> - Project structure
> - Naming conventions
> - Use of tools and libraries
> - Dependency injection and organization
> - Code style and folder layout
>
> If you're looking for flexible or fully unopinionated scaffolding, these templates may not be the best fit out-of-the-box. However, you're encouraged to fork and customize them to suit your team's conventions, tooling preferences, and domain requirements.
> 
> These templates were originally created for my own use — tailored to my personal development style and architectural preferences. You're absolutely welcome to use them.

> [!WARNING]  
> One of the core motivations behind this project is that most architecture templates available today are also highly opinionated, but they often fail to make that clear. Worse, many do not let you customize project names, namespaces, or folder structure properly — requiring significant manual cleanup after generation. This repository aims to be transparent about its opinions and give you a better starting point with proper scaffolding that respects your input.
>
> Treat these templates as a strong starting opinion — not a one-size-fits-all solution.

Welcome to the **LC.DotNetGenesis** repository!  

This project provides a collection of `dotnet new` templates for rapidly scaffolding ASP.NET Core applications using **Clean Architecture**, **Hexagonal Architecture (Ports and Adapters)**, and **Onion Architecture** principles — all with support for **Domain-Driven Design (DDD)** and key design patterns like CQRS, Mediator, Repository, and Dependency Injection.

## Overview

Starting a new project with a well-defined structure can significantly accelerate development and improve long-term maintainability. These templates aim to provide pre-configured solutions that embody best practices for different architectural styles.

**Key Features:**

* **Multiple Architectural Patterns:** Choose the architecture that best suits your project needs.
* **Domain-Driven Design (DDD) Ready:** Structured to facilitate DDD concepts like Entities, Aggregates, Value Objects, Domain Events, Repositories, and Application Services.
* **Separation of Concerns:** Clear boundaries between different layers (Domain, Application, Infrastructure, Presentation/API).
* **Testability:** Designed with testability in mind, encouraging unit, integration, and acceptance testing.
* **Modern .NET:** Built using the latest stable versions of .NET and ASP.NET Core.
* **Common Patterns:** Includes examples or placeholders for patterns like CQRS (Command Query Responsibility Segregation), Mediator, Repository, Unit of Work, etc., where applicable.

## Available Templates

Currently, the following templates are available:

1. **DDD Basic Stuff (`lc-ddd-basic`)**

Each template is accessible via `dotnet new` and includes comprehensive project structure and example implementations:

- **lc-ddd-basic** – DDD-first template with aggregates, value objects, repositories, and bounded contexts


## Features 

- ✅ Ready-to-use architecture patterns
- ✅ SOLID principles implementation
- ✅ Testable design
- ✅ Unit test and integration test scaffolding
- ✅ DI-ready structure
- ✅ Modern .NET practices
- ✅ API-first with minimal setup and Swagger/OpenAPI support in API templates (Swagger, versioning, etc.)
- ✅ Health checks
- ✅ Logging integration
- ✅ Configuration management

### All templates support:

- ✅ Domain-Driven Design (DDD) patterns (Entities, Aggregates, Value Objects, Services, Repositories)
- ✅ Follows SOLID, DRY, KISS principles
- ✅ CQRS and Mediator pattern implementation integration option
- ✅ Dependency Injection using Microsoft.Extensions.DependencyInjection
- ✅ Event Sourcing option
- ✅ Mediator pattern
- ✅ Repository pattern
- ✅ Unit of Work pattern
- ✅ Specification pattern
- ✅ Optional persistence via Entity Framework Core (can be replaced)
- ✅ Modular and layered structure


## Prerequisites
- .NET 8.0 SDK or later
- (Optional) Docker for containerized development

## 🚀 Getting Started

### 1. Install Templates

```bash
dotnet new install PATH_TO_THIS_REPOSITORY
# or, for local development
dotnet new install .
```

To use these templates, you first need to install them using the `dotnet new --install` command.

1.  **Clone the repository (Optional - if installing locally):**
    ```bash
    git clone <your-repository-url>
    cd <your-repository-directory>
    ```

2.  **Install from Local Source:**
    Navigate to the root directory containing the `.template.config` folders (or the parent directory of your template projects) and run:
    ```bash
    dotnet new --install .
    # Or point to specific template project folders if needed
    # dotnet new --install ./src/Templates/CleanArchitecture.Template/
    ```

3.  **Install from NuGet (Recommended once published):**
    *Replace `Your.Template.PackageName` with your actual NuGet package ID.*
    ```bash
    dotnet new --install Your.Template.PackageName
    ```

You can verify the installation by running `dotnet new --list` and searching for your template short names (e.g., `lc-clean`, `lc-hex`).

### 2. List Available Templates

```bash
dotnet new list
```

### 3. Usage

Once installed, you can create a new project using the templates.

```bash
# Example: Create a basic DDD project
dotnet new lc-ddd-basic -n MyDDDApp -o ./MyDDDApp
```

#### Template Options
Common options available for all templates:

--use-ddd - Enable Domain-Driven Design patterns
--use-cqrs - Implement CQRS pattern
--use-es - Add Event Sourcing infrastructure
--db-provider - Specify database provider (SqlServer, Postgres, Sqlite, InMemory)
--add-tests - Include unit and integration test projects
--add-docker - Include Docker support

Example:

```bash
dotnet new lc-ddd-basic -n MyDDDProject --use-ddd --db-provider Postgres --add-tests
```

## Template Details

### 🧩 DDD-Basic
Project Structure:

- YourProjectName.Domain: Domain Entities, Aggregates, Domain Services, Repository Interfaces.
- YourProjectName.Application: Application Services, DTOs, Use Cases, Interfaces for Infrastructure.
- YourProjectName.Infrastructure: Data Access, External Service Clients, Implementations of Infrastructure Interfaces.
- YourProjectName.Api (or YourProjectName.Web): Presentation Layer, Dependency Injection.

#### Project Structure Overview
```cpp
MyDDDApp/
├── src/
│   ├── Api/                   // ASP.NET Core entry point (routing, controllers, view models, endpoints)
│   ├── Application/           // Use cases (application services), CQRS handlers, orchestrating domain logic
│   ├── Domain/
│   │   ├── Aggregates/        // Aggregate roots and nested entities
│   │   ├── ValueObjects/      // Immutable types with business rules
│   │   ├── Events/            // Domain events and handlers
│   │   ├── Repositories/      // Interfaces for persistence logic
│   │   └── Services/          // Domain services for complex business logic (stateless operations)
│   └── Infrastructure/        // Persistence, third-party services, repository implementations
├── tests/
│   ├── UnitTests/             // Domain and Application layer tests
│   └── IntegrationTests/      // End-to-end, persistence and API-level testing
└── docs/                      // DDD diagrams, bounded context maps, event storming results,glossary (optional)
```

Principles:

Based on tactical DDD patterns (entities, VOs, aggregates, etc.)
Encourages rich domain modeling
Well-suited for complex, evolving business domains

Key Concepts:
Clear separation of Domain Model and Application Logic.
Designed for strategic design with Bounded Contexts and ubiquitous language.
Emphasis on rich domain modeling, not just anemic data models.
Implements tactical Domain-Driven Design (DDD) patterns.
Rich domain model with aggregates, value objects, and events.
Application layer is an orchestrator — it delegates to the domain model.
Suited for complex, evolving business rules and contexts.

## References
 
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)