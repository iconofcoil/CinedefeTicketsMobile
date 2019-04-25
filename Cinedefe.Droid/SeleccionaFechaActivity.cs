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
    [Activity(Label = "SeleccionaFechaActivity")]
    public class SeleccionaFechaActivity : Activity
    {
        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private TextView funcionTitleTextView;
        private ListView fechasListView;
        private List<FuncionHorario> horarios = new List<FuncionHorario>();

        private CarteleraWebRepository carteleraRepository;

        private string ciudadNombre;
        private string sucursalNombre;
        private string funcionNombre;
        private int funcionId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.FechasListView);

            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);
            funcionTitleTextView = FindViewById<TextView>(Resource.Id.funcionTitleTextView);
            fechasListView = FindViewById<ListView>(Resource.Id.fechasListView);

            carteleraRepository = new CarteleraWebRepository();

            ciudadNombre = Intent.Extras.GetString("ciudadNombre");
            sucursalNombre = Intent.Extras.GetString("sucursalNombre");
            funcionNombre = Intent.Extras.GetString("selectedFuncionPeliculaTitulo") + " | S " +
                            Intent.Extras.GetString("selectedFuncionSalaNombre");
            funcionId = Intent.Extras.GetInt("selectedFuncionId");

            ciudadTitleTextView.Text = ciudadNombre;
            sucursalTitleTextView.Text = sucursalNombre;
            funcionTitleTextView.Text = funcionNombre;

            // Fechas disponibles
            var fechas = carteleraRepository.GetHorariosByFuncionId(funcionId).Select(x => x.Horario.Date).Distinct();

            foreach (DateTime f in fechas)
            {
                horarios.Add(new FuncionHorario() { FuncionId = funcionId, Horario = f });
            }

            fechasListView.Adapter = new FuncionHorariosFechasListAdapter(this, horarios);

            fechasListView.ItemClick += FechasListView_ItemClick;

            fechasListView.FastScrollEnabled = true;
        }

        private void FechasListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var horario = this.horarios[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaHorarioActivity));
            intent.PutExtra("selectedFuncionId", horario.FuncionId);
            intent.PutExtra("selectedFecha", horario.Horario.Date.ToString("yyyy-MM-dd"));
            intent.PutExtra("selectedCiudadNombre", ciudadNombre);
            intent.PutExtra("selectedSucursalNombre", sucursalNombre);
            intent.PutExtra("selectedFuncionNombre", funcionNombre);

            StartActivity(intent);
        }
    }
}