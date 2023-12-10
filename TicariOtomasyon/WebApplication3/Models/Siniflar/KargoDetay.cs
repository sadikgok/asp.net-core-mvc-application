using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public  int KargoDetayId { get; set; }
        public string Aciklama { get; set; }
        public string TakipKodu { get; set; }
        public string Personel { get; set; }
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }

    }
}
