﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
