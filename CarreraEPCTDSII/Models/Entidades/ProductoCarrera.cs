using System.ComponentModel.DataAnnotations;

namespace CarreraEPCTDSII.Models.Entidades
{
    public class ProductoCarrera
    {
        [Key]
        [Display(Name = "ID")]
        public int IdProducto { get; set; }

        [Required]
        [Display(Name ="Nombre")]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name ="UM")]
        [MaxLength(15)]
        public string UM { get; set; }

        public virtual ICollection<OCompraDetCarrera> OCompraDet {  get; set; }
    }
}