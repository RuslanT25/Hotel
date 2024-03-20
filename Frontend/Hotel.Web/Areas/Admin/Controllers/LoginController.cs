using Hotel.Entity.DTOs.Login;
using Hotel.Entity.Models;
using Hotel.Web.Validations.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        readonly SignInManager<AppUser> _signInManager;
        readonly LoginValidator _loginValidator;
        public LoginController(SignInManager<AppUser> signInManager, LoginValidator validationRules)
        {
            _signInManager = signInManager;
            _loginValidator = validationRules;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginPostDTO model)
        {
            var validationResult = await _loginValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(model.Mail, model.Password, false, false);
            if(result.Succeeded) 
            { 
                return RedirectToAction("Index", "Room"); 
            }

            return View();
        }
    }
}
