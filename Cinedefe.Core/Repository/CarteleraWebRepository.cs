using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cinedefe.Core.Repository
{
	public class PeliculaWebRepository
	{
		string url =
			"http://gillcleerenpluralsight.blob.core.windows.net/files/hotdogs.json";

		public PeliculaWebRepository ()
		{
			Task.Run (() => this.LoadDataAsync (url)).Wait ();
		}
		
		public List<Pelicula> GetAllPeliculas()
		{
			IEnumerable <Pelicula> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.Peliculas

				select hotDog;
			return hotDogs.ToList<Pelicula> ();
		}

		public List<PeliculaGroup> GetGroupedPeliculas()
		{
			return hotDogGroups;
		}

		public List<Pelicula> GetPeliculasForGroup(int hotDogGroupId)
		{
			var group =  hotDogGroups.Where (h => h.PeliculaGroupId == hotDogGroupId).FirstOrDefault();

			if (group != null) 
			{
				return group.Peliculas;
			}
			return null;
		}

		public List<Pelicula> GetFavoritePeliculas()
		{
			IEnumerable <Pelicula> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.Peliculas
					where hotDog.IsFavorite
				select hotDog;

			return hotDogs.ToList<Pelicula> ();
		}

		public Pelicula GetPeliculaById(int hotDogId)
		{
			IEnumerable <Pelicula> hotDogs = 
				from hotDogGroup in hotDogGroups
				from hotDog in hotDogGroup.Peliculas
					where hotDog.PeliculaId == hotDogId
				select hotDog;

			return hotDogs.FirstOrDefault();
		}

		private static List<PeliculaGroup> hotDogGroups = new List<PeliculaGroup>();

		private async Task LoadDataAsync(string uri)
		{
			if (hotDogGroups != null) 
			{
				string responseJsonString = null;

				using (var httpClient = new HttpClient ()) 
				{
					try 
					{
						Task<HttpResponseMessage> getResponse = httpClient.GetAsync (uri);

						HttpResponseMessage response = await getResponse;

						responseJsonString = await response.Content.ReadAsStringAsync ();
						hotDogGroups = JsonConvert.DeserializeObject<List<PeliculaGroup>> (responseJsonString);
					} 
					catch (Exception ex) 
					{
						//handle any errors here, not part of the sample app
						string message = ex.Message;
					}
				}
			}
		}
	}
}