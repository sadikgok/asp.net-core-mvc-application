using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }
    }
}
