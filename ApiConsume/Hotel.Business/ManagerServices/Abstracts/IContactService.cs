﻿using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface IContactService : IBaseService<Contact>
    {
        public int GetContactCount();
    }
}
