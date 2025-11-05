# LCSoft.DotNetGenesis

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

Welcome to the **LCSoft.DotNetGenesis** repository!  

This project will provide a collection of `dotnet new` templates for rapidly scaffolding ASP.NET Core applications using **Clean Architecture**, **Hexagonal Architecture (Ports and Adapters)**, and **Onion Architecture** principles — all with support for **Domain-Driven Design (DDD)** and key design patterns like CQRS, Mediator, Repository, and Dependency Injection.

> [!TIP]
> For this first version, this will be only my choices for organization when creating a new project, will not be implemented DDD strictly at this point since this will be a future feature. Right now I just need a quickly setup start for my projects.

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

1. **LC Basics (`lc-basic-*`)**

Each template is accessible via `dotnet new` and includes comprehensive project structure and example implementations:

- **lc-basic-api** – Basic template with some basic structure and baseline files.
- **lc-basic-web** – Basic template for web applications with MVC structure.

## Features 

- [x] Ready-to-use architecture patterns
- [x] SOLID principles implementation
- [x] Testable design
- [x] Unit test and integration test scaffolding
- [x] DI-ready structure
- [x] Modern .NET practices
- [x] Health checks
- [ ] Logging integration
- [ ] API-first with minimal setup and Swagger/OpenAPI support in API templates (Swagger, versioning, etc.)
- [ ] Configuration management

### All templates support:

- [x] Modular and layered structure
- [x] Follows SOLID, DRY, KISS principles
- [x] Dependency Injection using Microsoft.Extensions.DependencyInjection
- [ ] Optional persistence via Entity Framework Core (can be replaced)
- [ ] Domain-Driven Design (DDD) patterns (Entities, Aggregates, Value Objects, Services, Repositories)
- [ ] CQRS and Mediator pattern implementation integration option
- [ ] Event Sourcing option
- [ ] Mediator pattern
- [ ] Repository pattern
- [ ] Unit of Work pattern
- [ ] Specification pattern


## Prerequisites
- .NET 8.0 SDK or later
- (Optional) Docker for containerized development - not implemented yet

## Getting Started

### 1. Install Templates

```bash
dotnet new install PATH_TO_THIS_REPOSITORY
# or, for local development
dotnet new install .
```

To use these templates, you first need to install them using the `dotnet new --install` command.

1.  **Clone the repository (Optional - if installing locally):**
    ```bash
    git clone https://github.com/luigi-sw/LCSoft.DotNetGenesis
    cd LCSoft.DotNetGenesis
    ```

2.  **Install from Local Source:**
    Navigate to the root directory containing the `.template.config` folders (or the parent directory of your template projects) and run:
    ```bash
    # **Build the project** (this will generate a `.nupkg` file automatically)
    dotnet build

    # The package will be created under `bin/Debug` (or `bin/Release` if you build in Release mode).

    # **Install the template from the generated NuGet package**  
    dotnet new install ./LCSoft.DotNetGenesisTemplates/bin/Debug/LCSoft.DotNetGenesis.Templates.<version>.nupkg
    ```

3.  **Install from NuGet (Recommended once published):**
    *Replace `LCSoft.DotNetGenesis` with your actual NuGet package ID.*
    ```bash
    dotnet new --install LCSoft.DotNetGenesis
    ```

You can verify the installation by running `dotnet new --list` and searching for your template short names (e.g., `lc-basic-api`, `lc-basic-web`).

### 2. List Available Templates

```bash
dotnet new list
```

### 3. Usage

Once installed, you can create a new project using the templates.

```bash
# Example: Create a basic api project
dotnet new lc-basic-api --company MyCompany --projectName MyProject -o ./MyApi
# Example: Create a basic web project
dotnet new lc-basic-web --company MyCompany --projectName MyProject -o ./MyWebApp
```

#### Template Parameters
| Parameter       | Description                             | Default Value      |
|-----------------|-----------------------------------------|--------------------|
| `--company`     | Company or organization name            | `MyCompany`        |
| `--projectName` | Name of the project                     | `MyProject`        |
| `-o`            | Output directory for the new project    | Current Directory  |

- Company and ProjectName will be used to set namespaces and project names accordingly.
    This is important for maintaining consistency across the solution.
- Output directory (`-o`) specifies where to create the new project.

## Template Details

### LC-Basic-Api

This template will allow clean architecture and organization of the project, without strict enforcement of rules, will allow the code be highly maintainable, clean and testable.

- Project Structure:
    - YourCompany.YourProjectName.Core: Shared models, interfaces, and domain rules (anemic or rich, as needed).
    - YourCompany.YourProjectName.Application: Application Services, DTOs, Use Cases, Interfaces for Infrastructure.
    - YourCompany.YourProjectName.Infrastructure: Data Access, External Service Clients, Implementations of Infrastructure Interfaces.
    - YourCompany.YourProjectName.Api: Thin controllers/endpoints (minimal logic).

