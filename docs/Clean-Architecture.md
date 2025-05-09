1.  **Clean Architecture (`lc-clean`)**:
    * Based on Robert C. Martin's Clean Architecture principles.
    * Layers: Domain, Application, Infrastructure, Web API/UI.
    * Enforces the Dependency Rule (dependencies point inwards).
    * Suitable for complex applications requiring high maintainability and testability.

### 🧼 Clean Architecture (cleanarch)
Project Structure:

YourProjectName.Domain: Entities, Aggregates, Value Objects, Interfaces (Repositories, Domain Services), Domain Events.

YourProjectName.Application: Application Services, DTOs, Commands, Queries, Interfaces (Infrastructure), Business Logic orchestration.

YourProjectName.Infrastructure: Implementation of interfaces defined in Application/Domain (Repositories, External Services, Caching, etc.). Depends on specific technologies (e.g., Entity Framework Core, Dapper).

YourProjectName.Api (or YourProjectName.Web): ASP.NET Core project (Web API, MVC, Razor Pages), Dependency Injection setup.

#### Project Structure Overview
```cpp
MyProject/
├── src/
│   ├── Api/               // ASP.NET Core Web API entry point (controllers, filters, etc.)
│   ├── Application/       // Application layer: use cases, commands, queries, DTOs, interfaces
│   ├── Domain/            // Core domain model: entities, value objects, interfaces, enums, business logic
│   └── Infrastructure/    // External concerns: data access (EF Core), file I/O, integrations, services, repositories
├── tests/
│   ├── UnitTests/             // Unit tests for Domain and Application logic
│   └── IntegrationTests/      // Tests involving Infrastructure or API layers
└── docs/                      // Architecture guides, use case flows, diagrams (optional)
```

Principles:
Enforces separation of concerns via concentric rings.
Domain and Application layers are independent of external tech (UI, DB, frameworks).
Follows Uncle Bob’s Clean Architecture principles.

Key Concepts:

Layered architecture with inward dependency flow — outer layers depend on inner layers.
Independent domain model — the Domain layer is free of external dependencies.
Use cases in Application layer — orchestrate business logic and call Domain services.
Infrastructure is replaceable — database, logging, etc., can be swapped without affecting core logic.
Inspired by Uncle Bob's Clean Architecture and SOLID principles.
