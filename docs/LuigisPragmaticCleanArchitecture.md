---
Title: Pragmatic Clean Architecture for .NET C# Applications
Version: 1.0
Last Updated: 2025-11-01
Author: Luigi C. Filho
License: cc-by-nc-nd-4.0
---

# Pragmatic Clean Architecture for .NET C# Applications

## Executive Summary

This document presents a pragmatic clean architecture approach for .NET C# applications that emphasizes separation of concerns, maintainability, and flexibility while avoiding over-engineering. The architecture is structured into four distinct layers with clearly defined dependencies and responsibilities.

## Architecture Overview

### Dependency Graph

```
┌─────────────┐
│  Web/API    │
└──────┬──────┘
       │
       ▼
┌─────────────┐
│ Application │
└──┬───────┬──┘
   │       │
   ▼       ▼
┌──────┐ ┌────────────────┐
│ Core │ │ Infrastructure │
└──────┘ └────────────────┘
```

### Layer Dependencies

| Layer          | References             | Referenced By  |
|----------------|------------------------|----------------|
| Core           | None                   | Application    |
| Infrastructure | None                   | Application    |
| Application    | Core, Infrastructure   | Web/API        |
| Web/API        | Application            | None           |

## Layer Definitions

### 1. Core Layer

**Dependencies:** None (Pure domain logic)

**Purpose:** Contains the essential business logic and domain model that represents the heart of the application. This layer is framework-agnostic and should remain stable regardless of infrastructure or presentation changes.

#### Responsibilities

- **Entities:** Business objects that contain both data and behavior
- **Value Objects:** Immutable objects defined by their attributes rather than identity
- **Domain Events:** Events that represent significant occurrences in the domain
- **Business Rules:** Pure business logic and validation rules
- **Domain Exceptions:** Business-specific exceptions
- **Interfaces (Abstractions):** Repository interfaces, service contracts needed by the domain
- **Enumerations:** Domain-specific enums and constants

#### Characteristics

- **Zero Dependencies:** No references to external libraries or other layers
- **Framework-Agnostic:** No dependency on Entity Framework, ASP.NET, or any other framework
- **Stable:** Changes infrequently as business rules are relatively stable
- **Testable:** Easily unit tested without mocking infrastructure

#### Example Structure

```
Core/
├── Entities/
│   ├── Customer.cs
│   ├── Order.cs
│   └── Product.cs
├── ValueObjects/
│   ├── Money.cs
│   ├── Address.cs
│   └── Email.cs
├── Events/
│   ├── OrderPlacedEvent.cs
│   └── CustomerRegisteredEvent.cs
├── Exceptions/
│   ├── InvalidOrderException.cs
│   └── DomainException.cs
├── Interfaces/
│   ├── IOrderRepository.cs
│   └── ICustomerRepository.cs
└── Enums/
    └── OrderStatus.cs
```

### 2. Infrastructure Layer

**Dependencies:** None (Self-contained implementations)

**Purpose:** Provides concrete implementations of technical concerns and external dependencies. This layer isolates the application from specific technology choices.

#### Responsibilities

- **Database Access:** Entity Framework DbContext, repository implementations, data migrations
- **Caching:** Redis, in-memory cache implementations
- **External Services:** Third-party API clients, payment gateways, email services
- **File Systems:** File storage, blob storage implementations
- **Logging:** Logging implementations and configurations
- **Message Queues:** RabbitMQ, Azure Service Bus implementations
- **Serialization:** JSON, XML serialization utilities
- **Compression:** Data compression utilities
- **Cryptography:** Encryption and hashing implementations

#### Characteristics

- **Technology-Specific:** Contains framework and library dependencies
- **Replaceable:** Implementations can be swapped without affecting business logic
- **Configuration-Driven:** Behavior controlled through configuration
- **Independent:** Does not reference Core or Application layers

#### Example Structure

```
Infrastructure/
├── Data/
│   ├── ApplicationDbContext.cs
│   ├── Repositories/
│   │   ├── OrderRepository.cs
│   │   └── CustomerRepository.cs
│   └── Migrations/
├── Caching/
│   ├── RedisCacheService.cs
│   └── MemoryCacheService.cs
├── ExternalServices/
│   ├── StripePaymentService.cs
│   └── SendGridEmailService.cs
├── Logging/
│   └── SerilogLogger.cs
├── Storage/
│   └── AzureBlobStorageService.cs
└── Messaging/
    └── RabbitMQMessageBus.cs
```

