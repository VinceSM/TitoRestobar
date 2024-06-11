using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.ConectionDB;

namespace TitoRestobar.IConectionDB
{
    public class ConexionDB : IConexionDB
    {
        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string baseDeDatos = "titorestobar";

            string cadenaConexion = $"Server={servidor}; Database={baseDeDatos}; Uid={usuario}; Pwd={password};";
            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);

            try
            {
                conexionDb.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
                throw;
            }

            return conexionDb;
        }
    }
}
