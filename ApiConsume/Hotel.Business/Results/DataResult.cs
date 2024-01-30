using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Results
{
    public class DataResult<T> : Result,IDataResult<T>
    {
        // Result-a statusu ve mesaji gonder,ozunde ise data-ni ver.
        public DataResult(T data,bool success,string message) : base(success,message)
        {
            Data = data;
        }

        // Result-a statusu gonder,ozunde ise data-ni ver.
        public DataResult(T data,bool success) : base(success) 
        {
            Data = data;
        }
        public T Data { get; }
    }
}
