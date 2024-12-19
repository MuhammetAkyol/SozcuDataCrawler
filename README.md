
**Proje Dökümantasyonu - SozcuDataCrawler**

## **Proje Tanıtımı**
Bu proje, **web scraping**, **Elasticsearch** veritabanı entegrasyonu ve **ASP.NET Core Razor Pages** kullanılarak oluşturulan bir web uygulamasıdır. Proje, **www.sozcu.com.tr** web sitesinden veri çekip, bu verileri **Elasticsearch** veritabanına kaydeder ve kullanıcıların veriler üzerinde arama yapabilmesini sağlar.

## **Kullanılan Teknolojiler**
- **Web Scraping (Veri Çekme)**:
  - HtmlAgilityPack (C# için HTML parsing kütüphanesi)
  - HttpClient (Web verisi çekmek için)
  
- **Veritabanı**:
  - Elasticsearch (Veri saklama ve sorgulama)
  - NEST (Elasticsearch istemcisi için C# kütüphanesi)
  
- **Web Uygulaması**:
  - ASP.NET Core Razor Pages (Web uygulaması geliştirme)
  - HTML, CSS, JavaScript (Ön yüz geliştirme)
  
- **Diğer Araçlar**:
  - Visual Studio (Proje geliştirme ortamı)
  - Kibana (Verileri görselleştirme ve analiz etme aracı)

## **Proje Adımları**

1. **Web Scraping (Veri Çekme)**  
   - www.sozcu.com.tr sitesinden haber başlıkları ve bağlantıları çekildi.  
   - HtmlAgilityPack ile HTML verisi işlendi.

2. **Elasticsearch Entegrasyonu**  
   - Article.cs sınıfı oluşturularak veri modeli yapıldı.  
   - ElasticsearchService.cs ile veriler kaydedildi ve sorgulandı.

3. **Web Uygulaması Geliştirme (Razor Pages)**  
   - Razor Pages ile web uygulaması oluşturuldu.  
   - Veriler, Search.cshtml sayfasında listelendi.

4. **Arama İşlevi**  
   - Kullanıcı başlıklar üzerinde arama yaparak belirli verilere ulaşabiliyor.

## **Proje Yapısı**

1. **SozcuDataCrawler**  
   - www.sozcu.com’dan veri çekme işlemleri burada yapıldı.

2. **SozcuDataCrawler.Infrastructure**  
   - Elasticsearch ve web scraping işlemleri yapılır.  
   - Article.cs, ElasticsearchService.cs ve SozcuWebCrawler.cs içerir.

3. **SozcuDataCrawler.Web**  
   - Kullanıcı arayüzü Razor Pages ile yapılır.  
   - Veriler, Search.cshtml sayfasında listelenir.

4. **SozcuDataCrawler.Core**  
   - SozcuWebCrawler sınıfı, bu interface'i implement eder ve CrawlAsync metodunu kullanarak web scraping işlemini gerçekleştirir.

## **Kullanıcı Akışı ve Uygulama**

1. Kullanıcı uygulamayı açtığında Search.cshtml sayfasına yönlendirilir.  
2. Veriler, Elasticsearch veritabanından çekilerek kullanıcıya sunulur.  
3. Kullanıcı başlıklar arasında arama yaparak ilgili sonuçları görüntüler.

## **Test ve Sonuçlar**

Projede yapılan testler sonucu şu bulgulara ulaşıldı:  
- **Veri Çekme**: Web scraping işlemi doğru çalıştı ve başlıklar doğru şekilde alındı.  
- **Elasticsearch Entegrasyonu**: Veriler doğru şekilde kaydedildi ve sorgulandı.  
- **Arama Fonksiyonu**: Arama doğru şekilde çalıştı ve kullanıcılar başlıklar arasında arama yapabiliyor.  
- **Uygulama Akışı**: Kullanıcı doğrudan Search sayfasında arama yapabilmeye başladı.

## **Sonuç**

Proje başarılı bir şekilde tamamlandı. Veriler çekildi, Elasticsearch'e kaydedildi ve ASP.NET Razor Pages üzerinden görüntülendi.



![image](https://github.com/user-attachments/assets/0b25f149-b45d-462b-a82c-8e9b8e4977ce)


![image](https://github.com/user-attachments/assets/59fb6e9d-94e0-4cdd-bf8e-5ddadaa7978f)


