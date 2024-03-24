using Hotel.Entity.DTOs.Contact;
using Hotel.Entity.DTOs.Subscribe;

namespace Hotel.Web.ViewModels
{
    public class ContactVM
    {
        public SubscribePostDTO Subscribe { get; set; }
        public ContactPostDTO Contact { get; set; }
    }
}
