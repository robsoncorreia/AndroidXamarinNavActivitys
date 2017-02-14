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
using SQLite;
using System.IO;

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

            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);

            var elementos = from s in conn.Table<Informacao>() select s;
            foreach (var fila in elementos)
            {
                Toast.MakeText(this, fila.IngressoMexico.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.EgressoMexico.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.IngressoColombia.ToString(), ToastLength.Short).Show();
                Toast.MakeText(this, fila.EgressoColombia.ToString(), ToastLength.Short).Show();
            }
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