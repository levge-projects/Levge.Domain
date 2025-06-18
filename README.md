> 🇹🇷 [Dokümantasyonun Türkçesi için buraya tıklayın.](README.tr.md)

# Levge.Domain

[![NuGet](https://img.shields.io/nuget/v/Levge.Domain.svg)](https://www.nuget.org/packages/Levge.Domain)
[![Publish NuGet Package](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml/badge.svg)](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml)

`Levge.Domain` provides essential building blocks for the domain layer in .NET projects, including base entity classes, auditing, soft deletion, and a domain-driven enumeration pattern.

---

## 🚀 Installation

dotnet add package Levge.Domain
---

## Features

- Generic base entity: `EntityBase<TKey>`
- Auditing and soft delete interfaces: `IAuditable`, `ISoftDeletable`
- Ready-to-use auditable entity: `AuditableEntity<TKey>`
- Domain-driven enumeration base: `Enumeration`
- No external dependencies

---

## Usage

### Base Entity Example
public class Country : EntityBase<Guid>
{
    public string Code { get; set; }
    public string Name { get; set; }
}
### Auditable + Soft Delete Example
public class User : AuditableEntity<Guid>
{
    public string Name { get; set; }
}
The `AuditableEntity<TKey>` includes properties like `CreatedAt`, `UpdatedAt`, `DeletedAt`, and `IsDeleted` for tracking entity lifecycle.

### Enumeration Example
public class RoleType : Enumeration
{
    public static RoleType Admin = new(1, "Admin");
    public static RoleType User = new(2, "User");

    private RoleType(int value, string name) : base(value, name) { }
}

// Usage
var role = RoleType.FromValue<RoleType>(1); // RoleType.Admin
---

## License

MIT © [Serdar ÖZKAN](https://www.linkedin.com/in/serdarozkan41)