# Levge.Domain

[![NuGet](https://img.shields.io/nuget/v/Levge.Domain.svg)](https://www.nuget.org/packages/Levge.Domain)
[![Publish NuGet Package](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml/badge.svg)](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml)

`Levge.Domain`, .NET projelerinde domain katman� i�in temel yap� ta�lar�n� sunar: temel entity s�n�flar�, denetim (audit), yumu�ak silme (soft delete) ve domain odakl� enumeration desenini i�erir.

---

## ?? Kurulum

```bash
dotnet add package Levge.Domain
```

---

## �zellikler

- Generic temel entity: `EntityBase<TKey>`
- Denetim ve yumu�ak silme aray�zleri: `IAuditable`, `ISoftDeletable`
- Haz�r denetimli entity: `AuditableEntity<TKey>`
- Domain odakl� enumeration temeli: `Enumeration`
- Harici ba��ml�l�k yok

---

## Kullan�m

### Temel Entity �rne�i

```csharp
public class Country : EntityBase<Guid>
{
    public string Code { get; set; }
    public string Name { get; set; }
}
```

### Denetimli + Yumu�ak Silme �rne�i

```csharp
public class User : AuditableEntity<Guid>
{
    public string Name { get; set; }
}
```

`AuditableEntity<TKey>`, varl�k ya�am d�ng�s�n� izlemek i�in `CreatedAt`, `UpdatedAt`, `DeletedAt` ve `IsDeleted` gibi �zellikler i�erir.

### Enumeration �rne�i

```csharp
public class RoleType : Enumeration
{
    public static RoleType Admin = new(1, "Admin");
    public static RoleType User = new(2, "User");

    private RoleType(int value, string name) : base(value, name) { }
}

// Kullan�m
var role = RoleType.FromValue<RoleType>(1); // RoleType.Admin
```

---

## Lisans

MIT � [Serdar �ZKAN](https://www.linkedin.com/in/serdarozkan41)
