# GodRift.API - (in development)

GodRift.API is a RESTful Web API built with ASP.NET Core and Entity Framework Core. It serves as the backend for a project that manages data related to players, champions, builds, lanes, and match histories — inspired by Wild Rift.

## 🚀 Project Overview

This API currently supports:

- User and player management
- Champion and item data
- Builds and lanes
- Matches and match players
- Relationships such as champions on lanes and items used in matches

## ⚙️ Technologies Used

- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core**
- **SQL Server** (via Docker)
- **Swagger** for API documentation and testing

## 📂 Project Structure

```
src/
├── Backend/
│   └── GodRift.API/
│       ├── Controllers/       # REST controllers
│       ├── Data/              # EF Core DbContext
│       ├── Models/            # Domain models
│       ├── Program.cs         # Entry point
│       └── appsettings.json   # Configuration
```

## 🧪 API Documentation

After running the project, you can access Swagger UI at:

```
http://localhost:<port>/swagger
```

Use it to test the available endpoints and view API schemas.

## 🔧 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) with a running SQL Server container

### Example SQL Server Docker Setup

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourStrongPassword" \
   -p 1433:1433 --name sqlserver \
   -d mcr.microsoft.com/mssql/server:2022-lts
```

### Running the Project

```bash
cd src/Backend/GodRift.API
dotnet restore
dotnet build
dotnet run
```

The API will start at `https://localhost:5129` (or similar port).

## ✅ TODO (Next Steps)

- Add authentication and authorization
- Implement DTOs and data validation
- Seed initial data for development
- Create unit/integration tests
- Design and implement the frontend (GodRift.GG)

## 👤 Author

- Lucas Bellucci Almendra
