using MySql.Data.MySqlClient;
using System;

namespace ProyectoWindowsF.confing
{
    internal class conexion
    {

        private readonly string nombreDB = "prueba";
        private readonly string usuarioDB = "root";
        private readonly string contraDB = "";
        private readonly string server = "localhost";
        private readonly string connectionString;
        private MySqlConnection bd;

        public conexion()
        {
            connectionString = "Server=" + server +
                                ";Database=" + nombreDB +
                                ";User ID=" + usuarioDB +
                                ";Password=" + contraDB + ";";
        }


        public MySqlConnection Conectar()
        {
            try
            {
                bd = new MySqlConnection(connectionString);
                bd.Open();

                Console.WriteLine("Se conectó a la base de datos");
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se conectó a la base de datos");
                Console.WriteLine(ex.Message);
            }

            return bd;
        }


        public void Desconectar()
        {
            try
            {
                bd.Close();
                Console.WriteLine("Se desconectó de la base de datos");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
