using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinedefe.Core.Model
{
    public class Ciudad
    {
        public string Nombre { get; set; }

        public Ciudad()
        {

        }

        public Ciudad(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}
