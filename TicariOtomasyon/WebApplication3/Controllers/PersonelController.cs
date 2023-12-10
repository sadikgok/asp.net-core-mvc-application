using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models.Siniflar;

namespace WebApplication3.Controllers
{
    public class PersonelController : Controller
    {
        public IActionResult Index()
        {
            using (Context context = new Context())
            {
                var personel = context.Personels.Include(x => x.Departman).ToList();
                return View(personel);
            }
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            using (Context context = new Context())
            {

                List<SelectListItem> departman = (from d in context.Departmans.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = d.DepartmanAdi,
                                                      Value = d.DepartmanId.ToString(),
                                                  }).ToList();
                ViewBag.dgr = departman;
                return View();
            }

        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            using (Context context = new Context())
            {
                if (Request.Form.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetExtension(personel.PersonelGorseli.FileName);
                    var imageName = Guid.NewGuid() + dosyaAdi;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "/Image/", imageName);
                    var stream = new FileStream(location, FileMode.Create);
                    personel.PersonelGorseli.CopyTo(stream);

                    //string dosyaAdi = Path.GetFileName(Request.Form.Files[0].FileName);
                    //string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                    //string yol = "/Image/" + dosyaAdi + uzanti;
                    //var stream = new FileStream(yol, FileMode.Create);
                    //personel.PersonelGorseli.CopyTo(stream);
                    //stream.Close();
                }
                context.Personels.Add(personel);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
        }

        public ActionResult PersonelGetir(int id)
        {
            using (Context context = new Context())
            {
                List<SelectListItem> departman = (from d in context.Departmans.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = d.DepartmanAdi,
                                                      Value = d.DepartmanId.ToString()
                                                  }).ToList();
                ViewBag.dgr = departman;

                var personel = context.Personels.Find(id);
                return View("PersonelGetir", personel);
            }
        }

        public ActionResult PersonelGuncelle(Personel personel)
        {
            using (Context context = new Context())
            {
                var person = context.Personels.Find(personel.PersonelId);
                person.PersonelAdi = personel.PersonelAdi;
                person.PersonelSoyadi = personel.PersonelSoyadi;
                person.PersonelGorseli = personel.PersonelGorseli;
                person.Departman = personel.Departman;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
