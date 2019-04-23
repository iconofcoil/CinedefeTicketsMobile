using System;
using System.Collections.Generic;

namespace Cinedefe.Core
{
	public class PeliculaGroup
	{
		public PeliculaGroup ()
		{
		}

		public int PeliculaGroupId {
			get;
			set;
		}

		public string Title {
			get;
			set;
		}

		public string ImagePath {
			get;
			set;
		}

		public List<Pelicula>Peliculas {
			get;
			set;
		}
	}
}

