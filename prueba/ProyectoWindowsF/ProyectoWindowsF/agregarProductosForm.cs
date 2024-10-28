using ProyectoWindowsF.Controlador;
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
    public partial class agregarProductosForm : Form
    {
        private ProductosController productosController;
        
        public event Action ProductoGuardado;
        public agregarProductosForm()
        {
            InitializeComponent();
            productosController = new ProductosController();
        }

 

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                double precio = Convert.ToDouble(txtPrecio.Text); 
                string descripcion = txtDes.Text;

                Productos nuevoProducto = new Productos
                {
                    nombre = nombre,
                    precio = precio,
                    descripcion = descripcion
                };

                productosController.Guardar(nuevoProducto);
                MessageBox.Show("Producto guardado correctamente.");

                ProductoGuardado?.Invoke();

                txtNombre.Clear();
                txtPrecio.Clear();
                txtDes.Clear();
                
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            this.Close();
        }

    }
    
}