### 3. Application Layer

**Dependencies:** Core, Infrastructure

**Purpose:** Orchestrates the flow of data and coordinates application behavior. This layer contains cross-cutting concerns and application-specific logic that is reusable across different presentation layers.

#### Responsibilities

- **Use Cases / Application Services:** Orchestrate domain operations
- **DTOs (Data Transfer Objects):** Define data contracts for external communication
- **Mapping:** Map between domain entities and DTOs
- **Validation:** Input validation using FluentValidation or similar
- **Authentication & Authorization:** User identity, permissions, policies
- **Health Checks:** Application health monitoring endpoints
- **Cross-Cutting Concerns:**
  - Transaction management
  - Auditing
  - Exception handling
  - Caching strategies
  - Event dispatching
- **Application Events:** Application-level events distinct from domain events
- **Interfaces:** Define abstractions for presentation layer needs

#### Characteristics

- **Presentation-Agnostic:** Not tied to any specific UI technology
- **Reusable:** Same application layer can serve Web, API, Console, or Desktop applications
- **Orchestration Focus:** Coordinates between Core and Infrastructure
- **Cross-Cutting:** Contains logic shared across all presentation types

#### Example Structure

```
Application/
├── UseCases/
│   ├── Orders/
│   │   ├── CreateOrder/
│   │   │   ├── CreateOrderCommand.cs
│   │   │   ├── CreateOrderCommandHandler.cs
│   │   │   └── CreateOrderValidator.cs
│   │   └── GetOrderDetails/
│   │       ├── GetOrderDetailsQuery.cs
│   │       └── GetOrderDetailsQueryHandler.cs
├── DTOs/
│   ├── OrderDto.cs
│   └── CustomerDto.cs
├── Mapping/
│   └── AutoMapperProfile.cs
├── Interfaces/
│   ├── ICurrentUserService.cs
│   └── INotificationService.cs
├── Security/
│   ├── AuthorizationPolicies.cs
│   └── PermissionRequirement.cs
├── HealthChecks/
│   ├── DatabaseHealthCheck.cs
│   └── ExternalServiceHealthCheck.cs
├── Behaviors/
│   ├── ValidationBehavior.cs
│   ├── LoggingBehavior.cs
│   └── TransactionBehavior.cs
└── Exceptions/
    └── ApplicationException.cs
```

### 4. Web/API Layer

**Dependencies:** Application

**Purpose:** Provides specific presentation interfaces. Each presentation type (Web MVC, Web API, Blazor, gRPC) should have its own project that references the Application layer.

#### Responsibilities

- **Controllers / Endpoints:** HTTP request handling
- **Middleware:** Request/response pipeline components
- **Filters:** Action filters, exception filters, authorization filters
- **View Models:** Presentation-specific data models
- **Views / Pages:** UI markup (Razor, Blazor)
- **API Documentation:** Swagger/OpenAPI specifications
- **Request/Response Models:** API contracts specific to this presentation
- **Dependency Injection Configuration:** Wire up services for this presentation
- **Startup Configuration:** Application initialization specific to this host

#### Characteristics

- **Presentation-Specific:** Contains code specific to Web or API
- **Thin Layer:** Minimal logic, primarily routing and model binding
- **Multiple Implementations:** Can have Web.MVC and Web.API projects using the same Application layer
- **Entry Point:** Application startup and configuration

#### Example Structure

**For Web API:**
```
Web.API/
├── Controllers/
│   ├── OrdersController.cs
│   └── CustomersController.cs
├── Middleware/
│   ├── ExceptionHandlingMiddleware.cs
│   └── RequestLoggingMiddleware.cs
├── Filters/
│   └── ValidateModelAttribute.cs
├── Models/
│   ├── Requests/
│   │   └── CreateOrderRequest.cs
│   └── Responses/
│       └── OrderResponse.cs
├── Configuration/
│   ├── DependencyInjection.cs
│   └── SwaggerConfiguration.cs
└── Program.cs
```

