using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitoRestobar.Interfaces;
using TitoRestobar.Model;

namespace TitoRestobar.Controller
{
    public class PedidoController : ICalculable
    {

        private Pedido pedidoActual {  get; set; }

        public Pedido PedidoActual => pedidoActual;

        private Item item { get; set; }

        private List<Item> items = new List<Item>();

        private Producto produto { get; set; }

        public PedidoController(Pedido pedido, Item item)
        {
            this.pedidoActual = pedido;
            this.item = item;
        }

        public void AgregarItem(Item item)
        {
            pedidoActual.Items.Add(item);
        }

        public void EliminarItem(Item item)
        {
            pedidoActual.Items.Remove(item);
        }

        public void UpdateItem(Item item)
        {
            pedidoActual.Items.Equals(item);
        }

        public void VerItemsPedido(DataGridView dgvItems)
        {
            dgvItems.Rows.Clear();

            foreach (var item in pedidoActual.Items)
            {
                dgvItems.Rows.Add(item.Producto.Nombre, item.Cantidad, item.getPrecio());
            }
        }

        public float CalcularTotalPedido()
        {
            return produto.Precio * item.Cantidad;
        }

        public float CalcularSubTotalPedido()
        {
            float subtotal = 0;

            foreach (var item in items)
            {
                subtotal += item.getPrecio();
            }
            return subtotal;
        }

        public float CalcularDescuentoPedido()
        {
            float total = CalcularSubTotalPedido();
            total -= pedidoActual.Descuento;
            return total; 
        }
    }
}
