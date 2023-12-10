using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }
        public string UrunAd { get; set; }
        public string UrunBilgi { get; set; } 
    }
}
