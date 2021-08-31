using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoºMVC.Models
{
    public class ReporteCliente
    {
        public String nombreCliente { get; set; }
        public String   documentoCliente { get; set; }
        public DateTime fecha_Compra { get; set; }
        public int idUsuario{ get; set; }
        public int totalCompra { get; set; }
     
    }
}