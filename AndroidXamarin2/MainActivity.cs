using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace AndroidXamarin2
{
    [Activity(Label = "Android Xamarin 2", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        double ingressosM = 0, ingressosC = 0, egressosM = 0, egressosC = 0, capitalM = 0, capitalC = 0;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            EditText mi = FindViewById<EditText>(Resource.Id.txtMexicoI);
            EditText me = FindViewById<EditText>(Resource.Id.txtMexicoE);
            EditText ci = FindViewById<EditText>(Resource.Id.txtColombiaI);
            EditText ce = FindViewById<EditText>(Resource.Id.txtColombiaE);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            

            button1.Click += delegate
            {
                try
                {
                    ingressosM = double.Parse(mi.Text);
                    ingressosC = double.Parse(ci.Text);
                    egressosM = double.Parse(me.Text);
                    egressosC = double.Parse(ce.Text);
                    capitalM = ingressosM - egressosM;
                    capitalC = ingressosC - egressosC;

                    Cargar();

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
        public void Cargar()
        {
            Intent objIntent = new Intent(this,
                typeof(VistaCapital)
              );
            objIntent.PutExtra("capitalM", capitalM);
            objIntent.PutExtra("capitalC", capitalC);
            StartActivity(objIntent);
        }
    }
}

