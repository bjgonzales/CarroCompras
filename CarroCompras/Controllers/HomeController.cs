using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarroCompras.Models;

namespace CarroCompras.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult List()
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            
            return View(mc.ObtenerClientes());
        }

        [HttpGet]
        public ActionResult Crear()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Crear(Clientes clientes)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            mc.Crear(clientes);
            ModelState.Clear();

            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            MantenimientoCliente mc = new MantenimientoCliente();
            return View(mc.ObtenerCliente(id));
        }

        [HttpPost]
        public ActionResult Eliminar(Clientes clientes)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            mc.Eliminar(clientes);
            return View();
        }

        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            MantenimientoCliente mc = new MantenimientoCliente();

            return View(mc.ObtenerCliente(id));
        }

        [HttpPost]
        public ActionResult Actualizar(Clientes clientes)
        {
            MantenimientoCliente mc = new MantenimientoCliente();
            mc.Actualizar(clientes);
            return View();
        }


    }
}