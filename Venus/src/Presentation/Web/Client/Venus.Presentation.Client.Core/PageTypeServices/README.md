# PageTypeServices Yapısı

Modern web projelerinde, kullanıcı deneyimine ve amaca yönelik farklı sayfa tasarımları ve işlevleri mevcuttur. Sayfaların büyük bir kısmı statik içeriklerden oluşsa da, birçoğu dinamik listeleme, detay gösterme veya özel iş mantıkları barındıran mimari yaklaşımlara ihtiyaç duyar.

Bu ayrımı ve yönetimi kolaylaştırmak adına **Venus**, sayfaların davranışlarını belirleyen dinamik bir **PageType** mimarisi kullanır.

### Senaryo: Blog Sistemi Örneği

Bir web sitesindeki klasik "Blog" akışını ele alalım:
1. **Liste Sayfası:** Kullanıcı `/bloglar` adresine gittiğinde, sistemdeki tüm blog yazıları bir liste halinde ekranda sıralanır.
2. **Detay Sayfası:** Kullanıcı ilgisini çeken bir blog başlığına tıkladığında, `/bloglar/ornek-blog` o yazının içeriğini barındıran özel detay sayfasına yönlendirilir.

Yukarıdaki senaryoda, aynı modüle ait iki temel sayfa yapısı (mimarisi) kullanılır: **Liste (List)** ve **Detay (Detail)**.

---

### Venus PageType Yaklaşımı

Venus sistemi, bu tür liste ve detay sayfaları için özel bir soyutlama sunar. Geliştiricilerin her defasında sıfırdan rota (route) veya render mantığı kurması yerine, bu ayrıştırmayı **PageType** mantığı üzerinden otomatikleştirir.

> 💡 **Sistem Nasıl Çalışır?**
> PageType sistemi sayesinde platform, ilgili sayfanın nasıl bir davranış (davranış modeli, veri çekme stratejisi, caching vb.) sergilemesi gerektiğini çalışma zamanında (runtime) anlar ve içeriği bu tipe göre dinamik olarak işler.

---

### Temel PageType Davranış Modelleri

Sistem genelinde en sık kullanılan sayfa tipleri ve kullanım amaçları aşağıda listelenmiştir:

| Page Type | Kullanım Amacı | Örnek URL |
| :--- | :--- | :--- |
| `Content` | Standart statik içerik sayfaları (Hakkımızda, İletişim vb.) | `/hakkimizda` |
| `List` | Dinamik içeriklerin listelendiği yapılar (Blog listesi, Ürünler) | `/bloglar` |
| `Detail` | Listelenen bir içeriğin tekil detay kırılımı | `/bloglar/venus-mimarisi-nedir` |

### NOT
Liste ve Detail sayfa mantıklarında sayfalar birbirini tanır, detay sayfası liste sayfasını tanır.
Bunu VenusUrl tablosunda parentId yaklaşımı sayesinde tanır.
> Detay sayfası liste sayfasının alt elemanıdır.


## EKSTRA 
Kendi pagetype kayıtları oluşturabilir ve özel sayfa tasarımları yapılabilir.

### Özel PageType Uygulanış
1. **VenusDefaultPageTypeService** gibi özel bir servis hazırlanır ve örnekte olduğu gibi **VenusPageTypeServiceBase**, **IVenusDefaultPageTypeService** miras alınır.

2. Tanımlanan özel sınıfın namespace adresine dikkat ederek VenusPageType tablosuna kayıt atılır.

3. PageTypeEnum içerisine VenusPageType.Title ile aynı olacak şekilde enum tanımlanır, zorunlu değil fakat kullanış ve mimari benzerliği açısından önemli