using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoºMVC.Models;
using System.Web.Mvc;

namespace ProyectoºMVC.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()

        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.proveedor.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(" ", "error " + ex);
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities1())
            {
                var findUser = db.proveedor.Find(id);
                return View(findUser);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var findUser = db.proveedor.Find(id);
                    db.proveedor.Remove(findUser);
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
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    proveedor findUser = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor editUser)
        {
            try
            {

                using (var db = new inventario2021Entities1())
                {
                    proveedor user = db.proveedor.Find(editUser.id);
                   
                    user.nombre = editUser.nombre;
                    user.direccion = editUser.direccion;
                    user.telefono = editUser.telefono;
                    user.nombre_contacto = editUser.nombre_contacto;

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
