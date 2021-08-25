﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoºMVC.Models;
using System.Web.Mvc;

namespace ProyectoºMVC.Controllers
{
    public class Producto_ImagenController : Controller
    {
        // GET: Producto_Imagen
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities1())
            {
                return View(db.producto_imagen.ToList());
            }
        }
        public ActionResult Productos()
        {

            using (var db = new inventario2021Entities1())

                return PartialView(db.producto.ToList());




        }
        public static string NombreProducto(int NomPro)
        {
            using (var db = new inventario2021Entities1())
            {
                return db.producto.Find(NomPro).nombre;
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_imagen producto_imagen)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    db.producto_imagen.Add(producto_imagen);
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
                var findUser = db.producto_imagen.Find(id);
                db.producto_imagen.Remove(findUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    var findUser = db.producto_imagen.Find(id);
                    db.producto_imagen.Remove(findUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities1())
                {
                    producto_imagen findUser = db.producto_imagen.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(producto_imagen editUser)
        {
            try
            {

                using (var db = new inventario2021Entities1())
                {
                    producto_imagen user = db.producto_imagen.Find(editUser.id);

                    user.imagen = editUser.imagen;
                    user.id_producto = editUser.id_producto;
                 


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