using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class StaffManager : BaseManager<Staff>, IStaffService
    {
        readonly IStaffRepository _staffRepository;
        public StaffManager(IStaffRepository staffRepository) : base(staffRepository)
        {
            _staffRepository = staffRepository;
        }
    }
}
