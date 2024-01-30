using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Results
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        // Mesaj gondermir,sadece statusu gosterir
        public Result(bool success)
        {
            Success= success;
        }

        // Hem mesaj gonderir,hem de statusu gosterir
        public Result(bool success,string message) : this(success)
        {
            Message= message;
        }
    }
}
