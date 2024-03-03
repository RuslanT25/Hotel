using FluentValidation;
using Hotel.Entity.DTOs.Room;

namespace Hotel.Web.Validations.Room
{
    public class RoomValidator : AbstractValidator<RoomBaseDTO>
    {
        public RoomValidator()
        {
            
        }
    }
}
