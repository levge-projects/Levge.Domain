# Levge.Domain

[![NuGet](https://img.shields.io/nuget/v/Levge.Domain.svg)](https://www.nuget.org/packages/Levge.Domain)
[![Publish NuGet Package](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml/badge.svg)](https://github.com/levge-projects/Levge.Domain/actions/workflows/main.yml)

📦 `Levge.Domain` paketi, domain katmanında sıkça ihtiyaç duyulan altyapı öğelerini içerir:

- `EntityBase<TKey>` ile generic Entity tanımları
- `IAuditable`, `ISoftDeletable` interface'leri
- `AuditableEntity<TKey>` hazır sınıfı
- `Enumeration` base class (Domain-driven enum alternatifi)

---

## 🧱 Kurulum

```bash
dotnet add package Levge.Domain
```

---

## 🧩 Base Entity Kullanımı

```csharp
public class Country : EntityBase<Guid>
{
    public string Code { get; set; }
    public string Name { get; set; }
}
```

---

## 📆 Auditable + Soft Delete

```csharp
public class User : AuditableEntity<Guid>
{
    public string Name { get; set; }
}
```

Sınıf `CreatedAt`, `UpdatedAt`, `DeletedAt`, `IsDeleted` gibi alanları içerir.

---

## 🎯 Enumeration Örneği

```csharp
public class RoleType : Enumeration
{
    public static RoleType Admin = new(1, "Admin");
    public static RoleType User = new(2, "User");

    private RoleType(int value, string name) : base(value, name) { }
}
```

Kullanım:
```csharp
var role = RoleType.FromValue<RoleType>(1); // RoleType.Admin
```

---

## 📦 Bağımlılıklar

- Harici bağımlılık YOK ❌

---

## 📄 Lisans

MIT © [Serdar ÖZKAN](https://www.linkedin.com/in/serdarozkan41)