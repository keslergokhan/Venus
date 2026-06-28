using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Cms
{
    public class VenusCmsHtmlTemplateSchemaException : VenusExceptionBase
    {
        public VenusCmsHtmlTemplateSchemaException(string message) : base("CMS_WIDGET_TEMPLATE_SCHEMA", message)
        {
        }

        public VenusCmsHtmlTemplateSchemaException(string message,Exception innerException) : base("CMS_WIDGET_TEMPLATE_SCHEMA", message,innerException)
        {
        }

    }
}
