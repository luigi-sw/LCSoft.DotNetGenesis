
3.  **Onion Architecture (`lc-onion`)**:
    * Similar to Clean and Hexagonal, emphasizing the Domain at the center.
    * Layers arranged in concentric circles, with dependencies flowing towards the center.
    * Core (Domain Model, Domain Services) -> Application Services -> Infrastructure/UI.
    * Promotes loose coupling and high cohesion.

### 🧅 Onion Architecture (onionarch)
Project Structure:

YourProjectName.Core: Domain Entities, Aggregates, Domain Services, Repository Interfaces.

YourProjectName.Application: Application Services, DTOs, Use Cases, Interfaces for Infrastructure.

YourProjectName.Infrastructure: Data Access, External Service Clients, Implementations of Infrastructure Interfaces.

YourProjectName.Api (or YourProjectName.Web): Presentation Layer, Dependency Injection.

#### Project Structure Overview
```cpp
MyOnionApp/
├── src/
│   ├── Presentation/          // Web/UI Layer (controllers, HTTP endpoints, API setup, controllers, filters, etc.)
│   ├── Application/           // Application services, business use cases, interfaces, DTOs
│   ├── Domain/                // Core pure business logic (entities, value objects, enums, interfaces)
│   └── Infrastructure/        // External concerns: EF Core, third-party services, implementations, IO
├── tests/
│   ├── UnitTests/             // Unit tests for Application and Domain layers
│   └── IntegrationTests/      // Integration tests for Infrastructure and Web layers
├── build/                     // Build scripts or CI/CD definitions (optional)
└── docs/                      // Architecture diagrams, decision records, guides (optional)
```

Principles:

Dependencies point inward (outer layers depend on inner layers).
Promotes testability and maintainability.
Application core is technology-agnostic.


Key Concepts:

Domain is the core of the architecture — everything depends on it - no dependencies.
Uses inversion of dependencies to keep core logic decoupled.
Emphasizes testable, maintainable code.
Similar to Clean Architecture, but often simpler and less opinionated about use cases.
Application references Domain, but not Infrastructure or Presentation.
Infrastructure and Presentation are outer rings that depend on inner rings.