**For Web MVC:**
```
Web.MVC/
├── Controllers/
│   ├── OrdersController.cs
│   └── CustomersController.cs
├── ViewModels/
│   ├── OrderViewModel.cs
│   └── CustomerViewModel.cs
├── Views/
│   ├── Orders/
│   │   ├── Create.cshtml
│   │   └── Details.cshtml
│   └── Shared/
├── Middleware/
├── Configuration/
└── Program.cs
```

## Architectural Principles

### 1. Dependency Rule

Dependencies point inward. Outer layers depend on inner layers, never the reverse.

- **Core** has no dependencies
- **Infrastructure** has no dependencies on application code
- **Application** depends on Core and Infrastructure
- **Web/API** depends only on Application

### 2. Interface Segregation

Infrastructure implementations are hidden behind interfaces defined in Core or Application layers, enabling:
- Testability through mocking
- Flexibility to swap implementations
- Adherence to SOLID principles

### 3. Single Responsibility

Each layer has a clear, focused responsibility:
- **Core:** Business logic
- **Infrastructure:** Technical implementation
- **Application:** Orchestration and cross-cutting concerns
- **Web/API:** Presentation and user interaction

### 4. Framework Independence

The Core layer is completely independent of frameworks, making the domain logic:
- Portable across different .NET applications
- Testable without UI or database
- Stable and long-lived

## Benefits

### Maintainability

- **Clear Separation:** Each layer has distinct responsibilities
- **Isolated Changes:** Modifications in one layer rarely affect others
- **Easier Onboarding:** New developers can understand the structure quickly

### Testability

- **Unit Testing:** Core business logic is easily unit tested
- **Integration Testing:** Infrastructure can be tested independently
- **Mocking:** Dependencies are injected through interfaces

### Flexibility

- **Multiple Presentations:** Same business logic serves Web, API, Console, or Desktop
- **Technology Changes:** Swap databases, caching, or external services without affecting business logic
- **Scaling:** Different layers can be scaled independently if needed

### Longevity

- **Stable Core:** Business rules remain stable over time
- **Technology Evolution:** Update frameworks without rewriting business logic
- **Future-Proof:** Architecture adapts to new requirements

## Implementation Guidelines

### 1. Project Organization

```
Solution/
├── src/
│   ├── Solution.Core/
│   ├── Solution.Infrastructure/
│   ├── Solution.Application/
│   ├── Solution.Web.API/
│   └── Solution.Web.MVC/
├── tests/
│   ├── Solution.UnitTests/
│   └── Solution.IntegrationTests/
└── Solution.sln
```

### 2. Dependency Injection Setup

**In Web/API Layer (Program.cs):**
```csharp
// Register Application Layer services
builder.Services.AddApplicationServices();

// Register Web-specific services
builder.Services.AddWebServices();
```

**In Application Layer:**
```csharp
public static IServiceCollection AddApplicationServices(this IServiceCollection services)
{
    // Register Infrastructure services
    builder.Services.AddInfrastructureServices(builder.Configuration);

    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    return services;
}
```

**In Infrastructure Layer:**
```csharp
public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services, 
    IConfiguration configuration)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped<IOrderRepository, OrderRepository>();
    
    services.AddStackExchangeRedisCache(options =>
        options.Configuration = configuration.GetConnectionString("Redis"));
    
    return services;
}
```

### 3. Communication Patterns

**Use CQRS (Command Query Responsibility Segregation) in Application Layer:**

- **Commands:** Operations that change state
- **Queries:** Operations that read data

**Leverage MediatR for decoupled communication:**

```csharp
// In Controller
public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
{
    var command = _mapper.Map<CreateOrderCommand>(request);
    var result = await _mediator.Send(command);
    return Ok(result);
}
```

### 4. Error Handling Strategy

- **Domain Exceptions:** Defined in Core, thrown when business rules are violated
- **Application Exceptions:** Defined in Application, thrown during orchestration failures
- **Infrastructure Exceptions:** Caught and wrapped in Application layer
- **Presentation Handling:** Global exception middleware in Web/API layer

## Common Pitfalls to Avoid

### 1. Anemic Domain Model

