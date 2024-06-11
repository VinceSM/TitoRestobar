using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Model;

namespace TitoRestobar.Dao
{
    public class DAOProducto
    {
        private readonly MySqlConnection conexion;

        public List<Producto> ListadoDeProductos()
        {
            List<Producto> lista = new List<Producto>();
            string consulta = "SELECT * FROM `producto`";

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                conexion.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string nombre = reader.GetString("nombre");
                        string descripcion = reader.GetString("descripcion");
                        float costo = reader.GetFloat("costo");
                        float precio = reader.GetFloat("precio");
                        bool elaboracion = reader.GetBoolean("elaborado");

                        Producto producto = new Producto(nombre, descripcion, precio, costo, elaboracion)
                        {
                            Id = id
                        };
                        lista.Add(producto);
                    }
                }
                conexion.Close();
            }

            return lista;
        }

        public void Guardar(Producto producto)
        {
            string consulta = "INSERT INTO `producto` (`nombre`, `descripcion`, `precio`, `costo`, `elaborado`) VALUES (@nombre, @descripcion, @precio, @costo, @elaborado)";
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@costo", producto.Costo);
                cmd.Parameters.AddWithValue("@elaborado", producto.Elaboracion);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void Actualizar(Producto producto)
        {
            string consulta = "UPDATE `producto` SET `nombre` = @nombre, `descripcion` = @descripcion, `precio` = @precio, `costo` = @costo, `elaborado` = @elaborado WHERE `id` = @id";
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@precio", producto.Precio);
                cmd.Parameters.AddWithValue("@costo", producto.Costo);
                cmd.Parameters.AddWithValue("@elaborado", producto.Elaboracion);
                cmd.Parameters.AddWithValue("@id", producto.Id);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public bool EliminarProductoPorNombre(string nombre)
        {
            string consulta = "DELETE FROM `producto` WHERE `nombre` = @nombre";
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);

                conexion.Open();
                int filasAfectadas = cmd.ExecuteNonQuery();
                conexion.Close();

                return filasAfectadas > 0;
            }
        }

        public void Ver(Producto producto)
        {
            string consulta = "SELECT * FROM `producto` WHERE `nombre` = @nombre";
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@nombre", producto.Nombre);

                conexion.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        producto.Id = reader.GetInt32("id");
                        producto.Descripcion = reader.GetString("descripcion");
                        producto.Costo = reader.GetFloat("costo");
                        producto.Precio = reader.GetFloat("precio");
                        producto.Elaboracion = reader.GetBoolean("elaborado");
                    }
                }
                conexion.Close();
            }
        }
    }
}
