using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Hotel.Business.ManagerServices.Abstracts;
using Microsoft.Extensions.Configuration;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class EmailManager : IEmailService
    {
        private readonly SmtpClient _client;
        private readonly IConfiguration _configuration;
        public EmailManager(IConfiguration configuration)
        {
            _configuration = configuration;
            var emailSettings = _configuration.GetSection("EmailSettings");
            _client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(emailSettings["SenderEmail"], emailSettings["Password"])
            };
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            string senderEmail = _configuration["EmailSettings:SenderEmail"];
            var mailMessage = new MailMessage(senderEmail, email, subject, message);

            await _client.SendMailAsync(mailMessage);
        }
    }

}
