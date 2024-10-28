using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ProyectoWindowsF.Controlador;
using ProyectoWindowsF.Data.ProyectoWindowsF.Data;
using ProyectoWindowsF.Modelos;


namespace ProyectoWindowsF
{
    public partial class catalogoForm : Form
    {
        private DataTable tabla;
        private ProductosController productosController;
        private static catalogoForm catalogo;
        private ventasForm formVentas;
        

        public catalogoForm()
        {
            InitializeComponent();
            Inicializar();
            productosController = new ProductosController();
            formVentas = new ventasForm();
            ConsultarBd();
            btnActualizar.Click += btnActualizar_Click;
            btnAgregar.Click += btnAgregar_Click;
            btnBuscar.Click += btnBuscar_Click;

        }



        private void Inicializar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Id", typeof(int)); 
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Precio", typeof(double)); 
            tabla.Columns.Add("Descripción", typeof(string));
            dgProducts.DataSource = tabla;
            dgProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }

        private void ConsultarBd()
        {
            List<Productos> productos = productosController.Cargar(); 
            tabla.Clear();
            foreach (var item in productos)
            {
                DataRow row = tabla.NewRow();
                row["Id"] = item.id_producto;
                row["Nombre"] = item.nombre;
                row["Precio"] = item.precio;
                row["Descripción"] = item.descripcion;
                tabla.Rows.Add(row);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgProducts.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                string nombre = filaSeleccionada.Cells["Nombre"].Value.ToString();
                double precio = Convert.ToDouble(filaSeleccionada.Cells["Precio"].Value);
                string descripcion = filaSeleccionada.Cells["Descripción"].Value.ToString();

                var formActualizar = Application.OpenForms.OfType<actualizarProducto>().FirstOrDefault();
                if (formActualizar == null)
                {
                    formActualizar = new actualizarProducto(idProducto, nombre, precio, descripcion);
                    formActualizar.ProductoActualizado += ConsultarBd;
                    formActualizar.Show();
                }
                else
                {
                    formActualizar.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para actualizar.");
            }
        }

        private void ConfigurarColumnasDataGridView()
        {
            dgProducts.Columns.Clear();
            dgProducts.Columns.Add("id_producto", "ID Producto");
            dgProducts.Columns.Add("nombre", "Nombre");
            dgProducts.Columns.Add("precio", "Precio");
            dgProducts.Columns.Add("descripcion", "Descripción");
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBuscar.Text.Trim();
            List<Productos> resultadosBusqueda = new List<Productos>();

            if (int.TryParse(criterioBusqueda, out int idBusqueda))
            {
                resultadosBusqueda = productosController.Buscar(idBusqueda);

                dgProducts.DataSource = null;
                dgProducts.Rows.Clear();

                ConfigurarColumnasDataGridView();

                if (resultadosBusqueda.Count > 0)
                {
                    foreach (var producto in resultadosBusqueda)
                    {
                        dgProducts.Rows.Add(
                            producto.id_producto,
                            producto.nombre,
                            producto.precio,
                            producto.descripcion
                        );
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron productos con el ID especificado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa un ID válido para buscar.");
            }
        }



        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                formVentas = new ventasForm();
                formVentas.TopLevel = false;
                formVentas.Visible = false;
                formVentas.FormBorderStyle = FormBorderStyle.None;
                formVentas.Dock = DockStyle.Fill;
                formVentas.ShowInTaskbar = false;

                panel.Controls.Clear();
                panel.Controls.Add(formVentas);
                formVentas.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public bool MenuVisible
        {
            get => menu.Visible; 
            set => menu.Visible = value;
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (catalogo == null || catalogo.IsDisposed)
            {
                catalogo = new catalogoForm();
                catalogo.TopLevel = false;
                catalogo.FormBorderStyle = FormBorderStyle.None;
                catalogo.Dock = DockStyle.Fill;
                catalogo.MenuVisible = false;
            }

            panel.Controls.Clear();
            panel.Controls.Add(catalogo);
            catalogo.Show();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var form = Application.OpenForms.OfType<agregarProductosForm>().FirstOrDefault();
            if (form == null)
            {
                form = new agregarProductosForm();
                form.ProductoGuardado += ConsultarBd; 
                form.Show();
            }
            else
            {
                form.BringToFront();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgProducts.SelectedRows[0];
                int idProducto = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                var result = MessageBox.Show("¿Estás seguro de que quieres eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    productosController.Eliminar(idProducto); 
                    ConsultarBd(); 
                    MessageBox.Show("Producto eliminado correctamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para eliminar.");
            }

        }


        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formVentas.ExportarExcel();

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
        }
    }
}
