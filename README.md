# Financial CRM - Dashboard (N Katmanlı Mimari)

Bu branch'te Financial CRM projesinin **Dashboard bölümü N Katmanlı Mimariye uygun şekilde yeniden düzenlenmiştir.**

Projenin önceki versiyonunda bazı işlemler doğrudan Windows Form içerisinde gerçekleştirilirken, bu güncelleme ile uygulama daha **modüler, sürdürülebilir ve okunabilir** bir yapıya dönüştürülmüştür.

---

# Yapılan Güncellemeler

## N Katmanlı Mimari Yapısı

Proje aşağıdaki katmanlara ayrılmıştır:

- **EntityLayer**
- **DataAccessLayer**
- **BusinessLayer**
- **PresentationLayer**

Bu yapı sayesinde:

- Kod tekrarının önüne geçilmiştir
- Katmanlar arası sorumluluklar ayrılmıştır
- Uygulamanın sürdürülebilirliği artırılmıştır

---

# Katmanların Görevleri

## EntityLayer

Veritabanındaki tabloları temsil eden sınıflar bu katmanda bulunmaktadır.

Örnek:

- Bank
- BankProcess
- Category
- Spending

Ayrıca tablolar arası ilişkiler için **Navigation Property** kullanılmıştır.

---

## DataAccessLayer

Bu katmanda veri erişim işlemleri gerçekleştirilmektedir.

Kullanılan teknolojiler:

- Entity Framework
- LINQ

Veritabanı işlemleri bu katmanda yönetilir.

---

## BusinessLayer

İş kurallarının bulunduğu katmandır.

Bu katmanda:

- Servis yapıları
- İş mantıkları
- Veri filtreleme işlemleri

gerçekleştirilmektedir.

Dashboard için gerekli hesaplamalar bu katmanda hazırlanarak arayüze gönderilir.

---

## PresentationLayer

Kullanıcı arayüzü bu katmanda bulunmaktadır.

Windows Forms üzerinden:

- Dashboard ekranı
- Finansal işlem ekranları
- Veri görüntüleme işlemleri

gerçekleştirilmektedir.

---

# Dashboard Güncellemeleri

Dashboard ekranı yeniden düzenlenmiş ve veriler servis katmanı üzerinden çekilecek şekilde yapılandırılmıştır.

Dashboard üzerinde gösterilen veriler:

- Toplam banka bakiyesi
- Son 30 gün içerisinde gelen toplam para
- Son 30 gün içerisinde giden toplam para
- Son finansal işlemler

Bu veriler **LINQ sorguları kullanılarak hesaplanmaktadır.**

---

# DTO Kullanımı

Dashboard üzerinde kullanılan bazı veriler için **DTO (Data Transfer Object)** yapısı kullanılmıştır.

DTO kullanımı sayesinde:

- Katmanlar arası veri aktarımı daha düzenli hale gelmiştir
- Gereksiz veri transferi önlenmiştir

---

# Kullanılan Teknolojiler

- C#
- .NET Framework
- Windows Forms
- Entity Framework
- LINQ
- SQL Server

---

# Amaç

Bu branch'in amacı mevcut projeyi **N Katmanlı Mimariye uygun hale getirerek** daha temiz, sürdürülebilir ve geliştirilebilir bir yapı oluşturmaktır.

Bu sayede proje:

- Daha okunabilir
- Daha modüler
- Daha profesyonel bir mimariye sahip hale getirilmiştir.

## Login Ekranı
![Login](Images/Login.PNG)

## Dashboard
![Dashboard](Images/Dashboard.PNG)

## Bankalar
![Banks](Images/Banks.PNG)

## Banka Hareketleri
![BankProcess](Images/BankProcess.PNG)

## Kategoriler
![Categories](Images/Categories.PNG)

## Faturalar
![Bills](Images/Bills.PNG)

## Harcamalar
![Spendings](Images/Spendings.PNG)
