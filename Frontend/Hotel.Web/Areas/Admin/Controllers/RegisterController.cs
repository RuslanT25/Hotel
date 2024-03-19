using Hotel.Entity.DTOs.Register;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterPostDTO registerPostDTO)
        {
            var validator = new RegisterValidator();
            var validationResult = validator.Validate(registerPostDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            if (!ModelState.IsValid) { return View(); }

            var appUser = new AppUser()
            {
                Name = registerPostDTO.Name,
                Surname = registerPostDTO.Surname,
                Email = registerPostDTO.Email
            };

            var result = await _userManager.CreateAsync(appUser, registerPostDTO.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