**Problem:** Entities become just data containers with no behavior.

**Solution:** Encapsulate business logic within entities. Use value objects and domain events.

### 2. Breaking the Dependency Rule

**Problem:** Core references Infrastructure or Application.

**Solution:** Use interfaces and dependency inversion. Core defines interfaces, Infrastructure implements them.

### 3. Fat Application Layer

**Problem:** Application layer contains business logic that belongs in Core.

**Solution:** Keep Application layer focused on orchestration. Move business rules to Core.

### 4. Duplicate Presentations

**Problem:** Creating separate Application logic for Web and API.

**Solution:** Share the same Application layer. Only the presentation differs.

### 5. Infrastructure Leakage

**Problem:** Infrastructure details (EF entities, DTOs) leak into Core.

**Solution:** Keep infrastructure implementations completely separate. Core defines pure domain entities.

## Comparison with Other Architectural Patterns

This section compares this pragmatic clean architecture approach with other popular architectural patterns to highlight the key differences and advantages.

### This Pragmatic Approach vs. Classic Clean Architecture (Uncle Bob)

The classic Clean Architecture by Robert C. Martin follows a strict dependency rule where all dependencies point inward to the domain core. **This architecture differs in a fundamental way:**

| Aspect | Classic Clean Architecture | This Pragmatic Approach |
|--------|---------------------------|------------------------|
| **Infrastructure Dependencies** | Infrastructure **depends on Core** to implement domain interfaces | Infrastructure has **NO dependencies** at all |
| **Interface Location** | Interfaces defined in Core, implemented in Infrastructure | Interfaces can be in Core or Application based on need |
| **Application Layer** | Application depends only on Core (abstractions) | Application depends on **both Core and Infrastructure** |
| **Dependency Inversion** | Strictly enforced everywhere | Pragmatically applied where it adds value |
| **Wiring Complexity** | Requires extensive DI configuration | Simpler, more direct wiring |
| **Learning Curve** | Steeper, more abstract | Gentler, more intuitive |

**Key Difference Explained:**

In classic Clean Architecture:
```
Core (defines IRepository interface)
  ↑
Infrastructure (implements IRepository) → depends on Core
  ↑
Application (uses IRepository abstraction) → depends on Core
  ↑
Web/Api → depends on Application
```

In this pragmatic approach:
```
Web/API
└── Application → depends on Core + Infrastructure
     ├── Infrastructure (implements repositories, external services) → NO dependencies
     └── Core (pure domain, defines IRepository interface) 
```

**Advantages of This Approach:**
- **Simpler Mental Model:** Infrastructure doesn't need to know about Core
- **Less Ceremony:** Reduced interface proliferation
- **Faster Development:** Direct references when abstraction doesn't add value
- **Easier Testing:** Still testable with mocking at Application layer
- **Flexibility:** Can use dependency inversion where it matters most

**When Classic Clean Architecture Wins:**
- Extremely large, complex domains requiring maximum isolation
- Projects with frequently changing infrastructure technologies
- Teams that strictly follow DDD and prefer maximum abstraction

### This Pragmatic Approach vs. Traditional N-Tier Architecture

N-Tier (or N-Layer) is one of the most common architectural patterns, but it has significant limitations compared to this approach.

| Aspect | Traditional N-Tier | This Pragmatic Clean Architecture |
|--------|-------------------|----------------------------------|
| **Layers** | Presentation → Business Logic → Data Access | Web/API → Application → Core + Infrastructure |
| **Dependencies** | Strict top-down cascade | Inward to Core, Application orchestrates Infrastructure |
| **Business Logic Location** | Often mixed with data access concerns | Pure domain logic in Core, isolated from infrastructure |
| **Infrastructure** | Embedded in Data Access Layer | Separate, independent layer |
| **Testability** | Difficult, requires database for testing | Easy, Core is completely isolated |
| **Database Coupling** | Business logic often coupled to ORM/DB | Core has zero knowledge of databases |
| **Multiple Presentations** | Difficult, often duplicates logic | Easy, share same Application layer |
| **Technology Swapping** | Painful, affects business logic | Simple, Infrastructure is isolated |

**Example of the Problem with N-Tier:**

