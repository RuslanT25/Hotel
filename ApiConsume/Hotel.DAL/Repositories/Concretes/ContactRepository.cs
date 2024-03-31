using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Concretes
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        readonly HotelDbContext _context;
        public ContactRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetContactCount()
        {
            int count = _context.Contacts.Count();

            return count;
        }
    }
}
