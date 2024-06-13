using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoRestobar.Controller;

namespace TitoRestobar.Model
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public List<Item> Items { get; set; }
        public float Descuento { get; set; }

        public Pedido(DateTime fechaHoraApertura, List<Item> items, float descuento, DateTime fechaHoraCierre)
        {
            FechaHoraApertura = fechaHoraApertura;
            Items = new List<Item>(items);
            Descuento = descuento;
            FechaHoraCierre = fechaHoraCierre;
        }
    }
}
