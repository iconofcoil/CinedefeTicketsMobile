using System;
using System.Collections.Generic;

namespace Cinedefe.Core
{
	public class Pelicula
	{
		public Pelicula ()
		{

		}

		public int Id {
			get;
			set;
		}

		public string Nombre {
			get;
			set;
		}

		public string Anio {
			get;
			set;
		}

		public int Duracion {
			get;
			set;
		}

		public byte[] Poster {
			get;
			set;
		}
	}
}
