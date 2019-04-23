using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Cinedefe.Core.Model;
using Cinedefe.Core.Repository;
using Cinedefe.Droid.Adapters;

namespace Cinedefe.Droid
{
    [Activity(Label = "SeleccionaPeliculaSalaActivity")]
    public class SeleccionaPeliculaSalaActivity : Activity
    {
        private ListView peliculasListView;
        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private List<SucursalPeliculas> sucursalPeliculas;
        private CarteleraRepository carteleraRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PeliculasListView);

            peliculasListView = FindViewById<ListView>(Resource.Id.peliculasListView);
            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);

            carteleraRepository = new CarteleraRepository();

            var ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            var sucursalId = Intent.Extras.GetInt("selectedSucursalId");

            ciudadTitleTextView.Text = ciudadNombre;
            sucursalPeliculas = carteleraRepository.GetPeliculasSalasBySucursalId(sucursalId);

            peliculasListView.Adapter = new PeliculasSalasListAdapter(this, sucursalPeliculas);

            peliculasListView.FastScrollEnabled = true;
        }
    }
}