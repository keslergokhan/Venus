using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Exceptions.Base;

namespace Venus.Core.Application.Exceptions.Systems
{
    public class VenusNotFoundWidgetSystemException : VenusExceptionBase
    {
        public VenusNotFoundWidgetSystemException(string widgetKey) : base("NOT_FOUND_WIDGET", $"Widget kaynağına ulaşılamadı: {widgetKey}")
        {
        }
    }
}
