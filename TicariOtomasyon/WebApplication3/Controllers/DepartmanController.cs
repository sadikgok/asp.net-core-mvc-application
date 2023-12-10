using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class DepartmanController : Controller
    {
        Context _context = new Context();
        public IActionResult Index()
        {
            var departman = _context.Departmans.Where(x => x.Durum == true).ToList();
            return View(departman);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            _context.Departmans.Add(departman);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var deparman = _context.Departmans.Find(id);
            deparman.Durum = false;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = _context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var dept = _context.Departmans.Find(departman.DepartmanId);
            dept.DepartmanAdi = departman.DepartmanAdi;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            using (Context context = new Context())
            {
                List<Personel> list = _context.Personels.Where(x => x.DepartmanId == id).ToList();
                var dpt = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAdi).FirstOrDefault();
                ViewBag.d = dpt;
                return View(list);
            }
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            using (Context context = new Context())
            {
                var degerler = context.SatisHarekets.Include(u => u.Urun).Include(c => c.Cari).Include(p => p.Personel)
                    .Where(x => x.PersonelId == id).ToList();
                var per = context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAdi + " " + y.PersonelSoyadi).FirstOrDefault();
                ViewBag.dpers = per;
                return View(degerler);
            }
        }
    }
}