```csharp
// Traditional N-Tier: Business logic mixed with data access
public class OrderService // Business Logic Layer
{
    private readonly SqlConnection _connection;
    
    public void ProcessOrder(int orderId)
    {
        // Business logic mixed with SQL
        var cmd = new SqlCommand("SELECT * FROM Orders WHERE Id = @id", _connection);
        // Domain rules scattered across DAL queries
        // Hard to test without database
        // Violates single responsibility
    }
}
```

**This Architecture:**
```csharp
// Core: Pure business logic
public class Order // Core Layer
{
    public void Process()
    {
        // Pure domain logic, no infrastructure
        // Easily unit tested
    }
}

// Infrastructure: Separate persistence concern
public class OrderRepository // Infrastructure Layer
{
    // Pure data access, no business logic
}
```

### This Pragmatic Approach vs. Onion Architecture

Onion Architecture inspired many clean architecture variants, but this approach offers practical simplifications.

| Aspect | Onion Architecture | This Pragmatic Clean Architecture |
|--------|-------------------|----------------------------------|
| **Structure** | Multiple concentric rings | Four distinct layers |
| **Core** | Domain Model + Domain Services | Entities, Value Objects, Business Rules |
| **Dependencies** | All point inward through rings | All point to Core, Application bridges Infrastructure |
| **Infrastructure** | Part of outer ring with UI | **Separate independent layer** |
| **Application Services** | In outer rings | Dedicated Application layer |
| **Complexity** | Can be over-engineered with too many rings | **Pragmatic four-layer structure** |
| **Learning Curve** | Conceptually challenging | More intuitive for .NET developers |

**Key Innovation: Infrastructure Independence**

Unlike Onion Architecture where Infrastructure is part of the outer shell and may depend on inner rings, **this architecture makes Infrastructure completely independent**, which:
- Simplifies understanding and implementation
- Reduces coupling even further
- Makes Infrastructure truly plug-and-play
- Allows parallel development of Infrastructure and Core

### This Pragmatic Approach vs. Vertical Slice Architecture

Vertical Slice Architecture takes a radically different approach by organizing code by features rather than technical layers.

| Aspect | Vertical Slice Architecture | This Pragmatic Clean Architecture |
|--------|---------------------------|----------------------------------|
| **Organization** | By feature/use case (vertical slices) | By technical responsibility (horizontal layers) |
| **Code Location** | All code for a feature in one place | Separated across layers by concern |
| **Coupling** | Features are isolated, but may duplicate logic | Shared domain logic in Core |
| **Reusability** | Lower, each slice is self-contained | Higher, Core and Application are shared |
| **Complexity** | Lower per slice, higher overall | Higher structure, lower duplication |
| **Best For** | CRUD-heavy apps, microservices | Complex domain logic, shared business rules |
| **Team Scaling** | Excellent, teams own complete slices | Good, teams own layers |
| **Cross-Cutting Concerns** | Challenging to implement consistently | Natural fit in Application layer |

**Comparison Example:**

**Vertical Slice for "Create Order":**
```
Features/
  Orders/
    CreateOrder/
      CreateOrderCommand.cs      // Request
      CreateOrderHandler.cs      // Business logic + data access
      CreateOrderValidator.cs    // Validation
      CreateOrderController.cs   // API endpoint
      // Everything for this feature in one folder
```

**This Architecture for "Create Order":**
```
Core/
  Entities/Order.cs              // Domain entity (reused by all features)
Infrastructure/
  Data/OrderRepository.cs        // Data access (reused by all features)
Application/
  UseCases/Orders/CreateOrder/   // Use case orchestration
    CreateOrderCommand.cs
    CreateOrderHandler.cs
    CreateOrderValidator.cs
Web.API/
  Controllers/OrdersController.cs // API endpoint
```

**When to Choose Vertical Slices:**
- CRUD-heavy applications with simple business logic
- Microservices with independent bounded contexts
- Rapid prototyping and iteration
- Teams prefer autonomy over shared abstractions

**When This Architecture Wins:**
- Rich domain models with complex business rules
- Significant shared logic across features
- Need for consistent domain language (DDD)
- Multiple presentation layers sharing the same logic

