using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class UrunDetayController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                //var urun = context.Uruns.Where(u => u.UrunId == 1).ToList();
                UrunDetay urunDetay = new UrunDetay();
                urunDetay.Urun = context.Uruns.Where(u => u.UrunId == 1).ToList();
                urunDetay.Detay = context.Detays.Where(y => y.DetayId == 1).ToList();

                return View(urunDetay);
            }

        }
    }
}
