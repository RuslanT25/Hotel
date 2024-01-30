using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Results
{
    public class SuccessResult : Result
    {
        // Sadece statusu gonder.
        public SuccessResult() : base(true)
        {
            
        }

        // Status ve mesaji gonder.
        public SuccessResult(string message) : base(true,message)
        {
            
        }
    }
}
