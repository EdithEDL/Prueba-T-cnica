using ProyectoWindowsF.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWindowsF.Modelos
{
    public class ProductosVendidos
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Ventas")]
        public int id_venta { get; set; }

        [ForeignKey("Productos")]
        public int id_producto { get; set; }

        [Required]
        public int cantidad { get; set; }

        public Ventas Venta { get; set; }
        public Productos Producto { get; set; }
    }
}
