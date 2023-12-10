using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class Yapilacak
    {
        [Key]
        public int YapilacakId { get; set; }
        public string Baslik { get; set; }
        public bool Durum { get; set; }

    }
}
