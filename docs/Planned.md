
- **lc-clean** – Clean Architecture template with layered project separation (API, Application, Domain, Infrastructure)
- **lc-hexagonal** – Hexagonal (Ports and Adapters) Architecture focusing on inbound/outbound ports and use case encapsulation
- **lc-onion** – Onion Architecture emphasizing domain-centric development and inversion of control

### Planned Templates

- 🪆 Modular Monolith : Domain-oriented modules inside a single deployable app; enforces boundaries at runtime
- 🧱 Feature Folders : Variation of vertical slices; UI/app organized by feature folders (less formal CQRS)
- 🛰️ Microservices : Independently deployed services, isolated data, API contracts
- 🔌 Plugin-Based : Extensible via modules/plugins; useful for SaaS/multi-tenant platforms
- 🎛️ Event-Driven : Architecture based around messaging (e.g., Kafka, RabbitMQ) with pub/sub models
- 🏗️ Layered (Traditional) : UI → BLL → DAL → DB; legacy-friendly, simple to understand
- 🧬 CQRS + Event Sourcing : Commands change state, queries read; source of truth is events instead of the database
- 🧳 BFF (Backend For Frontend)	: Tailored APIs per frontend (mobile/web); good for micro frontends
- 🧭 Service-Oriented (SOA)	: Coarse-grained services with contracts; precursor to microservices
- 🏞️ Serverless : Function-as-a-Service (e.g., Azure Functions); stateless logic execution
- 🔁 Saga-Orchestration	: Long-running transactions across services/domains using orchestrators or choreography
- 🛠️ Ports and Use Cases : More granular take on Clean/Hexagonal; aligns tightly with Uncle Bob’s original vision

##### Options: 
- Monolith First	Template to build a monolith that can later be split into services
- Test-Driven Architecture	Emphasizes test-first structure, dependency inversion everywhere
- Multi-Tenant SaaS	Adds tenant resolution, isolation layers, and scoped services
- Multi-Repo Setup	Bootstraps multiple services with shared contracts and tooling

#### Vertical Slice Architecture
**Description:** Organizes code by features rather than layers.

**Key Features:**
- Minimal coupling between features
- Each feature is self-contained (DTOs, handlers, validations)
- Often used with MediatR and CQRS

**Use Case:** APIs with distinct, independent functionalities.

#### Modular Monolith
**Description:** Monolithic structure with clear module boundaries.

**Key Features:**
- Modules can be extracted to microservices later
- Loose coupling between modules
- Each module may have its own DB schema

**Use Case:** Large applications that may evolve into microservices.

#### Event-Driven Architecture (EDA)
**Description:** Components communicate via events (pub/sub).

**Key Features:**
- Event sourcing support
- Kafka/RabbitMQ/Azure Service Bus integration
- Saga pattern for distributed transactions

**Use Case:** Systems requiring real-time updates & decoupled services.

#### Microservices Template
**Description:** Multiple small, independently deployable services.

**Key Features:**

-  Gateway (YARP, Ocelot)
- Service discovery (Consul, Kubernetes)
- Resilience (Polly, retry policies)

**Use Case:** Scalable, distributed systems.

#### Serverless Architecture
**Description:** Functions-as-a-Service (Azure Functions, AWS Lambda).

**Key Features:**
- Minimal boilerplate
- Durable Functions for workflows
- Event triggers (HTTP, queues, timers)

**Use Case:** Event-triggered, scalable workloads.

#### N-Tier Architecture (Traditional Layered)
**Description:** Classic separation (UI > Business > Data).

**Key Features:**
- Simple and familiar
- Good for CRUD-heavy apps
- Less strict than Clean/Onion Architecture

**Use Case:** Legacy migrations or straightforward apps.

#### CQRS + Event Sourcing Template
**Description:** Separates reads and writes, with event history.

**Key Features:**
- Separate read/write databases
- Event store (EventStoreDB, Marten)
- Projections for query models

**Use Case:** High-performance systems needing audit trails.

#### Plugin Architecture
**Description:** Core system with pluggable modules.

**Key Features:**
- Dynamic loading of DLLs
- Interface-based contracts
- Dependency injection for plugins

**Use Case:** Extensible applications (e.g., CMS, payment processors).

#### DDD-Lite (Simplified Domain-Driven Design)
**Description:** DDD without full complexity.

**Key Features:**
- Aggregates & Repositories
- Domain Events
- Bounded Contexts (optional)

**Use Case:** Teams new to DDD needing gradual adoption.

#### Actor Model (Akka.NET / Orleans)
**Description:** Concurrent systems using actors.

**Key Features:**
- Message-passing concurrency
- Fault tolerance
- Orleans virtual actors

**Use Case:** High-concurrency systems (chat, gaming).

##### Template Enhancement Ideas
- Add-ons:
    - Authentication: IdentityServer, JWT, OAuth2.
    - Monitoring: OpenTelemetry, Prometheus, Grafana.
    - CI/CD: GitHub Actions, Azure Pipelines.
    - Frontend: Blazor, React, Angular integration.

```bash
# Example: Create a Clean Architecture project
dotnet new lc-clean -n MyCleanArchProject -o ./MyCleanArchProject

# Example: Create a Hexagonal Architecture project
dotnet new lc-hex -n MyHexArchProject -o ./MyHexArchProject

# Example: Create an Onion Architecture project
dotnet new lc-onion -n MyOnionArchProject -o ./MyOnionArchProject

dotnet new lc-ddd-basic -n MyDDDApp -o ./MyDDDApp

dotnet new lc-vert-slice -n MyVerticalApp  -o ./MyVerticalApp
```

ref

[](https://medium.com/@gilvam/clean-architecture-clean-code-ec48a89b0f2b)
[](https://zup.com.br/blog/clean-architecture-arquitetura-limpa)
[](https://deviq.com/architecture/clean-architecture)
[](https://github.com/ardalis/ApiEndpoints)
[](https://github.com/ardalis/Ardalis.SharedKernel)
[](https://github.com/ardalis/Specification)
[](https://github.com/ardalis/Result)
[](https://github.com/ardalis/GuardClauses)
[](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)
[](https://www.dossier-andreas.net/software_architecture/ports_and_adapters.html)
[](https://alistair.cockburn.us/hexagonal-architecture)
[](https://alistair.cockburn.us/)
