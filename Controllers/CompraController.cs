using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoºMVC.Models;
using System.Web.Mvc;

namespace ProyectoºMVC.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.compra.ToList());
            }

        }
        public  ActionResult ListaCliente()
        {
            using (var db = new inventario2021Entities1())
            
                return PartialView(db.cliente.ToList());
            

        }
        public ActionResult ListaUsuario()
        {
            
            using (var db=new inventario2021Entities1())
              
              return PartialView(db.usuario.ToList());
              
           
                
            
        }
        public static string NombreUsuario(int NomUsu)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.usuario.Find(NomUsu).nombre;
            }
        }
        public static string NombreCliente(int NomCli)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.cliente.Find(NomCli).nombre;
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(compra compra)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.compra.Add(compra);
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
                var findUser = db.compra.Find(id);
                return View(findUser);
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var findUser = db.compra.Find(id);
                    db.compra.Remove(findUser);
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
                    compra findUser = db.compra.Where(a => a.id == id).FirstOrDefault();
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
        public ActionResult Edit(compra editUser)
        {
            try
            {

                using (var db = new inventario2021Entities1())
                {
                    compra user = db.compra.Find(editUser.id);

                    user.fecha= editUser.fecha;
                    user.total = editUser.total;
                    user.id_usuario = editUser.id_usuario;
                    user.id_cliente = editUser.id_cliente;
                   

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