using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Abstracts
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
        public int GetContactCount();
    }
}
