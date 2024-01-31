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

        public static class Entity<TClass>
        {
            public static string Add()
            {
                return $"New {typeof(TClass).Name} has been successfully added to the system.";
            }

            public static string AddRange()
            {
                return $"{typeof(TClass).Name}s have been successfully added to the system.";
            }

            public static string Delete()
            {
                return $"{typeof(TClass).Name} has been successfully deleted to the system.";
            }

            public static string DeleteRange()
            {
                return $"{typeof(TClass).Name}s have been successfully deleted to the system.";
            }

            public static string Destroy()
            {
                return $"{typeof(TClass).Name} has been successfully and permanently deleted to the system.";
            }

            public static string DestroyRange()
            {
                return $"{typeof(TClass).Name}s have been successfully and permanently deleted to the system.";
            }

            public static string Update()
            {
                return $"{typeof(TClass).Name} has been updated successfully.";
            }

            public static string UpdateRange()
            {
                return $"{typeof(TClass).Name}s have been updated successfully.";
            }

            public static string Exists()
            {
                return $" This {typeof(TClass).Name} is present in the system.";
            }

            public static string ExistsRange()
            {
                return $"All list elements of {typeof(TClass).Name} are present in the system.";
            }
        }
    }
}
