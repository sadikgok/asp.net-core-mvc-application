using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsin")]
        public string CariAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Bu alanı boş geçemezsin")]
        public string CariSoyadi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string CariUnvani { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSehir { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariMail { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSifre { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariTelefon { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}
