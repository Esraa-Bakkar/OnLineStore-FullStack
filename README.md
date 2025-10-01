# OnLineStore-FullStack

**An Online Store Web Application (ASP.NET Core MVC) — Inspired by Clean Architecture**

> This repository contains a practice project built on the .NET stack to explore structured, maintainable web app design. The solution is an MVC web application inspired by Clean Architecture principles and implements CQRS patterns using MediatR to organize commands and queries.

---

## Table of Contents

* [Project Overview](#project-overview)
* [Key Features](#key-features)
* [Architecture & Folder Structure](#architecture--folder-structure)
* [Tech Stack](#tech-stack)
* [Getting Started (Clone & Run)](#getting-started-clone--run)
* [Database](#database)
* [Configuration](#configuration)
* [Development Notes & Conventions](#development-notes--conventions)
* [Future Improvements](#future-improvements)
* [Contributing](#contributing)

---

## Project Overview

This is a practice / learning project focused on applying solid architectural principles in a real-world style application. It is an **ASP.NET Core MVC** project inspired by Clean Architecture where responsibilities are separated into logical layers to make the codebase easier to reason about, test, and extend.

The app demonstrates common e-commerce flows such as product listing, shopping cart, and simple order handling. The implementation uses a CQRS-inspired approach with **MediatR** to decouple request handling and keep concerns clear between commands (writes) and queries (reads).

> **Note:** This solution is intentionally practical — it follows the *ideas* of Clean Architecture (layered domain, application, infrastructure, presentation) while keeping the structure simple and approachable for learning and quick iteration.

---

## Key Features

* Product catalog with list and detail pages
* Shopping cart (add / remove / view) functionality
* Basic order placement and handling flow
* Cookie-based Authentication & Authorization (server-side cookies)
* Persistent storage using a SQL script (included)
* Separation of concerns across Domain, Application, Infrastructure, and Presentation layers
* CQRS-style organization with MediatR for commands & queries

---

## Architecture & Folder Structure

The repository is organized into multiple projects (solution-level):

* `OnLineStore.Domain` — Core business entities and domain logic
* `OnLineStore.Application` — Use cases, DTOs, commands, queries and handlers (CQRS & MediatR)
* `OnLineStore.Infrastructure` — Data access implementations and integrations
* `OnLineStore.Web` — MVC presentation layer (controllers, views, static assets)

This separation helps keep the core domain independent from infrastructure and UI details.

---

## Tech Stack

* **Framework:** ASP.NET Core (MVC)
* **Pattern / Libraries:** CQRS-inspired structure, MediatR
* **Authentication:** Cookie-based authentication (server-side cookies)
* **Languages:** C# for backend, SCSS/CSS & JavaScript for front-end
* **Database:** SQL script included (see `online_stor.sql`) — typically run with SQL Server or any compatible RDBMS

---

## Getting Started (Clone & Run)

These instructions will get you a copy of the project up and running on your local machine for development and testing.

### Prerequisites

* .NET SDK (recommended: .NET 6/7/8 — use the version you prefer; adjust the project target in the `.csproj` files if necessary)
* SQL Server or another relational DB engine where you can run the provided SQL script
* Visual Studio 2022/2023 or VS Code (with C# extension) OR you can use the `dotnet` CLI

### Steps

1. Clone the repository

```bash
git clone https://github.com/Esraa-Bakkar/OnLineStore-FullStack.git
cd OnLineStore-FullStack
```

2. Create the database

*  add migration and update database

3. Configure connection string

* Open `OnLineStore.Web/appsettings.json` (or the appropriate config file) and update the connection string to point to your database. Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=OnlineStore;Trusted_Connection=True;"
}
```

4. Restore and build

```bash
# restore and build the entire solution
dotnet restore
dotnet build
```

5. Run the web project

* From Visual Studio: set `OnLineStore.Web` as the startup project and run (F5 or Ctrl+F5)
* From CLI:

```bash
dotnet run --project OnLineStore.Web
```

6. Open the site

* Navigate to `http://localhost:5000` (or the port shown in the console) and explore the product listing, cart, and order flows.

---

## Database

A SQL script (`online_stor.sql`) is included at the repository root. Use it to create the required schema and sample data. If you prefer migrations, you can port the schema into EF Core migrations if the solution uses EF; otherwise, run the script manually.

---

## Configuration

* Connection strings and environment-specific settings are stored in `appsettings.json` inside the Web project. Update these before running.
* Cookie-based authentication settings (cookie name, expiration, SameSite, Secure policy) are configured in Startup/Program and can be adjusted in `appsettings.json`, `appsettings.Development.json`, or environment variables. Make sure to enable Secure and SameSite policies for production deployments.
* If you need to enable authentication providers or external services, add the credentials/secrets to your local `appsettings.Development.json` or use user secrets / environment variables.

---

## Development Notes & Conventions

* The solution uses a CQRS-inspired design with MediatR handlers — commands should belong to the write side (mutations) and queries to the read side.
* Authentication: server-side cookie-based authorization is used across the Web project; ensure cookie policies and protection against CSRF are properly configured when extending authentication flows.
* Keep domain models free from infrastructure concerns; place database access code into the Infrastructure layer.
* Use DTOs between Application and Presentation layers to avoid leaking persistence models into the UI.

---

## Future Improvements (ideas)

* Add automated tests (unit & integration) for handlers and controllers
* Add Docker support for DB + app to simplify local setup
* Add CI pipeline (GitHub Actions) with build/test steps

---

## Contributing

Contributions are welcome — open an issue or a pull request. If you plan to make larger changes, please open an issue first to discuss the direction.

When contributing, follow these guidelines:

* Stick to the layered architecture
* Add tests when you add or change business logic
* Keep commits atomic and well-described

---


