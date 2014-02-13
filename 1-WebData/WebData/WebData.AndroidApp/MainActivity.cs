using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WebData.AndroidApp
{
	[Activity (Label = "WebData.AndroidApp", MainLauncher = true)]
	public class MainActivity : Activity
	{
		private Button _webviewButton;
		private Button _jsonButton;
		private MyWebService _webservice;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			_webservice = new MyWebService ();
			// Get our button from the layout resource,
			// and attach an event to it
			_webviewButton = FindViewById<Button> (Resource.Id.webview);
			
			_webviewButton.Click += async delegate {
				var html = await _webservice.DownloadString("http://google.com");
				ChangeToBrowser(html);
			};

			_jsonButton = FindViewById<Button> (Resource.Id.json);
			_jsonButton.Click += JsonButtonClicked;
		}

		async void JsonButtonClicked (object sender, EventArgs e)
		{
			var json = await _webservice.DownloadString ("http://date.jsontest.com/");
			ShowToast (json);
		}

		private void ShowToast(string message)
		{
			Toast.MakeText (this, message, ToastLength.Long).Show ();
		}

		private void ChangeToBrowser(string html)
		{
			var intent = new Intent (this, typeof(WebviewActivity));
			intent.PutExtra (Constants.WebviewUriKey, html);
			StartActivity (intent);
		}
	}
}


