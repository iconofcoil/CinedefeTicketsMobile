using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Timers;

using Cinedefe.Droid.Adapters;

namespace Cinedefe.Droid
{
    [Activity(Label = "SeleccionaAsientosActivity")]
    public class SeleccionaAsientosActivity : Activity
    {
        private int _countseconds = 300;

        private Timer _timer = new Timer();

        private TextView timerTextView;

        private TextView ciudadTitleTextView;
        private TextView sucursalTitleTextView;
        private TextView peliculaTitleTextView;
        private TextView horarioTitleTextView;
        private TextView boletosTitleTextView;
        private EditText cantidadEditText;

        private string ciudadNombre;
        private string sucursalNombre;
        private string funcionNombre;
        private DateTime horario;
        private string boletosNombre;
        private int funcionId;

        private string[] _texts = { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "eee", "hhh", "iii" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsedEvent;
            _timer.Start();

            SetContentView(Resource.Layout.AsientosSalaView);

            var gridview = FindViewById<GridView>(Resource.Id.asientosGridView);
            gridview.Adapter = new AsientosGridAdapter(this, _texts);

            gridview.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args) {
                Toast.MakeText(this, _texts[args.Position], ToastLength.Short).Show();
            };

            ciudadNombre = Intent.Extras.GetString("selectedCiudadNombre");
            sucursalNombre = Intent.Extras.GetString("selectedSucursalNombre");
            funcionNombre = Intent.Extras.GetString("selectedFuncionNombre");
            horario = DateTime.Parse(Intent.Extras.GetString("selectedHorario"));
            boletosNombre = "Boletos: " + Intent.Extras.GetString("cantidadBoletos");
            funcionId = Intent.Extras.GetInt("selectedFuncionId");

            FindViews();

            BindData();
        }

        private void BindData()
        {
            ciudadTitleTextView.Text = ciudadNombre;
            sucursalTitleTextView.Text = sucursalNombre;
            peliculaTitleTextView.Text = funcionNombre;
            horarioTitleTextView.Text = horario.ToString("dd/MMM/yyyy") + "- " + horario.ToString("HH:mm");
            boletosTitleTextView.Text = boletosNombre;
        }

        private void FindViews()
        {
            ciudadTitleTextView = FindViewById<TextView>(Resource.Id.ciudadTitleTextView);
            sucursalTitleTextView = FindViewById<TextView>(Resource.Id.sucursalTitleTextView);
            peliculaTitleTextView = FindViewById<TextView>(Resource.Id.peliculaTitleTextView);
            horarioTitleTextView = FindViewById<TextView>(Resource.Id.horarioTitleTextView);
            boletosTitleTextView = FindViewById<TextView>(Resource.Id.boletosTitleTextView);
            //addButton = FindViewById<Button>(Resource.Id.addButton);

            timerTextView = FindViewById<TextView>(Resource.Id.timerTextView);
            timerTextView.Text = SecondsToCountDown();
        }

        private void TimerElapsedEvent(object sender, ElapsedEventArgs e)
        {
            if (_countseconds > 0)
            {
                _countseconds--;

                RunOnUiThread(() => DisplaySeconds());
            }

            if (_countseconds == 0)
            {
                _timer.Stop();
                RunOnUiThread(() => ReturnToBoletos());
            }
        }

        private void ReturnToBoletos()
        {
            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Aviso");
            dialog.SetPositiveButton("OK", DialogButtonHandler);
            dialog.SetMessage("Ha transcurrido el tiempo límite para comprar los boletos, vuelve a seleccionar tus asientos");
            dialog.Show();
        }

        private void DialogButtonHandler(object sender, DialogClickEventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(SeleccionaBoletosActivity));
            intent.PutExtra("selectedFuncionId", funcionId);
            intent.PutExtra("selectedCiudadNombre", ciudadNombre);
            intent.PutExtra("selectedSucursalNombre", sucursalNombre);
            intent.PutExtra("selectedFuncionNombre", funcionNombre);
            intent.PutExtra("selectedHorario", horario.ToString("yyyy-MM-ddTHH:mm"));

            StartActivity(intent);
        }

        private string SecondsToCountDown()
        {
            int mins = _countseconds / 60;
            int seconds = _countseconds - mins * 60;
            return string.Format("{0}:{1}", mins.ToString("00"), seconds.ToString("00"));
        }

        private void DisplaySeconds()
        {
            TextView timerText = FindViewById<TextView>(Resource.Id.timerTextView);
            timerText.Text = SecondsToCountDown();
        }
    }
}