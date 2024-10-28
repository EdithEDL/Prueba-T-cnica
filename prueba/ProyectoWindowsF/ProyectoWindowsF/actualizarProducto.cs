using ProyectoWindowsF.Controlador;
using ProyectoWindowsF.Modelos;
using System;
using System.Windows.Forms;

namespace ProyectoWindowsF
{
    public partial class actualizarProducto : Form
    {

        private int idProducto; 
        private ProductosController productosController;
        public event Action ProductoActualizado;

        public actualizarProducto(int id, string nombre, double precio, string descripcion)
        {
            InitializeComponent();
            productosController = new ProductosController();

            txtNombre.Text = nombre;
            txtPrecio.Text = precio.ToString();
            txtDes.Text = descripcion;

            idProducto = id; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Productos productoActualizado = new Productos
                {
                    id_producto = idProducto,
                    nombre = txtNombre.Text,
                    precio = Convert.ToDouble(txtPrecio.Text),
                    descripcion = txtDes.Text
                };

                productosController.Editar(productoActualizado);
                MessageBox.Show("Producto actualizado correctamente.");
               
                ProductoActualizado?.Invoke();
                this.Close(); 
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el producto: " + ex.Message);
            }
        }

    }
    
}
