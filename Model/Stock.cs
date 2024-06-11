using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public Producto Producto { get; set; }

        public Stock(int cantidad, Producto producto)
        {
            Cantidad = cantidad;
            Producto = producto;
        }
    }
}
