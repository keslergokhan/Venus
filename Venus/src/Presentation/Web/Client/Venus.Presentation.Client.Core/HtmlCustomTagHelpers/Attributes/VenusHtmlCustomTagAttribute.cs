using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.HtmlCustomTagHelpers
{
    /// <summary>
    /// <see cref="Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base.VenusHtmlCustomTagHelper"/> sınıfından türetilecek olan alt sınıflar özel html attributes
    /// değerlerini temsil eder.
    /// </summary>
    /// <remarks>
    /// <see cref="Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base.VenusHtmlCustomTagHelper.LoadPropertySetData"/> araclığı ile html içerisindeki attr değerleri
    /// yakalanır ve temsil edilen property değerlerine value eklenir.
    /// </remarks>
    public class VenusHtmlCustomTagNameAttribute : Attribute
    {
        /// <summary>
        /// Html üzerinde işaretlenecek attributes name değeri
        /// </summary>
        /// <example>
        /// <see cref="Venus.Presentation.Client.Core.HtmlCustomTagHelpers.Base.VenusHtmlCustomTagHelper.LoadPropertySetData"/> methodu araclığı ile belirlenmiş
        /// property değerlerine html içerisindeki değerleri yakalar.
        /// <c> <venus-example title-key=""></venus-example>  </c>
        /// </example>
        public string Name { get; set; }
        /// <summary>
        /// Html içerisinde value değerine ulaşılamadığı durumda varsayılan değer
        /// </summary>
        public string DefaultValue { get; set; }

        public VenusHtmlCustomTagNameAttribute(string name,string defaultValue)
        {
            Name = name;
            DefaultValue = defaultValue;
        }
    }
}