### This Pragmatic Approach vs. Hexagonal Architecture (Ports and Adapters)

Hexagonal Architecture (also known as Ports and Adapters) focuses on isolating the application core from external concerns through ports and adapters.

| Aspect | Hexagonal Architecture | This Pragmatic Clean Architecture |
|--------|----------------------|----------------------------------|
| **Core Concept** | Ports (interfaces) + Adapters (implementations) | Layers with clear dependencies |
| **Structure** | Hexagon (core) surrounded by adapters | Four-layer hierarchy |
| **Terminology** | Ports, Adapters, Hexagon | Core, Infrastructure, Application, Web/API |
| **Dependencies** | Adapters depend on Ports (in core) | Infrastructure is independent, Application bridges |
| **Complexity** | Can be conceptually abstract | More concrete and familiar to .NET developers |
| **Symmetry** | Treats input/output symmetrically | Explicit presentation layer |
| **Best For** | Systems with many external integrations | Balanced applications with clear layering |

**Conceptual Mapping:**

```
Hexagonal Architecture          →  This Architecture
────────────────────────────────────────────────────
Hexagon (Application Core)       →  Core Layer
Primary Ports                    →  Interfaces in Core
Secondary Ports                  →  Interfaces in Application
Adapters (Driving)              →  Web/API Layer
Adapters (Driven)               →  Infrastructure Layer
Application Services            →  Application Layer
```

**Key Difference:**
- Hexagonal emphasizes **ports and adapters metaphor**
- This architecture emphasizes **layered separation with pragmatic dependencies**
- Hexagonal requires all external dependencies go through ports (interfaces)
- This architecture allows direct Infrastructure usage in Application when practical

### Architecture Comparison Matrix

| Architecture | Complexity | Testability | Flexibility | Learning Curve | Best Use Case |
|--------------|-----------|-------------|-------------|----------------|---------------|
| **This Pragmatic Clean** | Medium | High | High | Medium | Balanced applications with domain logic |
| **Classic Clean** | High | Very High | Very High | Steep | Complex domains, strict DDD |
| **N-Tier** | Low | Low | Low | Easy | Simple CRUD applications |
| **Onion** | High | High | High | Steep | DDD applications |
| **Vertical Slice** | Low-Medium | Medium | Medium | Easy | CRUD-heavy, microservices |
| **Hexagonal** | High | High | Very High | Steep | Integration-heavy systems |

### Summary: Why This Pragmatic Approach?

This architecture strikes a **practical balance** between purity and productivity:

- **Simpler than Classic Clean Architecture** - Infrastructure doesn't depend on Core, reducing abstraction overhead
- **More structured than N-Tier** - Clear separation of domain logic from infrastructure
- **More intuitive than Onion/Hexagonal** - Familiar layered approach with clear responsibilities
- **More reusable than Vertical Slice** - Shared domain logic and cross-cutting concerns
- **Production-proven** - Battle-tested pattern that works for real-world .NET applications

**The Golden Rule:**
> "Make things as simple as possible, but not simpler." - Albert Einstein

This architecture applies just enough structure to reap the benefits of clean architecture principles without the ceremony and complexity that can slow down development teams.

## Conclusion

This clean architecture approach provides a solid foundation for building maintainable, testable, and flexible .NET C# applications. By clearly separating concerns across four distinct layers—Core, Infrastructure, Application, and Web/API—teams can:

- **Isolate business logic** from technical implementation details
- **Share application logic** across multiple presentation types
- **Swap technologies** without rewriting business rules
- **Test thoroughly** at every layer
- **Scale development** with clear boundaries

The key to success is discipline in maintaining the dependency rule and ensuring each layer stays focused on its specific responsibilities. While it may seem like additional structure upfront, the long-term benefits in maintainability, testability, and flexibility make this investment worthwhile for applications of any significant complexity.

---

## Further Reading

- [**Clean Architecture**](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) by Robert C. Martin
- **Domain-Driven Design** by Eric Evans
- **Implementing Domain-Driven Design** by Vaughn Vernon
- **Microsoft Architecture Patterns**: https://docs.microsoft.com/en-us/dotnet/architecture/
- **CQRS Pattern**: https://martinfowler.com/bliki/CQRS.html
