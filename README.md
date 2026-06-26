# 🛒 MultiShop - E-Commerce Platform

**ASP.NET Core ile geliştirilmiş modern e-ticaret platformu / Modern e-commerce platform built with ASP.NET Core**

[![.NET](https://img.shields.io/badge/.NET-8.0-512bd4?logo=dotnet)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://learn.microsoft.com/dotnet/csharp/)
[![SQL Server](https://img.shields.io/badge/Database-SQL_Server-CC2927.svg)](https://www.microsoft.com/sql-server)
[![OpenID Connect](https://img.shields.io/badge/Auth-OpenID_Connect-success.svg)](https://openid.net/connect/)
[![Architecture](https://img.shields.io/badge/Architecture-Microservices-orange.svg)]()

> **.NET 8.0 | C# 12 | SQL Server | OpenID Connect Authentication**

---

## 🚀 Özellikler / Features

| 🇹🇷 Türkçe                                                                      | 🇬🇧 English                                                                          |
| -------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------- |
| OpenID Connect ile güvenli kimlik doğrulama                                      | Secure authentication with OpenID Connect                                             |
| Katmanlı mimari (EntityLayer / DataAccessLayer / BusinessLayer / WebApi / WebUI) | Layered architecture (EntityLayer / DataAccessLayer / BusinessLayer / WebApi / WebUI) |
| DTO ve AutoMapper ile veri taşınması                                             | Data transfer using DTO & AutoMapper                                                  |
| Repository & Generic Repository Pattern                                          | Repository & Generic Repository Pattern                                               |
| Fluent Validation ile model doğrulama                                            | Model validation with Fluent Validation                                               |
| Swagger ile API dokümantasyonu                                                   | API documentation via Swagger                                                         |
| Çok satıcılı marketplace yapısı                                                  | Multi-vendor marketplace architecture                                                 |
| Ürün yönetimi ve kategorilendirme                                                | Product management and categorization                                                 |
| Gerçek zamanlı stok takibi                                                       | Real-time inventory tracking                                                          |
| Güvenli ödeme entegrasyonu                                                       | Secure payment integration                                                            |
| Kullanıcı profili ve sipariş yönetimi                                            | User profiles and order management                                                    |
| Modern ve responsive UI tasarımı                                                 | Modern and responsive UI design                                                       |
| Mikroservis mimarisi desteği                                                     | Microservice architecture support                                                     |
| Ölçeklenebilir proje yapısı                                                      | Scalable project structure                                                            |

---

## 🏗️ Mimari / Architecture

```text
MultiShop/
│
├── Frontends/
│   └── MultiShop.WebUI
│
├── Services/
│   ├── MultiShop.IdentityService
│   ├── MultiShop.CatalogService
│   ├── MultiShop.OrderService
│   ├── MultiShop.PaymentService
│   ├── MultiShop.CommentService
│   ├── MultiShop.DiscountService
│   └── MultiShop.UserService
│
├── Shared/
│   ├── MultiShop.DtoLayer
│   └── MultiShop.SharedLibrary
│
└── MultiShop.sln
```

Katmanlı ve mikroservis mimarisi sayesinde proje ölçeklenebilir, sürdürülebilir ve test edilebilir bir yapıya sahiptir.

The layered and microservice architecture provides a scalable, maintainable, and testable project structure.

---

## 🧩 Kullanılan Tasarım Yaklaşımları / Design Approaches

### Repository Pattern

Veri erişim işlemlerinin merkezi ve yönetilebilir şekilde gerçekleştirilmesini sağlar.

Provides a centralized and maintainable approach for data access operations.

---

### Generic Repository Pattern

Kod tekrarını azaltır ve veri erişim süreçlerini standartlaştırır.

Reduces code duplication and standardizes data access processes.

---

### DTO & AutoMapper

Katmanlar arasında güvenli ve performanslı veri transferi sağlar.

Provides secure and efficient data transfer between application layers.

---

### Fluent Validation

Veri doğrulama süreçlerini merkezi hale getirir.

Centralizes model validation processes.

---

### OpenID Connect Authentication

OpenID Connect protokolü kullanarak güvenli ve merkezi kimlik doğrulama sağlar.

Provides secure and centralized authentication using OpenID Connect protocol.

---

### Dependency Injection

Bağımlılıkları yönetir ve kodun test edilebilirliğini artırır.

Manages dependencies and improves code testability.

---

## 🛠️ Kullanılan Teknolojiler / Tech Stack

| Katman / Layer    | Teknoloji                       |
| ----------------- | ------------------------------- |
| Backend           | ASP.NET Core Web API            |
| Frontend          | ASP.NET Core MVC / Razor Pages  |
| Authentication    | OpenID Connect / IdentityServer |
| ORM               | Entity Framework Core           |
| Validation        | Fluent Validation               |
| Mapping           | AutoMapper                      |
| API Documentation | Swagger                         |
| Database          | SQL Server                      |
| HTTP Client       | HttpClientFactory               |
| Language          | C# 12                           |
| Framework         | .NET 8                          |

---

## ⚙️ Kurulum / Setup

### Gereksinimler / Requirements

* .NET SDK 8.0 veya üzeri / .NET SDK 8.0 or higher
* SQL Server (Yerel veya uzak) / SQL Server (local or remote)
* Visual Studio 2022 (Önerilen) / Visual Studio 2022 (Recommended)

---

### Adımlar / Steps

#### Repoyu Klonla / Clone the Repository

```bash
git clone https://github.com/abdullahhaktan/MultiShop.git

cd MultiShop
```

#### Veritabanı Bağlantısını Güncelle / Update Database Connection

`appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=MultiShopDb;Trusted_Connection=True;"
  }
}
```

#### Migration İşlemlerini Çalıştır / Run EF Core Migrations

```bash
dotnet ef database update
```

#### Identity Service'i Başlat / Run Identity Service

```bash
dotnet run --project Services/MultiShop.IdentityService
```

#### Catalog Service'i Başlat / Run Catalog Service

```bash
dotnet run --project Services/MultiShop.CatalogService
```

#### Order Service'i Başlat / Run Order Service

```bash
dotnet run --project Services/MultiShop.OrderService
```

#### Payment Service'i Başlat / Run Payment Service

```bash
dotnet run --project Services/MultiShop.PaymentService
```

#### WebUI Uygulamasını Başlat / Run WebUI

```bash
dotnet run --project Frontends/MultiShop.WebUI
```

---

## 🔑 Kimlik Doğrulama / Authentication

Proje OpenID Connect ve IdentityServer kullanarak güvenli bir kimlik doğrulama sistemi sunar.

Kullanıcılar merkezi bir kimlik doğrulama sunucusu üzerinden giriş yaparak tüm mikroservislere erişebilirler.

The project provides secure authentication using OpenID Connect and IdentityServer.

Users can log in through a centralized authentication server to access all microservices.

### Authentication Flow

```text
User
 │
 ▼
MultiShop.WebUI
 │
 ▼
Identity Service
 │
 ▼
OpenID Connect Authentication
 │
 ▼
Access Token + Refresh Token
 │
 ▼
Microservices Access
```

---

## 📁 Proje Yapısı / Project Structure

### Frontends

* MultiShop.WebUI → Ana web arayüzü (Razor Pages + MVC Controllers)

### Services

* MultiShop.IdentityService → Kimlik doğrulama ve yetkilendirme
* MultiShop.CatalogService → Ürün kataloğu yönetimi
* MultiShop.OrderService → Sipariş yönetimi
* MultiShop.PaymentService → Ödeme işlemleri
* MultiShop.CommentService → Ürün yorumları
* MultiShop.DiscountService → İndirim ve promosyon kodları
* MultiShop.UserService → Kullanıcı yönetimi

### Shared

* MultiShop.DtoLayer → Data Transfer Objects
* MultiShop.SharedLibrary → Ortak utility ve extension sınıfları

---

## 🚦 API Endpoints

Tüm API endpointlerine Swagger üzerinden erişebilirsiniz.

Access all API endpoints through Swagger UI.

| Service          | URL                           |
| ---------------- | ----------------------------- |
| Catalog Service  | http://localhost:5001/swagger |
| Order Service    | http://localhost:5002/swagger |
| Payment Service  | http://localhost:5003/swagger |
| Comment Service  | http://localhost:5004/swagger |
| Discount Service | http://localhost:5005/swagger |
| User Service     | http://localhost:5006/swagger |
| Identity Service | http://localhost:5000/swagger |

---

## 💡 Kullanım / Usage

### Demo Hesabı / Demo Account

```text
Username : ahmethaktan
Password : Ahmethaktan1
```

---

## 📸 Ekran Görüntüleri / Screenshots


---

## 🤝 Katkıda Bulunma / Contributing

1. Fork the Project
2. Create your Feature Branch

```bash
git checkout -b feature/AmazingFeature
```

3. Commit your Changes

```bash
git commit -m "Add some AmazingFeature"
```

4. Push to the Branch

```bash
git push origin feature/AmazingFeature
```

5. Open a Pull Request

---

## 📝 Lisans / License

Bu proje MIT Lisansı altında dağıtılmaktadır.

This project is distributed under the MIT License.

---

## 👨‍💻 Mühendis & Geliştirici / Engineer & Developer

**Abdullah Haktan**

GitHub → https://github.com/abdullahhaktan

---

## 📞 İletişim / Contact

GitHub Issues:

https://github.com/abdullahhaktan/MultiShop/issues

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın.

⭐ If you like this project, don't forget to give it a star.
