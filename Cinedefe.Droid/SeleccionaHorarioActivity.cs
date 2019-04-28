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
    [Activity(Label = "SeleccionaHorarioActivity")]
    public class SeleccionaHorarioActivity : Activity
    {
        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private TextView peliculaTitleTextView;
        private TextView fechaTitleTextView;
        private ListView horariosListView;
        private List<FuncionHorario> horarios = new List<FuncionHorario>();

        private CarteleraWebRepository carteleraRepository;

        private string ciudadNombre;
        private string sucursalNombre;
        private string funcionNombre;
        private DateTime fecha;
        private int funcionId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.HorariosListView);

            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);
            peliculaTitleTextView = FindViewById<TextView>(Resource.Id.peliculaTitleTextView);
            fechaTitleTextView = FindViewById<TextView>(Resource.Id.fechaTitleTextView);
            horariosListView = FindViewById<ListView>(Resource.Id.horariosListView);

            carteleraRepository = new CarteleraWebRepository();

            ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            sucursalNombre = Intent.Extras.GetString("selectedSucursalNombre");
            funcionNombre = Intent.Extras.GetString("selectedFuncionNombre");
            fecha = DateTime.Parse(Intent.Extras.GetString("selectedFecha"));
            funcionId = Intent.Extras.GetInt("selectedFuncionId");

            ciudadTitleTextView.Text = ciudadNombre;
            sucursalTitleTextView.Text = sucursalNombre;
            peliculaTitleTextView.Text = funcionNombre;
            fechaTitleTextView.Text = fecha.ToString("dd/MMM/yyyy");

            // Horarios disponibles
            var horarios = carteleraRepository.GetHorariosByFuncionId(funcionId).Where(x => x.Horario.Date == fecha.Date);

            foreach (FuncionHorario f in horarios)
            {
                this.horarios.Add(f);
            }

            horariosListView.Adapter = new FuncionHorariosFechasListAdapter(this, this.horarios, true);

            horariosListView.ItemClick += HorariosListView_ItemClick;

            horariosListView.FastScrollEnabled = true;
        }

        private void HorariosListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var funcionHorario = this.horarios[e.Position];

            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaBoletosActivity));
            intent.PutExtra("selectedFuncionId", funcionHorario.FuncionId);
            intent.PutExtra("selectedCiudadNombre", ciudadNombre);
            intent.PutExtra("selectedSucursalNombre", sucursalNombre);
            intent.PutExtra("selectedFuncionNombre", funcionNombre);
            intent.PutExtra("selectedHorario", funcionHorario.Horario.ToString("yyyy-MM-ddTHH:mm"));

            StartActivity(intent);
        }
    }
}