1. **DDD Basic Stuff (`lc-ddd-basic`)**

Each template is accessible via `dotnet new` and includes comprehensive project structure and example implementations:

- **lc-ddd-basic** – DDD-first template with aggregates, value objects, repositories, and bounded contexts


```bash
# Example: Create a basic DDD project
dotnet new lc-ddd-basic -n MyDDDApp -o ./MyDDDApp
```

--use-ddd - Enable Domain-Driven Design patterns
--use-cqrs - Implement CQRS pattern
--use-es - Add Event Sourcing infrastructure
--db-provider - Specify database provider (SqlServer, Postgres, Sqlite, InMemory)
--add-tests - Include unit and integration test projects
--add-docker - Include Docker support

```bash
dotnet new lc-ddd-basic -n MyDDDProject --use-ddd --db-provider Postgres --add-tests
```


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

- Based on tactical DDD patterns (entities, VOs, aggregates, etc.)
- Encourages rich domain modeling
- Well-suited for complex, evolving business domains

Key Concepts:
- Clear separation of Domain Model and Application Logic.
- Designed for strategic design with Bounded Contexts and ubiquitous language.
- Emphasis on rich domain modeling, not just anemic data models.
- Implements tactical Domain-Driven Design (DDD) patterns.
- Rich domain model with aggregates, value objects, and events.
- Application layer is an orchestrator — it delegates to the domain model.
- Suited for complex, evolving business rules and contexts.