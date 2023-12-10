using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime SatisTarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; } 
        public virtual Urun Urun { get; set; }
        public virtual Cari Cari { get; set; }
        public virtual Personel Personel { get; set; } 

    }
}
