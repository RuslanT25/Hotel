using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.WebApi.Services.ApiResponseModels
{
    public class ResponseData<T>
    {
        public T Data { get; set; }
    }
}
