using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoºMVC.Models;
using System.Web.Mvc;

namespace ProyectoºMVC.Controllers
{
    public class Producto_compraController : Controller
    {
        // GET: Producto_compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.producto_compra.ToList());
            }

        }

        public static int NombreCompra(int idcompra)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.compra.Find(idcompra).id;
            }
        }

        public static string NombreProducto(int idproducto)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.producto.Find(idproducto).nombre;
            }
        }

        public ActionResult ListarCompra()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public ActionResult ListarProducto()
        {
            using (var db = new inventario2021Entities1())
            {
                return PartialView(db.producto.ToList());
            }
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.producto_compra.Add(producto_Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.producto_compra.Find(id));
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                producto_compra producto_compra_Edit = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(producto_compra_Edit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_compra producto_compra)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    producto_compra user  = db.producto_compra.Find(producto_compra.id);

                    user.id_compra= producto_compra.id_compra;
                    user.id_producto = producto_compra.id_producto;
                    user.cantidad = producto_compra.cantidad;
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    producto_compra producto_Compra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(producto_Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}