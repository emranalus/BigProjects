using FairWorks.Models.DTOs;
using FairWorks.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FairWorks.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        //private readonly RoleManager<AppUser> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IPasswordHasher<AppUser> passwordHasher;

        public AccountController(UserManager<AppUser> userManager,
            //RoleManager<AppUser> roleManager,
            SignInManager<AppUser> signInManager,
            IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            //this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.passwordHasher = passwordHasher;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterDTO());
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            if (ModelState.IsValid)
            {
                // registerDTO ile yeni kullanıcı objesi oluştur ve verebildiğin verileri ver
                AppUser appUser = new AppUser { UserName = registerDTO.UserName, Email = registerDTO.Email };

                // userManager ile Create metodunu kullanarak kullanıcı oluştur ve şifreyi burda ver
                var result = await userManager.CreateAsync(appUser, registerDTO.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View(registerDTO);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new LoginDTO());
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {

            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByNameAsync(loginDTO.UserName);

                var result = await signInManager.PasswordSignInAsync(appUser, appUser.PasswordHash, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış!");

            }

            return View(loginDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            // User.Identity ile şu anda giriş yapmış kullanıcıya erişilebilir
            // Bu giriş yapmış kullanıcı bulunur ve boş bir appUser objesine atılır
            AppUser appUser = await userManager.FindByNameAsync(User.Identity.Name);

            UserUpdateDTO updateDTO = new UserUpdateDTO(appUser);

            return View(updateDTO);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Edit(UserUpdateDTO updateDTO)
        {

            if (ModelState.IsValid)
            {

                AppUser appUser = await userManager.FindByNameAsync(updateDTO.UserName);
                appUser.UserName = updateDTO.UserName;

                if (updateDTO.Password != null)
                {
                    appUser.PasswordHash = passwordHasher.HashPassword(appUser, appUser.PasswordHash);
                }

                var result = await userManager.UpdateAsync(appUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(updateDTO);
        }

    }
}
