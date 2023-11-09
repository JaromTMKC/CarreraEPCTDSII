using CarreraEPCTDSII.Data.AccesoDatos;
using CarreraEPCTDSII.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CarreraEPCTDSII.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {   
            var Listado = new DAProducto();
            var model = Listado.GetProducto();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductoCarrera Entity)
        {
            Entity.IdProducto = 0;
            
            var InsertProducto = new DAProducto();
            var model = InsertProducto.InsertProducto(Entity);

            if (model > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Detail(int id)
        {
            var DetailProducto = new DAProducto();
            var model = DetailProducto.DetailProducto(id);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Edit(int id)
        {
            var Producto = new DAProducto().DetailProducto(id);

            if (Producto == null)
            {
                return RedirectToAction("Index");
            }

            return View(Producto);
        }

        [HttpPost]
        public IActionResult Edit(ProductoCarrera Entity)
        {
            var EditProducto = new DAProducto();
            var model = EditProducto.EditProducto(Entity);

            if (model > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var Producto = new DAProducto().DetailProducto(id);

            if (Producto == null)
            {
                return RedirectToAction("Index");
            }

            return View(Producto);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var resultado = new DAProducto().DeleteProducto(id);

            if (resultado > 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
    }
}
