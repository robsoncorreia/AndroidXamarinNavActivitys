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

namespace AndroidXamarin2
{
    [Activity(Label = "Vista Capital")]
    public class VistaCapital : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.VistaCapital);
            // Create your application here
            EditText txtMexico = FindViewById<EditText>(Resource.Id.txtMexico);
            EditText txtColombia = FindViewById<EditText>(Resource.Id.txtColombia);

            try
            {
                double x = 0, y = 0;
                txtMexico.Text = Intent.GetDoubleExtra("capitalM", x).ToString();
                txtColombia.Text = Intent.GetDoubleExtra("capitalC", y).ToString();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
            }
        }
    }
}