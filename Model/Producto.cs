using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
        public bool Elaboracion { get; set; }

        public Producto(string nombre, string descripcion, float precio, float costo, bool elaboracion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Costo = costo;
            Elaboracion = elaboracion;
        }
    }
}
