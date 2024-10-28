using ProyectoWindowsF.Controlador;
using ProyectoWindowsF.Data;
using ProyectoWindowsF.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoWindowsF
{
    public partial class generarVenta : Form
    {
        private List<Productos> listaProductos;
        private ProductosController productosController;
        public generarVenta()
        {
            InitializeComponent();
            productosController = new ProductosController();
            this.Load += generarVenta_Load;
        }

        private void generarVenta_Load(object sender, EventArgs e)
        {
            CargarProductos();
            ConfigurarColumnasDataGridView();
        }

        private void ConfigurarColumnasDataGridView()
        {
  
            dg.Columns.Add("id_producto", "ID Producto");
            dg.Columns.Add("nombre", "Nombre");
            dg.Columns.Add("cantidad", "Cantidad");
            dg.Columns.Add("precio", "Precio");
            dg.Columns.Add("total", "Total");

        }


        private void CargarProductos()
        {
            listaProductos = productosController.Cargar();

            if (listaProductos != null && listaProductos.Count > 0)
            {
                foreach (var producto in listaProductos)
                {
                    Seleccionar.Items.Add(producto.nombre);
                }
            }
            else
            {
                MessageBox.Show("No hay productos disponibles para cargar.");
            }
        }

        private void Seleccionar_SelectedIndexChanged(object sender, EventArgs e)
        {
            var productoSeleccionado = Seleccionar.SelectedItem;
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (Seleccionar.SelectedItem != null && !string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                string nombreProducto = Seleccionar.SelectedItem.ToString();
                int cantidad;

                if (int.TryParse(txtCantidad.Text, out cantidad) && cantidad > 0)
                {
                    // Buscar el producto en la lista según el nombre seleccionado.
                    Productos productoSeleccionado = listaProductos.FirstOrDefault(p => p.nombre == nombreProducto);
                    Console.WriteLine(productoSeleccionado.id_producto + "AGREGADOOOOO");
                    if (productoSeleccionado != null)
                    {
                        dg.Rows.Add(
                         productoSeleccionado.id_producto,
                         productoSeleccionado.nombre,
                         cantidad,
                         productoSeleccionado.precio,
                         cantidad * productoSeleccionado.precio
                        );
                        dg.AllowUserToAddRows = false;


                    }
                    else
                    {
                        MessageBox.Show("Producto no encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingresa una cantidad válida.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto y una cantidad.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (dg.Rows.Count > 0)
            {
                List<ProductosVendidos> productosVendidos = new List<ProductosVendidos>();
                double montoTotal = 0;

                foreach (DataGridViewRow row in dg.Rows)
                {
                    if (row.IsNewRow) continue; 
                    if (row.Cells["id_producto"].Value == null || row.Cells["cantidad"].Value == null || row.Cells["precio"].Value == null)
                    {
                        MessageBox.Show("Hay filas con datos incompletos en el DataGridView.");
                        continue;
                    }

                    int idProducto = Convert.ToInt32(row.Cells["id_producto"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    double precio = Convert.ToDouble(row.Cells["precio"].Value);

                   
                    if (productosVendidos.Any(p => p.id_producto == idProducto))
                    {
                        MessageBox.Show($"El producto con ID {idProducto} ya ha sido agregado.");
                        continue; 
                    }

                    ProductosVendidos productoVendido = new ProductosVendidos
                    {
                        id_producto = idProducto,
                        cantidad = cantidad
                    };

                    productosVendidos.Add(productoVendido);
                    montoTotal += precio * cantidad; 
                }

                Ventas nuevaVenta = new Ventas
                {
                    fecha = DateTime.Now,
                    monto_total = montoTotal
                };

                var ventasController = new ventasController();
                ventasController.GuardarVenta(nuevaVenta, productosVendidos);

                MessageBox.Show("Venta guardada exitosamente.");
            }
            else
            {
                MessageBox.Show("No hay productos agregados para guardar en la venta.");
            }
        }




    }

}
