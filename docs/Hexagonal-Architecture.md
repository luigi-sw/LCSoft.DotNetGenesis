2.  **Hexagonal Architecture (`lc-hex`)**:
    * Also known as Ports & Adapters.
    * Focuses on isolating the application core (business logic) from external concerns (UI, database, third-party services).
    * Uses Ports (interfaces defined by the core) and Adapters (implementations of ports for specific technologies).
    * Excellent for applications needing flexibility in technology choices for infrastructure components.

### 🎯 Hexagonal Architecture (hexarch)
Project Structure:

YourProjectName.Core.Application: Application Services, Use Cases, Ports (interfaces defined by the core).

YourProjectName.Core.Domain: Entities, Aggregates, Value Objects, Domain Logic.

YourProjectName.Adapter.Persistence: Infrastructure Adapters for data persistence (e.g., EF Core implementation of repository ports).

YourProjectName.Adapter.WebApi: Driving Adapter for the Web API interface.

(Other Adapters as needed, e.g., Adapter.Messaging)

#### Project Structure Overview
```cpp
MyHexProject/
├── src/
│   ├── Adapters/
│   │   ├── Inbound/           // Adapters that receive input (e.g., API controllers, CLI)
│   │   └── Outbound/          // Adapters for output (e.g., DB access, file storage, APIs)
│   ├── Application/           // Application services, use cases, DTOs, orchestrates Ports
│   ├── Domain/                // Core domain model: entities, value objects, interfaces
│   └── Ports/
│       ├── Inbound/           // Interfaces that inbound adapters implement
│       └── Outbound/          // Interfaces that outbound adapters implement
├── tests/
│   ├── UnitTests/             // Focus on Domain and Application logic
│   └── IntegrationTests/      // End-to-end flows using real adapters
└── docs/                      // Diagrams explaining ports/adapters flow, decisions
```

Principles:
Core logic is isolated from external systems.
Communication happens via well-defined ports.
Easily testable and framework-agnostic.

Key Concepts:

Focuses on separation between the core logic and the outside world.
Ports define the core’s expectations; adapters implement them.
Inversion of control — the application drives external interactions, not vice versa.
Useful when integrating with many interfaces (e.g., APIs, databases, queues).
Promotes testability and technology neutrality.