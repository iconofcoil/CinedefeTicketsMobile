using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinedefe.Core.Model
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }

        public Sucursal()
        {

        }
    }

    public class SucursalPeliculas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int PeliculaId { get; set; }
        public string PeliculaTitulo { get; set; }
        public byte[] PeliculaPoster { get; set; }
        public int PeliculaDuracion { get; set; }
        public int SalaId { get; set; }
        public string SalaNombre { get; set; }
        public string SalaTipo { get; set; }

        public SucursalPeliculas()
        {

        }
    }
}
