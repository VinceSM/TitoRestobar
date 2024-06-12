using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Dao;
using TitoRestobar.Model;

namespace TitoRestobar.Controller
{
    public class MesaController
    {
        private List<Mesa> mesas;
        private DaoMesa daoMesa;
        private DaoPedido daoPedido;
        private PedidoController pedidoController;

        public List<Mesa> GetMesas()
        {
            return mesas;
        }

        public void SetMesas(List<Mesa> mesas)
        {
            this.mesas = mesas;
        }

        public Mesa CrearMesa(string nombre)
        {
            Mesa nuevaMesa = new Mesa(nombre);
            daoMesa.CrearMesa(nuevaMesa);
            mesas.Add(nuevaMesa);
            return nuevaMesa;
        }

        public Mesa BuscarMesaPorNombre(string nombre)
        {
            foreach (Mesa mesa in mesas)
            {
                if (mesa.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return mesa;
                }
            }
            return null;
        }

        public void EliminarMesa(string nombre)
        {
            daoMesa.EliminarMesa(nombre);
            mesas.RemoveAll(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }

        public List<string> ObtenerNombresDeMesas()
        {
            List<string> nombres = new List<string>();
            foreach (Mesa mesa in mesas)
            {
                nombres.Add(mesa.Nombre);
            }
            return nombres;
        }

        

        public List<string> ObtenerDetallesDePedidoEnMesa(Mesa mesa)
        {
            List<string> detalles = new List<string>();
            Pedido pedido = daoPedido.VerPedido(mesa);
            if (pedido != null)
            {
                detalles.Add($"Fecha y hora de apertura: {pedido.FechaHoraApertura}");
                detalles.Add($"Total del pedido: {pedidoController.CalcularTotalPedido()}");
                detalles.Add("Items del pedido:");
                foreach (Item item in pedido.Items)
                {
                    detalles.Add($"- {item.Producto.Nombre} - Cantidad: {item.Cantidad}");
                }
            }
            else
            {
                detalles.Add($"No hay pedido en la mesa {mesa.Nombre}");
            }
            return detalles;
        }
    }
}
