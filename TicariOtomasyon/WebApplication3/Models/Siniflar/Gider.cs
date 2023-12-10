using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }
        public string GiderAciklama { get; set; }
        public DateTime GiderTarih { get; set; }
        public decimal GiderTutar { get; set; }

    }
}
