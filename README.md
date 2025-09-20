# Konsol tabanlı bir Akademi/Öğrenci Kayıt Sistemi

NET 6 ve Entity Framework Core (SQL Server) kullanır; kategori, kurs, eğitmen, öğrenci ve kayıt (enrollment) süreçlerini CRUD, soft delete (Çöp Kutusu) ve repository deseni ile uygular.

## Özellikler

Menü tabanlı CLI ile tüm işlemler:

Kategori: listele, ekle, güncelle, sil / çöp kutusuna al, geri al

Öğrenci: listele, ekle, güncelle, sil / çöp kutusuna al, geri al

Eğitmen: listele, ekle, güncelle, sil / çöp kutusuna al, geri al

Kurs: listele, ekle, güncelle, sil / çöp kutusuna al, geri al

Kayıt (Enrollment): listele, yeni kayıt oluştur

Soft Delete: BaseEntity.Status (aktif / pasif) ile kalıcı silmeden ayrı “Çöp Kutusu” mantığı

Repository Deseni: GenericRepo<T> üzerinden ortak CRUD + CategoryRepo gibi tip-özelleşmiş repolar

## Zengin İlişkiler

1-N: Category ↔ Course, Instructor ↔ Course

1-1: Course ↔ CourseDetail (FK: CourseDetail.Id)

N-N: Student ↔ Course (Enrollment ara tablosu, bileşik anahtar)

## Teknolojiler

.NET 6 (C#) — console app

Entity Framework Core 6

SQL Server (EF Core SqlServer provider)

Paketler: Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools

## Kurulum

### Gereksinimler

.NET SDK 6.x

SQL Server (LocalDB/Express/Server)

### Depoyu alın

git clone https://github.com/berkay-ceylan/AcademyManagementSystem.git
cd AcademyManagementSystem
dotnet restore

## Bağlantı dizesi

Contexts/AppDbContext.cs içindeki UseSqlServer(...) kısmını kendi SQL Server bilgilerinize göre düzenleyin

