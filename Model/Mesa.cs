using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoRestobar.Model
{
    public class Mesa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Mesa(string nombre)
        {
            Nombre = nombre;
        }
    }
}
