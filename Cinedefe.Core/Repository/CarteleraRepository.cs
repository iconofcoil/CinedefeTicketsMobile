using System;
using System.Collections.Generic;
using System.Linq;

using Cinedefe.Core.Model;

namespace Cinedefe.Core.Repository
{
	public class CarteleraRepository
	{
        private List<Sucursal> _sucursales;
        private List<SucursalPeliculas> _sucursalPeliculas;

        public CarteleraRepository ()
		{
            _sucursales = new List<Sucursal>();

            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Centro", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Plaza Galerías", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Centro Magno", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Cerro de la Silla", Ciudad = "Monterrey" });

            _sucursalPeliculas = new List<SucursalPeliculas>();

            _sucursalPeliculas.Add(new SucursalPeliculas() { Id = 1, SalaId = 1, SalaNombre = "A", SalaTipo = "",
                                                                     PeliculaId = 1, PeliculaTitulo = "Dumbo", PeliculaDuracion = 120, PeliculaPoster = null});
            _sucursalPeliculas.Add(new SucursalPeliculas()
            {
                Id = 1,
                SalaId = 2,
                SalaNombre = "B",
                SalaTipo = "3D",
                PeliculaId = 1,
                PeliculaTitulo = "Dumbo",
                PeliculaDuracion = 120,
                PeliculaPoster = null
            });
            _sucursalPeliculas.Add(new SucursalPeliculas()
            {
                Id = 1,
                SalaId = 3,
                SalaNombre = "C",
                SalaTipo = "",
                PeliculaId = 2,
                PeliculaTitulo = "Hellboy",
                PeliculaDuracion = 105,
                PeliculaPoster = null
            });
            _sucursalPeliculas.Add(new SucursalPeliculas()
            {
                Id = 1,
                SalaId = 4,
                SalaNombre = "D",
                SalaTipo = "",
                PeliculaId = 3,
                PeliculaTitulo = "Gaguin",
                PeliculaDuracion = 115,
                PeliculaPoster = null
            });
            _sucursalPeliculas.Add(new SucursalPeliculas()
            {
                Id = 1,
                SalaId = 5,
                SalaNombre = "E",
                SalaTipo = "",
                PeliculaId = 4,
                PeliculaTitulo = "El Complot Mongol",
                PeliculaDuracion = 90,
                PeliculaPoster = null
            });
        }

        public List<Ciudad> GetAllCiudades()
        {
            List<Ciudad> ciudades = new List<Ciudad>();

            ciudades.Add(new Ciudad("Guadalajara"));
            ciudades.Add(new Ciudad("Monterrey"));

            return ciudades;
        }

        public List<Sucursal> GetSucursalesByCiudadNombre(string ciudadNombre)
        {
            IEnumerable<Sucursal> sucursales = from sucursal in _sucursales
                                               where sucursal.Ciudad == ciudadNombre
                                               select sucursal;

            return sucursales.ToList<Sucursal>();
        }

        public List<SucursalPeliculas> GetPeliculasSalasBySucursalId(int sucursalId)
        {
            IEnumerable<SucursalPeliculas> peliculas = from sucursal in _sucursalPeliculas
                                                       where sucursal.Id == sucursalId
                                                       select sucursal;

            return peliculas.ToList<SucursalPeliculas>();
        }
    }
}