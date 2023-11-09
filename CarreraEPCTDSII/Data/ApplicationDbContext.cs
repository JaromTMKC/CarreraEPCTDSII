using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarreraEPCTDSII.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarreraEPCTDSII.Models.Entidades.OCompraDetCarrera>
            CompraDet
        { get; set; }

        public virtual DbSet<CarreraEPCTDSII.Models.Entidades.ProductoCarrera>
            Producto
        {  get; set; }

        public virtual DbSet<CarreraEPCTDSII.Models.Entidades.OCompraCabCarrera>
            CompraCab
        { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=JAROMTMKA;" +
                "Database=DBCompras2023DSI;" + 
                "User id=sa;" + 
                "Password=1234;" + 
                "MultipleActiveResultSets=true;");
        }
    }
}