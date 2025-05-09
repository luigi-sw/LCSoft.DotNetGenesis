### 📚 Vertical Slices Architecture

#### Project Structure Overview
```cpp
MyVerticalApp/
├── src/
│   ├── Api/                      // ASP.NET Core API (Startup, Program, middleware, endpoints)
│   ├── Features/
│   │   └── FeatureN/             // Command + Handler + Endpoint in a single file or folder
│   │      ├── CreateFeatureN.cs    
│   │      └── GetFeatureN.cs    
│   ├── Domain/                   // Shared domain objects (entities, value objects, enums)
│   ├── Infrastructure/           // Persistence, external services, integrations
│   └── Common/                   // Base classes, shared interfaces, helpers, response wrappers
├── tests/
│   ├── UnitTests/                // Tests per vertical slice (e.g., Features/Orders/CreateOrderTests.cs)
│   └── IntegrationTests/         // API tests, DB-backed tests for slices
└── docs/                         // Architectural decisions, slice design guide, patterns
```

🔑 Key Concepts
Features are organized by vertical slices (not by layers like Controllers/Services/Repos).
Each slice contains everything it needs: request model, handler, endpoint, validation.
Encourages high cohesion and low coupling — changes are localized to a slice.
Scales well with CQRS (Command/Query separation) and MediatR.
Reduces ceremony: minimal controllers, fewer cross-cutting concerns.
Can coexist with DDD and Onion/Clean principles internally, but slice is the unit of organization.

📦 Ideal Use Cases
Microservices or small/medium monoliths that require high modularity.
Systems where bounded features evolve independently.
Teams practicing feature-first development.