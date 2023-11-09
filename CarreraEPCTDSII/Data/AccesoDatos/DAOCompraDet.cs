using CarreraEPCTDSII.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CarreraEPCTDSII.Data.AccesoDatos
{
    public class DAOCompraDet
    {
        public ICollection<OCompraDetCarrera> GetCompraDet()
        {
            var ListadoCompraDet = new List<OCompraDetCarrera>();
            using (var db = new ApplicationDbContext())
            {
                ListadoCompraDet = db.CompraDet.Include(item => item.CompraCab).Include(item => item.Producto).ToList();
            }
            return ListadoCompraDet;
        }

        public int InsertCompraDet(OCompraDetCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Entity);
                db.SaveChanges();
                resultado = Entity.IdOCompraDet;
            }

            return resultado;
        }

        public OCompraDetCarrera DetailCompraDet(int id)
        {
            var resultado = new OCompraDetCarrera();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.CompraDet.Where(item => item.IdOCompraDet == id).FirstOrDefault();
            }
            return resultado;
        }

        public int EditCompraDet(OCompraDetCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.CompraDet.Attach(Entity);
                db.Entry(Entity).State = EntityState.Modified;
                db.Entry(Entity).Property(item => item.FechaRegistro).IsModified = false;
                db.SaveChanges();
                resultado = Entity.IdOCompraDet;
            }

            return resultado;
        }

        public int DeleteCompraDet(int id)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                var compraDet = db.CompraDet.Find(id);

                if (compraDet != null)
                {
                    db.CompraDet.Remove(compraDet);
                    db.SaveChanges();
                    resultado = compraDet.IdOCompraDet;
                }
            }

            return resultado;
        }
    }
}