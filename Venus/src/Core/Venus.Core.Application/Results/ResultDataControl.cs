using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venus.Core.Application.Results.Base;
using Venus.Core.Application.Results.Interfaces;

namespace Venus.Core.Application.Results
{
    public class ResultControl : BaseResultControl
    {

    }

    public class ResultDataControl<T> : BaseResultControl, IResultDataControl<T>
    {
        public ResultDataControl()
        {

        }

        public ResultDataControl(T d)
        {
            this._data = d;
        }

        private T _data;
        public T Data => _data;

        public object GetDataObject()
        {
            return this.Data;
        }

        public IResultDataControl<T> SetData(T t)
        {
            _data = t;
            return this;
        }

        public IResultDataControl<T> SuccessSetData(T t)
        {
            this.SetData(t);
            base.Success();
            return this;
        }

        public override IResultControl Fail(Exception exception)
        {
            return base.Fail(exception);
        }

    }
}
