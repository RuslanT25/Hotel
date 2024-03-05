using AutoMapper;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Service;
using Hotel.WebApi.Services.WebApiServices;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        readonly ServiceApiService _serviceApiService;
        readonly ServiceValidator _validator;
        readonly IMapper _mapper;
        public ServiceController(ServiceApiService serviceApiService, ServiceValidator validations, IMapper mapper)
        {
            _serviceApiService = serviceApiService;
            _validator = validations;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var services = await _serviceApiService.GetAllServices();
            var serviceDTOs = _mapper.Map<List<ServiceGetPutDTO>>(services);

            return View(serviceDTOs);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ServicePostDTO model)
        {
            var service = _mapper.Map<Service>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _serviceApiService.AddServiceAsync(service);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ServiceGetPutDTO model)
        {
            var service = _mapper.Map<Service>(model);
            var result = _validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            await _serviceApiService.UpdateServiceAsync(service);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _serviceApiService.DeleteServiceAsync(id);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Destroy(int id)
        {
            await _serviceApiService.DestroyServiceAsync(id);

            return RedirectToAction("Index");
        }
    }
}
