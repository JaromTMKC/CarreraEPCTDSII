using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarreraEPCTDSII.Models.Entidades
{
    public class OCompraDetCarrera
    {
        [Key]
        [Display(Name ="ID")]
        public int IdOCompraDet { get; set; }

        [Required]
        [Display(Name ="Precio")]
        public float Precio { get; set; }

        [Required]
        [Display(Name ="Cantidad")]
        public float Cantidad { get; set; }

        [Required]
        [Display(Name ="Total")]
        public float Total { get; set; }

        public int IdOCompraCab {  get; set; }
        [ForeignKey("IdOCompraCab")]
        public virtual OCompraCabCarrera CompraCab { get; set; }

        public int IdArticulo { get; set; }
        [ForeignKey("IdProducto")]
        public virtual ProductoCarrera Producto {  get; set; }

        [Required]
        [Display(Name ="Registro")]
        public DateTime FechaRegistro { get; set; }
    }
}
