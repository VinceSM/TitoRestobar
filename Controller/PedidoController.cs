using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Interfaces;
using TitoRestobar.Model;

namespace TitoRestobar.Controller
{
    public class PedidoController : ICalculable
    {
        private Pedido pedido { get; set; }
        private Item item { get; set; }

        private Producto produto { get; set; }

        public void AgregarItemEnPedido()
        {
            pedido.AgregarItem(item);
        }

        public void EliminarItemEnPedido()
        {
            pedido.EliminarItem(item);
        }

        public void UpdateItem() 
        {
            pedido.UpdateItem(item);
        }

        public float CalcularTotalPedido()
        {
            return produto.Precio * item.Cantidad;
        }

        public float CalcularSubTotalPedido()
        {
            float subtotal = 0;
            foreach (var item in Items)
            {
                subtotal += produto.Precio;
            }
            return subtotal;
        }

        public float CalcularDescuentoPedido()
        {
            float total = CalcularSubTotalPedido();
            total -= pedido.Descuento;
            return total; 
        }
    }
}
