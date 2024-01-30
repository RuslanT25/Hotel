using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Results
{
    public class ErrorResult : Result
    {
        // Sadece status gonderir
        public ErrorResult() : base(false)
        {
            
        }

        // Status ve mesaj gonderir.
        public ErrorResult(string message) : base(false,message)
        {
            
        }
    }
}
