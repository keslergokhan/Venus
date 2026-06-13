# HtmlCustomTagHelpers

> Venüs sistemine özel dinamik html sistemleri. Çalışma mantığı .net taghelper sistemine benzer.


```html
<div class="container">
    <h1>Merhaba Dünya</h1>
    <p>Bu bir örnek HTML içeriğidir.</p>
    <venus-widget key-data="Carousel"></venus-widget>
</div>
```

## Uygulanma
**VenusHtmlCustomTagHelper**'den türetilmiş alt sınıflar ile özel etiket servisleri oluşturulur.

Sınıf `HtmlTargetElement` ve `GetTemplateAsync` gibi temel method ve property değerlerini implemente etmeni ister.

````csharp
public class VenusLangaugeResourceHtmlCustomTagHelper : VenusHtmlCustomTagHelper
{
    [VenusHtmlCustomTagNameAttribute("key-data", "")]
    public string Key { get; set; }
    public VenusLangaugeResourceHtmlCustomTagHelper(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public override string HtmlTargetElement => "venus-lan-resource";

    public override short RenderOrder => 99;

    protected override async Task<string> GetTemplateAsync()
    {
        return $"<span>{Key}</span>";
    }
    
}
````

> Yukarıdaki kod bloğuna baktığımızda **HtmlTargetElement** içinde belirtilen `venus-lan-resource` html yapısı içerisinde ayrıştırılacak etiket isimlendirmesini temsil eder.

>**VenusHtmlCustomTagNameAttribute** ile belirtilen etiketin içerisinde girilmesi beklenen attributes değerlerini temsil edder.

> **GetTemplateAsync** methodu etiketin sonucunda ekrana basılacak son html çıktısın temsileder.

### Kullanım

> Gün sonunda html etiketleri içerisinde aşağıdaki gibi bir etiket tanımlanabilir, html render edilirken. **IHtmlCustomTagParserAndRenderFactory** kullanılır.

#### Örnek html
```html
<div class="container">
    <venus-lan-resource key-data="Carousel"></venus-lan-resource>
</div>
```

#### Html çıktısı
```html
<div class="container">
    <span>Carousel</span>
</div>
```

## Scriban sistemi

> Scriban paketi ile birlikte özel etiketlerin oluşturulması sırasında ilgili html kodları içerisinde döngü koşul vs gibi dinamik imkanları sunmaktadır.

> Aşağıdaki örnekte dikkat edileceği üzere bu html render edilmeden önce belirli verilere ihtiyaç duymaktadır, user verisi ve is_admin gibi verilere ihtiyaç duyumakta ve bunları html içerisinde kullanmaktadır.

> Aynı zamanda if gibi koşul ifadesi kullanılabilmektedir bunun gibi döngü ve birçok özellik scriban ile kullanılabilmektedir.

````html
<div>
    <div class="user-card">
        <h3>{{ user.name }}</h3>
        <p>{{ user.email }}</p>
    </div>

    {{ if is_admin }}
    <span class="badge badge-danger">Yönetici</span>
    {{ end }}
</div>

````


## Widget ve Scriban Sistemi

> Venus sistemi **`Venus.Core.Domain.Entities.Systems.VenusWidget`** tablosu ile birlikte `Template` yani Html kayıtları tutulur, özel tanımladığımız Html kayıtları **`VenusWidgetHtmlCustomTagHelper`** sistemi ile birlikte render edilmektedir.

#### Örnek :
````html
<venus-widget key-data="Test.Sablonu">
    <script type="application/json">
    {
        "Title": "Merhaba Dünya",
        "Description":"Bu veri dışarıdan eklendi"
    }
    </script>
</venus-widget>
````

> Yukarıdaki örnekte **`VenusWidgetHtmlCustomTagHelper`** servisi Html kaynağı içindeki `venus-widget` etiketini derler, `key-data`.

> Derleme sırasında attributes değerleri okunur `key-data` temsil edilecek `VenusWidget` kaydını belirtir, `<script>` etiketleri arasında gönderilen json değerleri `key-data="Test.Sablonu"` temsil eden Html içindeki Scriban tanımlamalarını karşılamak amaçlıdır.

### Derlenecek olan widget = Test.Sablonu

````html
<div>
    <div class="user-card">
        <h3>{{ Model.Title }}</h3>
        <p>{{ Model.Description }}</p>
    </div>
</div>
````

### Derleme Sonrası

````html
<div>
    <div class="user-card">
        <h3>Merhaba Dünya</h3>
        <p>Bu veri dışarıdan eklendi</p>
    </div>
</div>
````