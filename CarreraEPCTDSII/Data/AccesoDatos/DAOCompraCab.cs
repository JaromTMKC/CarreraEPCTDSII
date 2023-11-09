using CarreraEPCTDSII.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CarreraEPCTDSII.Data.AccesoDatos
{
    public class DAOCompraCab
    {
        public IEnumerable<OCompraCabCarrera> GetCompraCab()
        {
            var ListadoCompraCab = new List<OCompraCabCarrera>();
            using (var db = new ApplicationDbContext())
            {
                ListadoCompraCab = db.CompraCab.ToList();
            }
            return ListadoCompraCab;
        }

        public int InsertSucursal(OCompraCabCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Entity);
                db.SaveChanges();
                resultado = Entity.IdOCompraCab;
            }

            return resultado;
        }

        public OCompraCabCarrera DetailSucursal(int id)
        {
            var resultado = new OCompraCabCarrera();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.CompraCab.Where(item => item.IdOCompraCab == id).FirstOrDefault();
            }
            return resultado;
        }

        public int EditSucursal(OCompraCabCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.CompraCab.Attach(Entity);
                db.Entry(Entity).State = EntityState.Modified;
                db.Entry(Entity).Property(item => item.FechaRegistro).IsModified = false;
                db.SaveChanges();
                resultado = Entity.IdOCompraCab;
            }

            return resultado;
        }

        public int DeleteSucursal(int id)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                var Sucursal = db.CompraCab.Find(id);

                if (Sucursal != null)
                {
                    db.CompraCab.Remove(Sucursal);
                    db.SaveChanges();
                    resultado = Sucursal.IdOCompraCab;
                }
            }

            return resultado;
        }
    }
}
