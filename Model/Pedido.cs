using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Model
{
    public class Pedido
    {
        private Producto producto;
        public int Id { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public List<Item> Items { get; set; }
        public float Descuento { get; set; }

        public Pedido(DateTime fechaHoraApertura, List<Item> items)
        {
            FechaHoraApertura = fechaHoraApertura;
            Items = new List<Item>(items);
        }

        public void AgregarItem(Item item)
        {
            Items.Add(item);
        }

        public void EliminarItem(Item item)
        {
            Items.Remove(item);
        }

        public float Subtotal()
        {
            float total = 0;
            foreach (var item in Items)
            {
                total += producto.Precio;
            }
            return total;
        }


        public float AplicarDescuentoPedido(float descuento)
        {
            float total = Subtotal();
            total -= descuento;
            return total;
        }

        public float TotalPedido()
        {
            
            return AplicarDescuentoPedido(Descuento);
        }
    }
}
