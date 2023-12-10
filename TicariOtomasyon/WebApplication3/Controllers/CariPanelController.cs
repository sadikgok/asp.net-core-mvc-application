using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    [Authorize]
    [AllowAnonymous]
    public class CariPanelController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
                return View();
        }

        public IActionResult Index(Cari cari)
        {
            using (Context context = new Context())
            {
                //var mail = HttpContext.Session.SetString("Session", cari.CariMail);
                return View();
            }

        }
    }
}
