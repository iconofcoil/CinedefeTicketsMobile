using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    [Activity(Label = "SeleccionaCiudadActivity")]
    public class SeleccionaCiudadActivity : Activity
    {
        private ListView ciudadesListView;
        private List<Ciudad> ciudades;
        private CarteleraWebRepository carteleraRepository;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CiudadListView);

            ciudadesListView = FindViewById<ListView>(Resource.Id.ciudadesListView);

            carteleraRepository = new CarteleraWebRepository();

            ciudades = carteleraRepository.GetCiudades();

            ciudadesListView.Adapter = new CiudadesListAdapter(this, ciudades);

            ciudadesListView.ItemClick += CiudadesListView_ItemClick;

            ciudadesListView.FastScrollEnabled = true;
        }

        private void CiudadesListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var ciudad = this.ciudades[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaSucursalActivity));
            intent.PutExtra("selectedCiudadNombre", ciudad.Nombre);

            StartActivity(intent);
        }
    }
}