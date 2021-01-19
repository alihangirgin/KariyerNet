using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KariyerNet.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        #region LoginEmployer
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginEmployer(string returnUrl = null)
        {
            // Daha önceden var olan cookie temizlenir, başarılı bir giriş yapılabilmesi için.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginEmployer(LoginEmployerViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanici giris yapti.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Basarısız giriş denemesi.");
                    return View(model);
                }
            }

            return View(model);
        }
        #endregion


        #region LoginEmployer
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> LoginEmployee(string returnUrl = null)
        {
            // Daha önceden var olan cookie temizlenir, başarılı bir giriş yapılabilmesi için.
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginEmployee(LoginEmployeeViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanici giris yapti.");
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Basarısız giriş denemesi.");
                    return View(model);
                }
            }

            return View(model);
        }
        #endregion


        #region RegisterEmployer
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterEmployer(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployer(RegisterEmployerViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email, CreateDate = DateTime.Now };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanıcı başarıyla oluştu.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var checkResult = await _userManager.AddToRoleAsync(user, "Employer");
                    code = HttpUtility.UrlEncode(code);
                    var callbackUrl =
                        string.Concat(Request.Scheme, "://", Request.Host, Url.Action("ConfirmEmail", "Account", null), "?code=", code, "&userId=", user.Id);

                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    //await _signInManager.SignInAsync(user, isPersistent: false);


                    _logger.LogInformation("Kullanıcı başarıyla oluştu.");



                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // sorun olursa tekrar ekran render olur
            return View(model);
        }
        #endregion

        #region RegisterEmployee
        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterEmployee(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterEmployee(RegisterEmployeeViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.UserName, Email = model.Email, CreateDate = DateTime.Now , NameSurname=model.NameSurname};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Kullanıcı başarıyla oluştu.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var checkResult = await _userManager.AddToRoleAsync(user, "Employee");
                    code = HttpUtility.UrlEncode(code);
                    var callbackUrl =
                        string.Concat(Request.Scheme, "://", Request.Host, Url.Action("ConfirmEmail", "Account", null), "?code=", code, "&userId=", user.Id);

                    //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    //await _signInManager.SignInAsync(user, isPersistent: false);


                    _logger.LogInformation("Kullanıcı başarıyla oluştu.");



                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // sorun olursa tekrar ekran render olur
            return View(model);
        }

        #endregion


        #region Logout

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().ConfigureAwait(true);

            _logger.LogInformation("Kullanici cikis yapti.");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        #endregion






        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }


    }
}

