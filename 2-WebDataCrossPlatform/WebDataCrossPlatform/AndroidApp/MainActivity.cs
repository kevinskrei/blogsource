using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
	[Activity (Label = "AndroidApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private AndroidApplicationLayer _appLayer;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		
			SetContentView (Resource.Layout.Main);

			_appLayer = new AndroidApplicationLayer (this);

			Button fake = FindViewById<Button> (Resource.Id.fake);
			
			fake.Click += async delegate {
				var message = await _appLayer.SimulatedDownload();
				_appLayer.ShowNotification(message);
			};

			Button real = FindViewById<Button> (Resource.Id.real);
			real.Click += async delegate {
				var message = await _appLayer.RealDownload();
				_appLayer.ShowNotification(message);
			};
		}
	}
}


