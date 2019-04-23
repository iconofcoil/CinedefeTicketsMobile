using System;
using System.Collections.Generic;
using System.Linq;

using Cinedefe.Core.Model;

namespace Cinedefe.Core.Repository
{
	public class CarteleraRepository
	{
        private List<Sucursal> _sucursales;

        public CarteleraRepository ()
		{
            _sucursales = new List<Sucursal>();

            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Centro", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Plaza Galerías", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Centro Magno", Ciudad = "Guadalajara" });
            _sucursales.Add(new Sucursal() { Id = 1, Nombre = "Cerro de la Silla", Ciudad = "Monterrey" });
        }

        public List<Pelicula> GetAllPeliculas()
		{
			IEnumerable <Pelicula> peliculas = 
				from peliculaGroup in peliculaGroups
				from pelicula in peliculaGroup.Peliculas
					
				select pelicula;
			return peliculas.ToList<Pelicula> ();
		}

        public List<PeliculaGroup> GetGroupedPeliculas()
		{
			return peliculaGroups;
		}

		public List<Pelicula> GetPeliculasForGroup(int peliculaGroupId)
		{
			var group =  peliculaGroups.Where (h => h.PeliculaGroupId == peliculaGroupId).FirstOrDefault();

			if (group != null) 
			{
				return group.Peliculas;
			}
			return null;
		}

		public List<Pelicula> GetFavoritePeliculas()
		{
			IEnumerable <Pelicula> peliculas = 
				from peliculaGroup in peliculaGroups
				from pelicula in peliculaGroup.Peliculas
					where pelicula.IsFavorite
				select pelicula;
			
			return peliculas.ToList<Pelicula> ();
		}

		public Pelicula GetPeliculaById(int peliculaId)
		{
			IEnumerable <Pelicula> peliculas = 
				from peliculaGroup in peliculaGroups
				from pelicula in peliculaGroup.Peliculas
					where pelicula.PeliculaId == peliculaId
				select pelicula;
			
			return peliculas.FirstOrDefault();
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

        private static List<PeliculaGroup> peliculaGroups = new List<PeliculaGroup>()
		{
			new PeliculaGroup()
			{
				PeliculaGroupId = 1, Title = "Meat lovers", ImagePath = "", Peliculas = new List<Pelicula>()
				{
					new Pelicula()
					{
						PeliculaId = 1, 
						Name = "Regular Hot Dog", 
						ShortDescription = "The best there is on this planet", 
						Description = "Manchego smelly cheese danish fontina. Hard cheese cow goat red leicester pecorino macaroni cheese cheesecake gouda. Ricotta fromage cheese and biscuits stinking bishop halloumi monterey jack cheese strings goat. Pecorino babybel pecorino jarlsberg cow say cheese cottage cheese.",
						ImagePath = "hotdog1", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Regular bun", "Sausage", "Ketchup"},
						Price = 8,
						IsFavorite = true
					}, 
					new Pelicula()
					{
						PeliculaId = 2, 
						Name = "Haute Dog", 
						ShortDescription = "The classy one", 
						Description = "Bacon ipsum dolor amet turducken ham t-bone shankle boudin kevin. Hamburger salami pork shoulder pork chop. Flank doner turducken venison rump swine sausage salami sirloin kielbasa pork belly tail cow. Pork chop bacon ground round cupim tongue, venison frankfurter bresaola tri-tip andouille sirloin turducken spare ribs biltong. Drumstick ham hock pork tail, capicola shank frankfurter beef ribs jowl meatball turkey hamburger. Tenderloin swine ham pork belly beef ribeye. ",
						ImagePath = "hotdog2", 
						Available = true,
						PrepTime= 15,
						Ingredients = new List<string>(){"Baked bun", "Gourmet sausage", "Fancy mustard from Germany"},
						Price = 10,
						IsFavorite = false
					}, 
					new Pelicula()
					{
						PeliculaId = 3, 
						Name = "Extra Long", 
						ShortDescription = "For when a regular one isn't enough", 
						Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
						ImagePath = "hotdog3", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Extra long bun", "Extra long sausage", "More ketchup"},
						Price = 8,
						IsFavorite = true
					}
				}
			},
			new PeliculaGroup()
			{
				PeliculaGroupId = 2, Title = "Veggie lovers", ImagePath = "", Peliculas = new List<Pelicula>()
				{
					new Pelicula()
					{
						PeliculaId = 4, 
						Name = "Veggie Hot Dog", 
						ShortDescription = "American for non-meat-lovers", 
						Description = "Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic.\n\nGumbo beet greens corn soko endive gumbo gourd. Parsley shallot courgette tatsoi pea sprouts fava bean collard greens dandelion okra wakame tomato. Dandelion cucumber earthnut pea peanut soko zucchini.",
						ImagePath = "hotdog4", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Bun", "Vegetarian sausage", "Ketchup"},
						Price = 8,
						IsFavorite = false
					}, 
					new Pelicula()
					{
						PeliculaId = 5, 
						Name = "Haute Dog Veggie", 
						ShortDescription = "Classy and veggie", 
						Description = "Turnip greens yarrow ricebean rutabaga endive cauliflower sea lettuce kohlrabi amaranth water spinach avocado daikon napa cabbage asparagus winter purslane kale. Celery potato scallion desert raisin horseradish spinach carrot soko. Lotus root water spinach fennel kombu maize bamboo shoot green bean swiss chard seakale pumpkin onion chickpea gram corn pea. Brussels sprout coriander water chestnut gourd swiss chard wakame kohlrabi beetroot carrot watercress. Corn amaranth salsify bunya nuts nori azuki bean chickweed potato bell pepper artichoke.",
						ImagePath = "hotdog5", 
						Available = true,
						PrepTime= 15,
						Ingredients = new List<string>(){"Baked bun", "Gourmet vegetarian sausage", "Fancy mustard"},
						Price = 10,
						IsFavorite = true
					}, 
					new Pelicula()
					{
						PeliculaId = 6, 
						Name = "Extra Long Veggie", 
						ShortDescription = "For when a regular one isn't enough", 
						Description = "Beetroot water spinach okra water chestnut ricebean pea catsear courgette summer purslane. Water spinach arugula pea tatsoi aubergine spring onion bush tomato kale radicchio turnip chicory salsify pea sprouts fava bean. Dandelion zucchini burdock yarrow chickpea dandelion sorrel courgette turnip greens tigernut soybean radish artichoke wattle seed endive groundnut broccoli arugula.",
						ImagePath = "hotdog6", 
						Available = true,
						PrepTime= 10,
						Ingredients = new List<string>(){"Extra long bun", "Extra long vegetarian sausage", "More ketchup"},
						Price = 8,
						IsFavorite = false
					}
				}
			}
		};
	}
}