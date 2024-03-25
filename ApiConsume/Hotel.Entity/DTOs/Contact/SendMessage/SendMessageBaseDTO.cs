using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Contact.SendMessage
{
    public class SendMessageBaseDTO
    {
        public string Subject { get; set; }
        public string Message { get; set; }
        public string RecieverName { get; set; }
        public string RecieverEmail { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }
        public DateTime Date { get; set; }
    }
}
