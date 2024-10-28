using MySql.Data.MySqlClient;
using ProyectoWindowsF.confing;
using ProyectoWindowsF.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 
using System.Configuration;

namespace ProyectoWindowsF.Data
{
    internal class ventasController 
    {

        private conexion dbConexion;

        public ventasController()
        {
            dbConexion = new conexion();
        }

        public void GuardarVenta(Ventas nuevaVenta, List<ProductosVendidos> productosVendidos)
        {
            var conexionAbierta = dbConexion.Conectar();
            MySqlTransaction transaction = null;

            try
            {
                transaction = conexionAbierta.BeginTransaction();

                string queryVenta = "INSERT INTO venta (fecha, monto_total) VALUES (@fecha, @monto_total)";
                MySqlCommand cmdVenta = new MySqlCommand(queryVenta, conexionAbierta, transaction);
                cmdVenta.Parameters.AddWithValue("@fecha", nuevaVenta.fecha);
                cmdVenta.Parameters.AddWithValue("@monto_total", nuevaVenta.monto_total);
                cmdVenta.ExecuteNonQuery();

                int idVenta = (int)cmdVenta.LastInsertedId;

                foreach (var productoVendido in productosVendidos)
                {
                    
                    string queryVerificarProducto = "SELECT COUNT(*) FROM product WHERE id_producto = @id_producto";
                    MySqlCommand cmdVerificarProducto = new MySqlCommand(queryVerificarProducto, conexionAbierta, transaction);
                    cmdVerificarProducto.Parameters.AddWithValue("@id_producto", productoVendido.id_producto);

                    int existeProducto = Convert.ToInt32(cmdVerificarProducto.ExecuteScalar());
                    if (existeProducto == 0)
                    {
                        throw new Exception($"El producto con ID {productoVendido.id_producto} no existe en la base de datos.");
                    }

                    string queryProductoVendido = "INSERT INTO productovendido (id_venta, id_producto, cantidad) VALUES (@id_venta, @id_producto, @cantidad)";
                    MySqlCommand cmdProductoVendido = new MySqlCommand(queryProductoVendido, conexionAbierta, transaction);
                    cmdProductoVendido.Parameters.AddWithValue("@id_venta", idVenta);
                    cmdProductoVendido.Parameters.AddWithValue("@id_producto", productoVendido.id_producto);
                    cmdProductoVendido.Parameters.AddWithValue("@cantidad", productoVendido.cantidad);
                    cmdProductoVendido.ExecuteNonQuery();
                }


                transaction.Commit();
                Console.WriteLine("Venta guardada correctamente.");
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }

                Console.WriteLine("Error al guardar la venta: " + ex.Message);
            }
            finally
            {
                dbConexion.Desconectar();
            }
            
        }


    }

    

}
