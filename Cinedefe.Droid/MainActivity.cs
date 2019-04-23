using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace Cinedefe.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button carteleraButton;
        private Button boletosButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            FindViews();
            HandleEvents();
        }

        private void FindViews()
        {
            carteleraButton = FindViewById<Button>(Resource.Id.carteleraButton);
            boletosButton = FindViewById<Button>(Resource.Id.boletosButton);
        }

        private void HandleEvents()
        {
            carteleraButton.Click += CarteleraButton_Click;
            boletosButton.Click += BoletosButton_Click;

        }

        private void CarteleraButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(SeleccionaCiudadActivity));
            StartActivity(intent);
        }

        private void BoletosButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MisBoletosActivity));
            StartActivity(intent);
        }
    }
}