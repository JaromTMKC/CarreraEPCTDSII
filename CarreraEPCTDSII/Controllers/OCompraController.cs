using CarreraEPCTDSII.Data.AccesoDatos;
using CarreraEPCTDSII.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CarreraEPCTDSII.Controllers
{
    public class OCompraController : Controller
    {
        public string SemanaAño(DateTime Registro)
        {
            int añoActual = DateTime.Now.Year;
            float semana = (float)((Registro - new DateTime(añoActual, 1, 1)).TotalDays / 7);
            int semanaSalida = (int)Math.Round(semana, 2);

            return (semanaSalida + "");
        }

        public IActionResult ListadoOCompraCarrera()
        {
            var Listado = new DAOCompraDet();
            var model = Listado.GetCompraDet();
            return View(model);
        }

        public IActionResult Create()
        {
            var LCab = new DAOCompraCab();
            ViewBag.LCab = LCab.GetCompraCab();

            var LProducto = new DAProducto();
            ViewBag.LProducto = LProducto.GetProducto();

            return View();
        }

        [HttpPost]
        public IActionResult Create(OCompraDetCarrera Entity)
        {
            Entity.IdOCompraDet = 0;
            Entity.Total = (Entity.Cantidad * Entity.Precio);
            Entity.FechaRegistro = DateTime.Now;

            var InsertCompraDet = new DAOCompraDet();
            var model = InsertCompraDet.InsertCompraDet(Entity);

            if (model > 0)
            {
                return RedirectToAction("ListadoOCompraCarrera");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Detail(int id)
        {
            var LCab = new DAOCompraCab();
            ViewBag.LCab = LCab.GetCompraCab();

            var LProducto = new DAProducto();
            ViewBag.LProducto = LProducto.GetProducto();

            var DetailCompraDet = new DAOCompraDet();
            var model = DetailCompraDet.DetailCompraDet(id);

            if (model != null)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("ListadoOCompraCarrera");
            }
        }

        public IActionResult Edit(int id)
        {
            var CompraDet = new DAOCompraDet().DetailCompraDet(id);

            if (CompraDet == null)
            {
                return RedirectToAction("ListadoOCompraCarrera");
            }

            var LCab = new DAOCompraCab();
            ViewBag.LCab = LCab.GetCompraCab();

            var LProducto = new DAProducto();
            ViewBag.LProducto = LProducto.GetProducto();

            return View(CompraDet);
        }

        [HttpPost]
        public IActionResult Edit(OCompraDetCarrera Entity)
        {

            Entity.Total = (Entity.Cantidad * Entity.Precio);

            var EditCompraDet = new DAOCompraDet();
            var model = EditCompraDet.EditCompraDet(Entity);

            if (model > 0)
            {
                return RedirectToAction("ListadoOCOmpraCarrera");
            }
            else
            {
                return View(model);
            }

        }

        public IActionResult Delete(int id)
        {
            var CompraDet = new DAOCompraDet().DetailCompraDet(id);

            if (CompraDet == null)
            {
                return RedirectToAction("ListadoOCompraCarrera");
            }

            return View(CompraDet);
        }


        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var resultado = new DAOCompraDet().DeleteCompraDet(id);

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