using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class YapilacakController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var yapilacak = context.Yapilacaks.ToList();
                return View(yapilacak);
            }

        }
    }
}
