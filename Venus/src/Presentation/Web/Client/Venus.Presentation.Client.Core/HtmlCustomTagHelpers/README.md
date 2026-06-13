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