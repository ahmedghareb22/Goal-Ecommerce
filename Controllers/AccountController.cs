using Goal.Models;
using Goal.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace Goal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IWebHostEnvironment _environment;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager, IWebHostEnvironment hostEnvironment)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this._environment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return RedirectToAction("Register");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterViewModel registerViewModel)
        {


            if(ModelState.IsValid)
            {
                var uploadFolder = Path.Combine(_environment.WebRootPath, "img");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(registerViewModel.Photo.FileName); // استخدام GUID لاسم فريد
                var fullPath = Path.Combine(uploadFolder, fileName);

                // التأكد من وجود المجلد
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // نسخ الملف إلى المجلد
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    registerViewModel.Photo.CopyTo(fileStream);
                }
                AppUser appUser = new AppUser
                {
                    Email = registerViewModel.Email,
                    PasswordHash = registerViewModel.Password,
                    BirthDate = registerViewModel.BirthDate,
                    Img = fileName,
                    UserName = registerViewModel.UserName,
                    FullName = registerViewModel.FullName,
                    PhoneNumber = registerViewModel.Phone,
                    UserAddresses = new UserAddress { Adress = registerViewModel.Adress, City = registerViewModel.city },
                    Carts = new Cart(),
                    WishLists = new WishList()
                    
                };
                IdentityResult result= await _userManager.CreateAsync(appUser,registerViewModel.Password);
                if (result.Succeeded)
                {
                    List<Claim> Claims = new List<Claim>();
                    Claims.Add(new Claim("UserPhoto", appUser.Img));
                    await _userManager.AddToRoleAsync(appUser, "User");
                    await signInManager.SignInWithClaimsAsync(appUser, isPersistent: false, Claims);


                 /* await  signInManager.SignInAsync(appUser, isPersistent: false);*/
                    return RedirectToAction("Index","Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("Register");
        }




        [HttpPost]
        [ValidateAntiForgeryToken]//requets.form['_requetss]
        public async Task<IActionResult> SaveLogin(LoginViewModel userViewModel)
        {
            if (ModelState.IsValid == true)
            {
                //check found 
                AppUser appUser =
                    await _userManager.FindByEmailAsync(userViewModel.Email);
                if (appUser != null)
                {
                    bool found =
                         await _userManager.CheckPasswordAsync(appUser, userViewModel.Password);
                    if (found == true)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("UserPhoto", appUser.Img));

                        await signInManager.SignInWithClaimsAsync(appUser, userViewModel.RememberMe, Claims);
/*                        await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
*/                        //await signInManager.SignInAsync(appUser, userViewModel.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Username OR PAssword wrong");
                //create cookie
            }
            return View("Register");
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
