using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class ContactManager : BaseManager<Contact>, IContactService
    {
        readonly IContactRepository _contactRepository;
        public ContactManager(IContactRepository contactRepository) : base(contactRepository)
        {
            _contactRepository = contactRepository;
        }
    }
}
