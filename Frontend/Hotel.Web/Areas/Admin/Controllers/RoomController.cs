using AutoMapper;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Room;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        readonly RoomApiService _roomApiService;
        readonly RoomValidator _validator;
        readonly IMapper _mapper;
        public RoomController(RoomApiService roomApiService, RoomValidator validations, IMapper mapper)
        {
            _roomApiService = roomApiService;
            _validator = validations;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var rooms = await _roomApiService.GetAllRoomsAsync();
            var roomDTOs = _mapper.Map<List<RoomGetPutDTO>>(rooms);

            return View(roomDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoomPostDTO model)
        {
            var room = _mapper.Map<Room>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _roomApiService.AddRoomAsync(room, model.ImageFile);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RoomGetPutDTO model)
        {
            var room = _mapper.Map<Room>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _roomApiService.UpdateRoomAsync(room);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _roomApiService.DeleteRoomAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _roomApiService.DestroyRoomAsync(id);

            return RedirectToAction("Index");
        }
    }
}