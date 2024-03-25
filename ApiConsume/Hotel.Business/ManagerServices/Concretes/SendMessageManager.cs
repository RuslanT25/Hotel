using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class SendMessageManager : BaseManager<SendMessage>, ISendMessageService
    {
        readonly ISendMessageRepository _messageRepository;
        public SendMessageManager(ISendMessageRepository sendMessageRepository) : base(sendMessageRepository)
        {
            _messageRepository = sendMessageRepository;
        }
    }
}
