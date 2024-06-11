
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using TitoRestobar.ConectionDB;
using TitoRestobar.Model;

namespace TitoRestobar.Dao
{
    public class DAOMesa
    {
        private Mesa mesa;
        private MySqlConnection conexion;
        private readonly IConexionDB conexionDB;

        public DAOMesa(IConexionDB conexionDB)
        {
            this.conexionDB = conexionDB;
            try
            {
                conexion = this.conexionDB.Conectar();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Mesa> ListarMesas()
        {
            List<Mesa> lista = new List<Mesa>();

            string consulta = "SELECT * FROM mesas";
            using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
            {
                using (MySqlDataReader lectura = comando.ExecuteReader())
                {
                    while (lectura.Read())
                    {
                        int id = lectura.GetInt32("id");
                        string nombre = lectura.GetString("nombre");

                        Mesa mesa = new Mesa(nombre);
                        mesa.Id = id;
                        lista.Add(mesa);
                    }
                }
            }

            return lista;
        }

        public void CrearMesa(Mesa mesa)
        {
            string consulta = "INSERT INTO `mesas` (nombre) VALUES (@nombre)";
            using (MySqlConnection conexion = conexionDB.Conectar())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", mesa.Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void EliminarMesa(string nombre)
        {
            string consulta = "DELETE FROM `mesas` WHERE `nombre` = @nombre";
            using (MySqlConnection conexion = conexionDB.Conectar())
            {
                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

