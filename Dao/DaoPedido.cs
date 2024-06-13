using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Model;

namespace TitoRestobar.Dao
{
    public class DaoPedido
    {
        private readonly MySqlConnection conexion;

        public void CrearPedido(Pedido pedido)
        {
            string consulta = "INSERT INTO pedidos (mesa_id, fecha_hora_apertura) VALUES (@mesa_id, @fecha_hora_apertura)";
            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@mesa_id", pedido.Id); // Asumiendo que Pedido tiene una propiedad Id que corresponde a mesa_id
                cmd.Parameters.AddWithValue("@fecha_hora_apertura", pedido.FechaHoraApertura);

                conexion.Open();
                cmd.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public Pedido VerPedido(Mesa mesa)
        {
            string consulta = "SELECT * FROM pedidos WHERE mesa_id = @mesa_id";
            Pedido pedido = null;

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@mesa_id", mesa.Id);

                conexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int pedidoId = reader.GetInt32("id");
                        DateTime fechaHoraApertura = reader.GetDateTime("fecha_hora_apertura");
                        DateTime fechaHoraCierre = reader.GetDateTime("fecha_hora_cierre");

                        pedido = new Pedido(fechaHoraApertura, new List<Item>(), 0, fechaHoraCierre)
                        {
                            Id = pedidoId
                        };
                    }
                }

                conexion.Close();
            }

            return pedido;
        }


        public List<Pedido> ListarPedidosDeMesa(Mesa mesa)
        {
            List<Pedido> pedidos = new List<Pedido>();
            string consulta = "SELECT * FROM pedidos WHERE mesa_id = @mesa_id";

            using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@mesa_id", mesa.Id);
                conexion.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int pedidoId = reader.GetInt32("id");
                        DateTime fechaHoraApertura = reader.GetDateTime("fecha_hora_apertura");
                        List<Item> items = new List<Item>(); 
                        float descuento = reader.GetFloat("descuento");
                        DateTime fechaHoraCierre = reader.GetDateTime("fecha_hora_cierre");
                        Pedido pedido = new Pedido(fechaHoraApertura, items, descuento, fechaHoraCierre)
                        {
                            Id = pedidoId
                        };
                        pedidos.Add(pedido);
                    }
                }
                conexion.Close();
            }

            return pedidos;
        }
    }
}
