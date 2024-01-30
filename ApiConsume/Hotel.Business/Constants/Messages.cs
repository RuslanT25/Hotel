using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.Constants
{
    public static class Messages<T>
    {
        public static string Error()
        {
            return "Something went wrong.";
        }
        public static string NotFound()
        {
            return "No records were found.";
        }

        public static class Message<TClass>
        {
            public static string Add(string header)
            {
                return $"{typeof(TClass).Name} - {header} has been successfully added to the system.";
            }

        }
    }
}
