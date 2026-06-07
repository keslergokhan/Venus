using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venus.Presentation.Client.Core.HtmlCustomTagParser
{
    public interface HtmlCustomTagIterator<T>
    {
        public bool HasNext();
        T Next();
        void Reset();
    }
}
