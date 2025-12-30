# Real Estate Backend API

ASP.NET Core Web API implementing the backend for the Real Estate Listing application.

---

## 🧱 Architecture

The backend follows **Onion Architecture**:


### Layer Responsibilities

- **Domain**
  - Entities
  - Enums
  - Core business rules

- **Application**
  - DTOs
  - Interfaces
  - Services
  - AutoMapper profiles

- **Infrastructure**
  - EF Core DbContext
  - Repository implementations
  - Identity configuration

- **API**
  - Controllers
  - Authentication
  - Middleware

---

## 🔐 Authentication & Authorization

- Microsoft Identity
- JWT Bearer authentication
- Roles:
  - Buyer
  - Admin

JWT includes:
- User Id
- Email
- Roles

Issuer & Audience validation is enabled.

---

## 🗄️ Database

- SQL Server
- EF Core (Code First)
- Migrations enabled
- Seed data:
  - Roles
  - Admin user
  - Sample properties

---

## ⚙️ Configuration

### `appsettings.json`

```json
"Jwt": {
  "Key": "SUPER_SECRET_KEY",
  "Issuer": "RealEstateApi",
  "Audience": "RealEstateClient"
}