#### Project Structure Overview
```cpp
YourProjectName/
├── src/
│   ├── Api/                   // Thin controllers/endpoints (minimal logic).
│   │   ├── Models/            // Request/Response models
│   │   ├── Apidoc/            // Api documentation (Swagger/OpenAPI) extensions
│   │   ├── Configuration/     // Configuration (Dependency Injection) extensions
│   │   ├── Filters/           // Filter extensions (Exception handling, etc.)
│   │   ├── Mvc/               // MVC related extensions (Controllers, Views, etc.)
│   │   └── Mapping/           // Mapping extensions
│   ├── Application/           // Use cases/services—orchestrates workflows but defers to Core for rules.
│   │   ├── Dto/               // Data transfer objects
│   │   ├── Configuration/     // Configuration (Dependency Injection) extensions 
│   │   ├── Extensions/        // Other relevant extensions
│   │   ├── Interfaces/        // Interface for the AppServices
│   │   ├── AppServices/       // Use cases services and processors
│   │   ├── Healthcheck/       // Health check services and processors
│   │   ├── Logging/           // Logging services and processors
│   │   ├── Middleware/        // Middleware extensions
│   │   └── Mapping/           // Mapping extensions
│   ├── Core/                  // Shared models, interfaces, and domain rules (anemic or rich, as needed).
│   │   ├── Entities/          // Aggregate roots and nested entities
│   │   └── Services/          // Core services for complex business logic (stateless operations)
│   └── Infrastructure/        // Persistence, third-party services, repository implementations
│       ├── Repository/        // Repository pattern implementation
│       ├── Configuration/     // Configuration (Dependency Injection) extensions 
│       ├── Interfaces/        // Interfaces for infrastructure services
│       ├── ExternalServices/  // External services 
│       └── Mapping/           // Mapping extensions
├── tests/
│   ├── UnitTests/             // Core and Application layer tests
│   └── IntegrationTests/      // End-to-end, persistence and API-level testing
└── docs/                      // Entities diagrams,glossary (optional)
```

- Principles:
    - Separation of Concerns
    - Encourages rich domain modeling
    - Well-suited for small-to-medium but, evolving business domains.

- Key Concepts:
    - Separate concerns, but allow cross-layer communication when pragmatic.
    - Logic is decoupled from frameworks for easy unit/integration testing.
    - Prefer clear, readable code over "magic" or excessive abstraction.

### LC-Basic-Web

This template will allow clean architecture and organization of the project, without strict enforcement of rules, will allow the code be highly maintainable, clean and testable.

- Project Structure:
    - YourCompany.YourProjectName.Core: Shared models, interfaces, and domain rules (anemic or rich, as needed).
    - YourCompany.YourProjectName.Application: Application Services, DTOs, Use Cases, Interfaces for Infrastructure.
    - YourCompany.YourProjectName.Infrastructure: Data Access, External Service Clients, Implementations of Infrastructure Interfaces.
    - YourCompany.YourProjectName.Web: Thin controllers/endpoints (minimal logic).

#### Project Structure Overview
```cpp
YourProjectName/
├── src/
│   ├── Web/                   // Thin controllers/endpoints (minimal logic).
│   │   ├── Models/            // Request/Response models
│   │   ├── Controllers/       // Controllers folder
│   │   ├── Configuration/     // Configuration (Dependency Injection) extensions
│   │   ├── Filters/           // Filter extensions (Exception handling, etc.)
│   │   ├── Views/             // Views folder
│   │   └── Mapping/           // Mapping extensions
│   ├── Application/           // Use cases/services—orchestrates workflows but defers to Core for rules.
│   │   ├── Dto/               // Data transfer objects
│   │   ├── Configuration/     // Configuration (Dependency Injection) extensions 
│   │   ├── Extensions/        // Other relevant extensions
│   │   ├── Interfaces/        // Interface for the AppServices
│   │   ├── AppServices/       // Use cases services and processors
│   │   ├── Healthcheck/       // Health check services and processors
│   │   ├── Logging/           // Logging services and processors
│   │   ├── Middleware/        // Middleware extensions
│   │   └── Mapping/           // Mapping extensions
│   ├── Core/                  // Shared models, interfaces, and domain rules (anemic or rich, as needed).
│   │   ├── Entities/          // Aggregate roots and nested entities
│   │   └── Services/          // Core services for complex business logic (stateless operations)
│   └── Infrastructure/        // Persistence, third-party services, repository implementations
│       ├── Repository/        // Repository pattern implementation
│       ├── Configuration/     // Configuration (Dependency Injection) extensions 
│       ├── Interfaces/        // Interfaces for infrastructure services
│       ├── ExternalServices/  // External services 
│       └── Mapping/           // Mapping extensions
├── tests/
│   └── UnitTests/             // Core and Application layer tests
└── docs/                      // Entities diagrams,glossary (optional)
```

- Principles:
    - Separation of Concerns
    - Encourages rich domain modeling
    - Well-suited for small-to-medium but, evolving business domains.

- Key Concepts:
    - Separate concerns, but allow cross-layer communication when pragmatic.
    - Logic is decoupled from frameworks for easy unit/integration testing.
    - Prefer clear, readable code over "magic" or excessive abstraction.


## References
 
- [Clean Architecture by Robert C. Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microsoft Architecture Patterns](https://docs.microsoft.com/en-us/dotnet/architecture/)
- [Luigi's Pragmatic Clean Architecture](docs/LuigisPragmaticCleanArchitecture.md)
