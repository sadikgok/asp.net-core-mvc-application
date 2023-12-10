using Humanizer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{

    [AllowAnonymous]
    public class LoginController : Controller
    {
        //private readonly SignInManager<Cari> _signInManager;

        //public LoginController(SignInManager<Cari> signInManager)
        //{
        //    _signInManager = signInManager;
        //}


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Cari cari)
        {
            using (Context context = new Context())
            {
                context.Add(cari);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Cari cari)
        {
            using (Context context = new Context())
            {
                //var result = await _signInManager.PasswordSignInAsync(cari.CariMail, cari.CariSifre, false, false);
                //if (result.Succeeded)
                //{
                //    return RedirectToAction("Index", "CariPanel");
                //}
                //return View();
                var caris = context.Caris.FirstOrDefault(x => x.CariMail == cari.CariMail && x.CariSifre == cari.CariSifre);
                if (caris != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, cari.CariMail)
                    };
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    HttpContext.Session.SetString("CariMail", cari.CariMail);
                    return RedirectToAction("Index", "CariPanel");
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin admin)
        {
            using (Context context = new Context())
            {
                var adm = context.Admins.FirstOrDefault(x => x.KullaniciAdi == admin.KullaniciAdi && x.Sifre == admin.Sifre);
                if (adm != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,admin.KullaniciAdi)
                    };
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal claimprincipal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(claimprincipal);
                    HttpContext.Session.SetString("KullaniciAdi", adm.KullaniciAdi);
                    return RedirectToAction("Index", "CariPanel");
                }
            }
            return View();
        }
    }
}
