using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWindowsF.Modelos
{
    public class Ventas
    {
        [Key]
        public int id_ventas { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        public double monto_total { get; set; }

        public ICollection<ProductosVendidos> productosVendidos { get; set; }
    }
}
