using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoWindowsF.Modelos
{
    public class Productos
    {
        [Key]
        public int id_producto { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public double precio { get; set; }

        [Required]
        public string descripcion { get; set; }

        public ICollection<ProductosVendidos> productosVendidos { get; set; }
    }
}
