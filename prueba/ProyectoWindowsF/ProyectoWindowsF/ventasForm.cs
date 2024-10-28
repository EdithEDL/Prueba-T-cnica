using ProyectoWindowsF.Controlador;
using ProyectoWindowsF.Data.ProyectoWindowsF.Data;
using ProyectoWindowsF.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ClosedXML.Excel;

namespace ProyectoWindowsF
{
    public partial class ventasForm : Form
    {

        private DataTable tabla;
        private ProductosVendidosData productoVendidosVista = new ProductosVendidosData();
        public ventasForm()
        {
            InitializeComponent();
            productoVendidosVista = new ProductosVendidosData();
            Inicializar();
            cargarVista();
        }

        private void Inicializar()
        {
            tabla = new DataTable();
            tabla.Columns.Add("Id Venta", typeof(int));
            tabla.Columns.Add("Nombre", typeof(string));
            tabla.Columns.Add("Precio Unitario", typeof(double));
            tabla.Columns.Add("Cantidad", typeof(string));
            tabla.Columns.Add("Monto Total", typeof(string));
            tabla.Columns.Add("Fecha", typeof(DateTime));
            dgVentas.DataSource = tabla;
            dgVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigurarDataGridView();


        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var nuevoFormulario = Application.OpenForms.OfType<generarVenta>().FirstOrDefault();
            if (nuevoFormulario == null)
            {
                nuevoFormulario = new generarVenta();
                nuevoFormulario.Show();
            }
            else
            {
                nuevoFormulario.BringToFront();
            }
        }


        private void cargarVista()
        {
            try
            {
                List<ProductoVendidosVista> productos = productoVendidosVista.CargarVista();
                tabla.Clear();

                foreach (var item in productos)
                {
                    DataRow row = tabla.NewRow();
                    row["Id Venta"] = item.id_venta;
                    row["Nombre"] = item.nombre;
                    row["Precio Unitario"] = item.precio;
                    row["Cantidad"] = item.cantidad;
                    row["Monto Total"] = item.monto_total;
                    row["Fecha"] = item.fecha;
                    tabla.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgVentas.Columns["Precio Unitario"].DefaultCellStyle.Format = "C2";
            dgVentas.Columns["Monto Total"].DefaultCellStyle.Format = "C2";
            dgVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgVentas.Columns["Precio Unitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgVentas.Columns["Monto Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgVentas.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }



        public void ExportarExcel()
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Workbook|*.xlsx";
                    sfd.FileName = "Reporte_Ventas_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (XLWorkbook workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Ventas");
                            for (int i = 0; i < dgVentas.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgVentas.Columns[i].HeaderText;
                            }
                            for (int i = 0; i < dgVentas.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgVentas.Columns.Count; j++)
                                {
                                    worksheet.Cell(i + 2, j + 1).Value = dgVentas.Rows[i].Cells[j].Value?.ToString() ?? "";
                                }
                            }
                            decimal totalVendido = 0;
                            for (int i = 0; i < dgVentas.Rows.Count; i++)
                            {
                                if (decimal.TryParse(dgVentas.Rows[i].Cells["Monto Total"].Value?.ToString(), out decimal monto))
                                {
                                    totalVendido += monto;
                                }
                            }

                            worksheet.Cell(dgVentas.Rows.Count + 2, 1).Value = "Total Vendido:";
                            worksheet.Cell(dgVentas.Rows.Count + 2, 2).Value = totalVendido;
                            worksheet.Cell(dgVentas.Rows.Count + 2, 2).Style.NumberFormat.Format = "₡#,##0.00";

                            var rango = worksheet.Range(worksheet.Cell(1, 1).Address,
                                    worksheet.Cell(dgVentas.Rows.Count + 1, dgVentas.Columns.Count).Address);

                            var tabla = rango.CreateTable();
                            worksheet.Columns().AdjustToContents();

                            var columnaPrecio = worksheet.Column(3);
                            var columnaTotal = worksheet.Column(5);
                            columnaPrecio.Style.NumberFormat.Format = "₡#,##0.00";
                            columnaTotal.Style.NumberFormat.Format = "₡#,##0.00";

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("El archivo Excel se ha creado exitosamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar a Excel: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







    }
}
