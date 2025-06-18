# Levge.Domain

[![NuGet](https://img.shields.io/nuget/v/Levge.Domain.svg)](https://www.nuget.org/packages/Levge.Domain)
[![Publish NuGet Package](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml/badge.svg)](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml)

`Levge.Domain`, .NET projelerinde domain katmaný için temel yapý taþlarýný sunar: temel entity sýnýflarý, denetim (audit), yumuþak silme (soft delete) ve domain odaklý enumeration desenini içerir.

---

## ?? Kurulum

```bash
dotnet add package Levge.Domain
```

---

## Özellikler

- Generic temel entity: `EntityBase<TKey>`
- Denetim ve yumuþak silme arayüzleri: `IAuditable`, `ISoftDeletable`
- Hazýr denetimli entity: `AuditableEntity<TKey>`
- Domain odaklý enumeration temeli: `Enumeration`
- Harici baðýmlýlýk yok

---

## Kullaným

### Temel Entity Örneði

```csharp
public class Country : EntityBase<Guid>
{
    public string Code { get; set; }
    public string Name { get; set; }
}
```

### Denetimli + Yumuþak Silme Örneði

```csharp
public class User : AuditableEntity<Guid>
{
    public string Name { get; set; }
}
```

`AuditableEntity<TKey>`, varlýk yaþam döngüsünü izlemek için `CreatedAt`, `UpdatedAt`, `DeletedAt` ve `IsDeleted` gibi özellikler içerir.

### Enumeration Örneði

```csharp
public class RoleType : Enumeration
{
    public static RoleType Admin = new(1, "Admin");
    public static RoleType User = new(2, "User");

    private RoleType(int value, string name) : base(value, name) { }
}

// Kullaným
var role = RoleType.FromValue<RoleType>(1); // RoleType.Admin
```

---

## Lisans

MIT © [Serdar ÖZKAN](https://www.linkedin.com/in/serdarozkan41)
