using ProyectoWindowsF.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using ProyectoWindowsF.confing;

namespace ProyectoWindowsF.Data
{

    namespace ProyectoWindowsF.Data
    {
        internal class ProductosVendidosData
        {
            private readonly conexion dbConnection = new conexion();

            public List<ProductoVendidosVista> CargarVista()
            {
                List<ProductoVendidosVista> listaProductosVendidos = new List<ProductoVendidosVista>();
                MySqlConnection connection = dbConnection.Conectar();

                try
                {
                    if (connection != null)
                    {
                        string query = "SELECT * FROM ProductosVendidos;";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ProductoVendidosVista producto = new ProductoVendidosVista
                                {
                                    id_venta = reader.GetInt32("id_venta"),
                                    nombre = reader.GetString("nombre"),
                                    precio = reader.GetDouble("precio"),
                                    cantidad = reader.GetInt32("cantidad"),
                                    monto_total = reader.GetDouble("monto_total"),
                                    fecha = reader.GetDateTime("fecha")
                                };
                                listaProductosVendidos.Add(producto);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al cargar la vista: {ex.Message}");
                }
                finally
                {
                    dbConnection.Desconectar();
                }

                return listaProductosVendidos;
            }



        }
    }
}
