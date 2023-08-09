# NZHotel
**Bu proje, Full Stack .Net Software kursunun bitirme projesidir.**
NZ Hotel, tatil bölgesinde bir otelin kullanabileceği bir uygulamadır.
Proje, yönetim , resepsiyon ve web modülleri ile karmaşık bir yapıya sahiptir.
--Resepsiyon modülü, rezervasyon alma, otel konuklarının kaydı, giriş çıkış işlemleri, odaların durumu ve takibi gibi kısımları içerecektir.

--Ayrıca web modülü üzerinden müşterilerin yaptıkları rezervasyonları görüntüleyebilmektedir.Günlük kurlarıda içermektedir.WebApi kullanılmıştır.

--Yönetim modülü, resepsiyon modülünün yaptığı tüm işleri takip edebilmektedir.Ayrıca çalışanlarla ilgili kayıt ve muhasebe kısımları bu modülde yer alır. Çalışanlarn kullanıcı olarak kaydı ve yetkilendirme işlemleri de bu modülde gerçekleştirilir.

--Web modülü, müşteriye otelin tanıtımını yapan, internet üzerinden rezervasyon yapabilmesini sağlayan kısımdır.

Proje N-tier architecture yapıdadır.
VS de açtığımız Blank Solution içerisine biri Asp.Net Core Web App (MVC eklenerek) olmak üzere  6 proje ekledik.Bunlar ;
- Entities
- Data Access Layer
- Business Logic Layer
- DTOs 
- Common (Response ve Enums)
- UI

  ORM  teknolojisi olan **Entity Framework Core(Code First yaklaşımıyla)** kullanılmıştır. Gerekli Configuration&Mapping işlemleri FluentApi ile yapılmıştır. MSSQL server veritabanı kullanılmıştır.
  (Microsoft.AspNetCore.Identity.EntityFrameworkCore 5.0.17 & Microsoft.EntityFrameworkCore.SqlServer 5.0.17 && Microsoft.EntityFrameworkCore.Tools 5.0.17)
  
Üyelik sistemi için **Asp.NET Core Identity** kütüphanesinden faydalanılmıştır.(Microsoft.AspNetCore.Identity 2.2.0 &)
Katmanlar arası veri transferi için DTO lar ve gerektiği noktada UI da  ViewModel ler kullanılmştır.
Bu farklı tipte olan nesneleri dinamik bir şekilde birbirine dönüştüren **AutoMapper** kütüphanesini kullandık.
(AutoMapper 12.0.1)
  
  **Projemize gerekli olan paketleri ve kütüphaneleri eklemek için  Nuget Package Manager kullanıldı.**
  
  
 




