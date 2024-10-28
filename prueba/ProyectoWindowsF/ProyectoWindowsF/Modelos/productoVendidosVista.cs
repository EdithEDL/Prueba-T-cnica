using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWindowsF.Modelos
{
    internal class ProductoVendidosVista
    {
        public int id_venta { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }
        public double monto_total { get; set; }
        public DateTime fecha { get; set; }
    }
}
