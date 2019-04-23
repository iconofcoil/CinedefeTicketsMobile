using System;
using System.Collections.Generic;
using System.Linq;

using Cinedefe.Core.Repository;

namespace Cinedefe.Core
{
	public class PeliculaDataService
	{
        //private static PeliculaWebRepository hotDogRepository = new PeliculaWebRepository();
        private static CarteleraRepository hotDogRepository = new CarteleraRepository();

		public PeliculaDataService ()
		{
		}

		public List<Pelicula> GetAllPeliculas()
		{
			return hotDogRepository.GetAllPeliculas();
		}

		public List<PeliculaGroup> GetGroupedPeliculas()
		{
			return hotDogRepository.GetGroupedPeliculas ();
		}

		public List<Pelicula> GetPeliculasForGroup(int hotDogGroupId)
		{
			return hotDogRepository.GetPeliculasForGroup (hotDogGroupId);
		}

		public List<Pelicula> GetFavoritePeliculas()
		{
			return hotDogRepository.GetFavoritePeliculas ();
		}

		public Pelicula GetPeliculaById(int hotDogId)
		{
			return hotDogRepository.GetPeliculaById (hotDogId);
		}

	}
}

