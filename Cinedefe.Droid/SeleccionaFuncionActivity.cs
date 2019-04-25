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
    [Activity(Label = "SeleccionaFuncionActivity")]
    public class SeleccionaFuncionActivity : Activity
    {
        private ListView funcionesListView;
        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private List<FuncionDisponible> funciones;

        string ciudadNombre;
        string sucursalNombre;

        private CarteleraWebRepository carteleraRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FuncionesListView);

            funcionesListView = FindViewById<ListView>(Resource.Id.funcionesListView);
            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);

            carteleraRepository = new CarteleraWebRepository();

            ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            sucursalNombre = Intent.Extras.GetString("selectedSucursalNombre");
            var sucursalId = Intent.Extras.GetInt("selectedSucursalId");

            ciudadTitleTextView.Text = ciudadNombre;
            sucursalTitleTextView.Text = sucursalNombre;

            funciones = carteleraRepository.GetFuncionesBySucursalId(sucursalId);

            funcionesListView.Adapter = new FuncionesListAdapter(this, funciones);

            funcionesListView.ItemClick += FuncionesListView_ItemClick;

            funcionesListView.FastScrollEnabled = true;
        }

        private void FuncionesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var funcion = this.funciones[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaFechaActivity));
            intent.PutExtra("ciudadNombre", ciudadNombre);
            intent.PutExtra("sucursalNombre", sucursalNombre);
            intent.PutExtra("selectedFuncionId", funcion.FuncionId);
            intent.PutExtra("selectedFuncionPeliculaTitulo", funcion.PeliculaTitulo);
            intent.PutExtra("selectedFuncionSalaNombre", funcion.SalaNombre + " " +funcion.SalaTipo);

            StartActivity(intent);
        }
    }
}