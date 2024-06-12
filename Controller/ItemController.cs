using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Model;

namespace TitoRestobar.Controller
{
    public class ItemController
    { 
        private Pedido pedido { get; set; }

        public void AgregarItem(Item item)
        {
            pedido.Items.Add(item);
        }

        public void EliminarItem(Item item)
        {
            pedido.Items.Remove(item);
        }

        public void UpdateItem(Item item)
        {
            pedido.Items.Equals(item);
        }
    }
}
