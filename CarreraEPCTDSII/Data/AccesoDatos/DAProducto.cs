using CarreraEPCTDSII.Models.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CarreraEPCTDSII.Data.AccesoDatos
{
    public class DAProducto
    {
        public IEnumerable<ProductoCarrera> GetProducto()
        {
            var ListadoProducto = new List<ProductoCarrera>();
            using (var db = new ApplicationDbContext())
            {
                ListadoProducto = db.Producto.ToList();
            }
            return ListadoProducto;
        }
        public int InsertProducto(ProductoCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Add(Entity);
                db.SaveChanges();
                resultado = Entity.IdProducto;
            }

            return resultado;
        }

        public ProductoCarrera DetailProducto(int id)
        {
            var resultado = new ProductoCarrera();
            using (var db = new ApplicationDbContext())
            {
                resultado = db.Producto.Where(item => item.IdProducto == id).FirstOrDefault();
            }
            return resultado;
        }

        public int EditProducto(ProductoCarrera Entity)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                db.Producto.Attach(Entity);
                db.Entry(Entity).State = EntityState.Modified;
                db.SaveChanges();
                resultado = Entity.IdProducto;
            }

            return resultado;
        }

        public int DeleteProducto(int id)
        {
            var resultado = 0;
            using (var db = new ApplicationDbContext())
            {
                var Producto = db.Producto.Find(id);

                if (Producto != null)
                {
                    db.Producto.Remove(Producto);
                    db.SaveChanges();
                    resultado = Producto.IdProducto;
                }
            }

            return resultado;
        }
    }
}
