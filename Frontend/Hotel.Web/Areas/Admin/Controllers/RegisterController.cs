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
        readonly UserManager<AppUser> _userManager;
        readonly RegisterValidator _registerValidator;
        public RegisterController(UserManager<AppUser> userManager, RegisterValidator registerValidator)
        {
            _userManager = userManager;
            _registerValidator = registerValidator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterPostDTO registerPostDTO)
        {
            var validationResult = await _registerValidator.ValidateAsync(registerPostDTO);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();  
            }

            var appUser = new AppUser()
            {
                Name = registerPostDTO.Name,
                Surname = registerPostDTO.Surname,
                UserName = registerPostDTO.Email,
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
