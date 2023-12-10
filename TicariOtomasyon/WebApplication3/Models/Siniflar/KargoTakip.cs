using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }
        public string TakipKodu { get; set; }
        public string Aciklama { get; set; }
        public DateTime TarihZaman { get; set; }
    }
}
