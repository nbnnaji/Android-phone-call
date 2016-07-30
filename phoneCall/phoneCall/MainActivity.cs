using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.App;

using Android.Content;
using Android.Views;

using Android.Support.V4.Widget;

//Aliases created for these librarires
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using SupportActionBar = Android.Support.V7.App.ActionBar;
using AlertDialog = Android.Support.V7.App.AlertDialog;



namespace phoneCall
{
	[Activity(Label = "phoneCall", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		string telNum = "2122122123";
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			//Alertdialogue initiated for user to make a call
			try
			{
				var callDialog = new AlertDialog.Builder(this, Resource.Style.MyAlertDialogStyle);

				callDialog.SetTitle("Call " + telNum + " ?");
				callDialog.SetNegativeButton("Cancel", delegate { });
				callDialog.SetNeutralButton("Call", delegate
				{
					var callIntent = new Intent(Intent.ActionDial);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + telNum));
					StartActivity(callIntent);
				});


				// Show the alert dialog to the user and wait for response.
				callDialog.Show();
			}

			catch (ActivityNotFoundException ex)
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.SetTitle("Error");
				builder.SetMessage("Service unavailable.Please try again later." + ex.Message);
				builder.SetCancelable(false);
				builder.SetPositiveButton("OK", delegate
				{
					StartActivity(typeof(MainActivity));
				});
			}

		}

	}
}
	