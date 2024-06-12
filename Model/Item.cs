using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Model
{
    public class Item
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public float PrecioTotal { get; set; }

        public Item(Producto producto, int cantidad, float precioTotal)
        {
            Producto = producto;
            Cantidad = cantidad;
            PrecioTotal = precioTotal;
        }
    }
}
