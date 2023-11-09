using CarreraEPCTDSII.Data.AccesoDatos;
using CarreraEPCTDSII.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CarreraEPCTDSII.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            var Listado = new DAOCompraCab();
            var model = Listado.GetCompraCab();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OCompraCabCarrera Entity)
        {
            Entity.IdOCompraCab = 0;
            Entity.FechaRegistro = DateTime.Now;

            var InsertSucursal = new DAOCompraCab();
            var model = InsertSucursal.InsertSucursal(Entity);

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
            var DetailSucursal = new DAOCompraCab();
            var model = DetailSucursal.DetailSucursal(id);

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
            var Sucursal = new DAOCompraCab().DetailSucursal(id);

            if (Sucursal == null)
            {
                return RedirectToAction("Index");
            }

            return View(Sucursal);
        }

        [HttpPost]
        public IActionResult Edit(OCompraCabCarrera Entity)
        {
            var EditSucursal = new DAOCompraCab();
            var model = EditSucursal.EditSucursal(Entity);

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
            var Sucursal = new DAOCompraCab().DetailSucursal(id);

            if (Sucursal == null)
            {
                return RedirectToAction("Index");
            }

            return View(Sucursal);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var resultado = new DAOCompraCab().DeleteSucursal(id);

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
