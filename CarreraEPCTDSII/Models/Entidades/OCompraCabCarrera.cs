using System.ComponentModel.DataAnnotations;

namespace CarreraEPCTDSII.Models.Entidades
{
    public class OCompraCabCarrera
    {
        [Key]
        [Display(Name ="ID")]
        public int IdOCompraCab { get; set; }

        [Required]
        [Display(Name ="Proveedor")]
        [MaxLength(100)]
        public string Proveedor { get; set; }

        [Required]
        [Display(Name ="Registro")]
        public DateTime FechaRegistro { get; set; }

        public virtual ICollection<OCompraDetCarrera> OCompraDet {  get; set; }
    }
}