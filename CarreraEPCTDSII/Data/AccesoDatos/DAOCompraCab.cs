using CarreraEPCTDSII.Models.Entidades;

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
    }
}
