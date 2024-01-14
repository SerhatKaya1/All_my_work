using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YemekTarifiApp.Core;
using YemekTarifiApp.Entity.Concrate.Identity;
using YemekTarifiApp.Web.EmailServices.Abstract;
using YemekTarifiApp.Web.Models.Dtos;

namespace YemekTarifiApp.Web.Controllers
{
	[AutoValidateAntiforgeryToken]
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly IEmailSender _emailSender;

		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}
		public IActionResult Login(string returnUrl = null)
		{
			return View(new LoginDto { ReturnUrl = returnUrl });
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginDto loginDto)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(loginDto.UserName);
				if (user == null)
				{
					ModelState.AddModelError("", "Böyle bir kullanıcı bulunamadı!");
					return View(loginDto);
				}
				//Bu noktada email onayı yapılıp yapılmadığını kontrol edeceğiz.
				//Eğer email onaylı ise login yaptıracağız, değil ise hatırlatacağız.
				var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, true, true);
				if (result.Succeeded)
				{
					return Redirect(loginDto.ReturnUrl ?? "~/");
				}
				ModelState.AddModelError("", "Email adresi ya da parola hatalı!");
			}
			return View(loginDto);
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		//[ValidateAntiForgeryToken]//İlgili cookienin sadece ait olduğu tarayıcı tarafından gönderilmesi halinde geçerli olmasını sağlar.
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			if (ModelState.IsValid)
			{
				var user = new User
				{
					FirstName = registerDto.FirstName,
					LastName = registerDto.LastName,
					UserName = registerDto.UserName,
					Email = registerDto.Email
				};
				var result = await _userManager.CreateAsync(user, registerDto.Password);
				if (result.Succeeded)
				{
					//Generate token(mail onayı için)
					var tokenCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var url = Url.Action("ConfirmEmail", "Account", new
					{
						userId = user.Id,
						token = tokenCode
					});

                    //Mailin gönderilme, onaylanma vs
                    //Yeni kayıt olan kullanıcıya varsayılan olarak User rolünü veriyoruz.
                    await _userManager.AddToRoleAsync(user, "User");
                    TempData["Message"] = Jobs.CreateMessage("Bilgi", "Hesabınız başarıyla oluşturulmuştur. Giriş yapabilirsiniz.", "success");
                    return RedirectToAction("Login", "Account");
				}
			}
			ModelState.AddModelError("", "Bilinmeyen bir hata oluştu, lütfen tekrar deneyiniz");
			return View(registerDto);
		}
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (userId == null || token == null)
			{
				ViewBag.Message("Geçersiz token ya da user bilgisi!");
				return View();
			}
			var user = await _userManager.FindByIdAsync(userId);
			if (user != null)
			{
				var result = await _userManager.ConfirmEmailAsync(user, token);
				if (result.Succeeded)
				{
                    TempData["Message"] = Jobs.CreateMessage("Başarılı", "Hesabınız başarıyla onaylandı. Giriş yapabilirsiniz.", "success");
                    return RedirectToAction("Login", "Account");
                }
			}
            TempData["Message"] = Jobs.CreateMessage("Hata", "Bir sorun oluştu ve hesabınız onaylanmadı. Lütfen admin ile iletişime geçiniz.", "danger");
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Lütfen mail adresinizi eksiksiz bir şekild giriniz.", "danger");
                return View();
            }
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Böyle kayıtlı bir mail adresi bulunamadı. Lütfen kontrol ederek, yeniden deneyiniz.", "danger");
                return View();
            }
            var tokenCode = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = tokenCode
            });
            await _emailSender.SendEmailAsync(
                email,
                "YemekTarifiApp Şifre Sıfırlama Linki",
                $"Lütfen parolanızı yenilemek için <a href='https://localhost:5262{url}'>tıklayınız.</a>"
                );
            TempData["Message"] = Jobs.CreateMessage("Bilgi", "Şifre sıfırlama linkiniz, mail adresinize gönderilmiştir. Lütfen mail adresinizi kontrol ediniz.", "info");
            return RedirectToAction("Login", "Account");
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            if (userId == null || token == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Bir sorun oluştu, lütfen daha sonra yeniden deneyiniz.", "danger");
                return RedirectToAction("Index", "Home");
            }
            var resetPasswordDto = new ResetPasswordDto
            {
                Token = token
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordDto);
            }
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                TempData["Message"] = Jobs.CreateMessage("Hata", "Böyle bir kullanıcı bulunamadı. Tekrar deneyiniz", "danger");
                return View(resetPasswordDto);
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Başarılı", "Parolanız başarıyla değiştirilmiştir. Giriş yapmayı deneyebilirsiniz.", "success");
                return RedirectToAction("Login", "Account");
            }
            TempData["Message"] = Jobs.CreateMessage("Hata", "Bir hata oluştu. Lütfen admin ile iletişime geçiniz.", "danger");
            return Redirect("~/");
        }
        public async Task<IActionResult> Manage(string id)
        {
            var name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            var user = await _userManager.FindByNameAsync(name);
            if (user == null) { return NotFound(); }
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });
            UserManageDto userManageDto = new UserManageDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                UserName = user.UserName,
                Email = user.Email,
                GenderSelectList = genderList
            };

            return View(userManageDto);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(UserManageDto userManageDto)
        {
            if (userManageDto == null) { return NotFound(); }
            var user = await _userManager.FindByIdAsync(userManageDto.Id);
            if (user == null) { return NotFound(); }

            user.FirstName = userManageDto.FirstName;
            user.LastName = userManageDto.LastName;
            user.UserName = userManageDto.UserName;
            user.Gender = userManageDto.Gender;
            user.Email = userManageDto.Email;
            user.DateOfBirth = userManageDto.DateOfBirth;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = Jobs.CreateMessage("Başarılı!", "Profiliniz başarıyla kaydedilmiştir.", "success");

            }

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });
            userManageDto.GenderSelectList = genderList;
            return View(userManageDto);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
