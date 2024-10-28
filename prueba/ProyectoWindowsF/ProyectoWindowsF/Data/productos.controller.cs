using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ProyectoWindowsF.confing;
using ProyectoWindowsF.Modelos;

namespace ProyectoWindowsF.Controlador
{
    public class ProductosController {


        private readonly conexion dbConexion;

        public ProductosController()
        {
            dbConexion = new conexion(); 
        }

        public List<Productos> Cargar()
        {
            List<Productos> productos = new List<Productos>();

            try
            {
                var conexionAbierta = dbConexion.Conectar();

                if (conexionAbierta != null && conexionAbierta.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT id_producto, nombre, precio, descripcion FROM product";
                    MySqlCommand cmd = new MySqlCommand(query, conexionAbierta);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Productos producto = new Productos
                        {
                            id_producto = reader.GetInt32("id_producto"),
                            nombre = reader.GetString("nombre"),
                            precio = reader.GetDouble("precio"),
                            descripcion = reader.GetString("descripcion")
                        };
                        productos.Add(producto);
                    }

                    reader.Close(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
            finally
            {
                
                dbConexion.Desconectar();
            }

            return productos;
        }

        public void Guardar(Productos producto)
        {
            try
            {
                var conexionAbierta = dbConexion.Conectar();

                if (conexionAbierta != null && conexionAbierta.State == System.Data.ConnectionState.Open)
                {
                    string query = "INSERT INTO product (nombre, precio, descripcion) VALUES (@nombre, @precio, @descripcion)";
                    MySqlCommand cmd = new MySqlCommand(query, conexionAbierta);

                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }
            finally
            {
                dbConexion.Desconectar();
            }
        }

        public void Editar(Productos producto)
        {
            try
            {
                var conexionAbierta = dbConexion.Conectar();

                if (conexionAbierta != null && conexionAbierta.State == System.Data.ConnectionState.Open)
                {
                    string query = "UPDATE product SET nombre = @nombre, precio = @precio, descripcion = @descripcion WHERE id_producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexionAbierta);

                    cmd.Parameters.AddWithValue("@nombre", producto.nombre);
                    cmd.Parameters.AddWithValue("@precio", producto.precio);
                    cmd.Parameters.AddWithValue("@descripcion", producto.descripcion);
                    cmd.Parameters.AddWithValue("@id", producto.id_producto);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el producto: " + ex.Message);
            }
            finally
            {
                dbConexion.Desconectar();
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                var conexionAbierta = dbConexion.Conectar();

                if (conexionAbierta != null && conexionAbierta.State == System.Data.ConnectionState.Open)
                {
                    string query = "DELETE FROM product WHERE id_producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexionAbierta);

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto: " + ex.Message);
            }
            finally
            {
                dbConexion.Desconectar();
            }
        }



        public List<Productos> Buscar(int idProducto)
        {
            List<Productos> productos = new List<Productos>();
            var conexionAbierta = dbConexion.Conectar();

            try
            {
                if (conexionAbierta != null && conexionAbierta.State == System.Data.ConnectionState.Open)
                {
                    string query = "SELECT * FROM product WHERE id_producto = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conexionAbierta);
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Productos producto = new Productos
                        {
                            id_producto = reader.GetInt32("id_producto"),
                            nombre = reader.GetString("nombre"),
                            precio = reader.GetDouble("precio"),
                            descripcion = reader.GetString("descripcion")
                        };
                        productos.Add(producto);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar el producto: " + ex.Message);
            }
            finally
            {
                dbConexion.Desconectar();
            }

            return productos;
        }




    }

}
    

