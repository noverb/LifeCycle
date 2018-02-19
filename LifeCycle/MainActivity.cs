using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4;
using System;
using Android.Support.V4.App;

namespace LifeCycle
{
    [Activity(Label = "Lifecycle Viewer", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private static string myTextField;
        private static int myTextFieldId;
        private static int numStateChanges = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            TextView txtMsg = FindViewById<TextView> (Resource.Id.txtMessage);
            myTextFieldId = Resource.Id.txtMessage;

            // Handle the BUNDLE (named savedInstanceState) here
            if (savedInstanceState != null)
            {
                numStateChanges = savedInstanceState.GetInt("StateJumps");
            }
            else
            {
                numStateChanges = 0;
            }

            numStateChanges++;

            myTextField = DateTime.Now.ToShortTimeString() + $" Processed OnCreate {numStateChanges.ToString()}\n";
            Toast.MakeText(this, "Leaving the OnCreate method " + numStateChanges.ToString(), ToastLength.Long).Show();

            txtMsg.Text = myTextField;
        }

        protected override void OnStart()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnStart - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnStart();
            Toast.MakeText(this, "Running the OnStart method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }

        protected override void OnResume()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnResume - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnResume();
            Toast.MakeText(this, "Running the OnResume method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }
        protected override void OnPause()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnPause - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnPause();
            Toast.MakeText(this, "Running the OnPause method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }

        protected override void OnRestart()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnRestart - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnRestart();
            Toast.MakeText(this, "Running the OnRestart method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }

        protected override void OnStop()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnStop - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnStop();
            Toast.MakeText(this, "Running the OnStop method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }
        
        protected override void OnDestroy()
        {
            TextView txtMsg = FindViewById<TextView>(myTextFieldId);

            numStateChanges++;

            myTextField += DateTime.Now.ToShortTimeString() + $" Processed OnDestroy - {numStateChanges.ToString()}\n";
            txtMsg.Text = myTextField;
            base.OnDestroy();
            Toast.MakeText(this, "Running the OnDestroy method " + numStateChanges.ToString(), ToastLength.Long).Show();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("StateJumps",numStateChanges);
            base.OnSaveInstanceState(outState);
        }
    }
}

