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
    [Activity(Label = "SeleccionaSucursalActivity")]
    public class SeleccionaSucursalActivity : Activity
    {
        private ListView sucursalesListView;
        private TextView ciudadTitleTextView;
        private List<Sucursal> sucursales;
        private CarteleraRepository carteleraRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SucursalListView);

            sucursalesListView = FindViewById<ListView>(Resource.Id.sucursalesListView);
            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);

            carteleraRepository = new CarteleraRepository();

            var ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            ciudadTitleTextView.Text = ciudadNombre;
            sucursales = carteleraRepository.GetSucursalesByCiudadNombre(ciudadNombre);

            sucursalesListView.Adapter = new SucursalesListAdapter(this, sucursales);

            sucursalesListView.ItemClick += SucursalesListView_ItemClick;

            sucursalesListView.FastScrollEnabled = true;
        }

        private void SucursalesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var sucursal = this.sucursales[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaPeliculaSalaActivity));
            intent.PutExtra("selectedCiudadNombre", sucursal.Ciudad);
            intent.PutExtra("selectedSucursalId", sucursal.Id);
            intent.PutExtra("selectedSucursalNombre", sucursal.Nombre);

            StartActivity(intent);
        }
    }
}