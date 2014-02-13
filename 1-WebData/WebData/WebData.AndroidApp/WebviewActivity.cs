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
using Android.Webkit;

namespace WebData.AndroidApp
{
	[Activity (Label = "WebviewActivity")]			
	public class WebviewActivity : Activity
	{
		private WebView _webview;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.WebviewActivity);
			_webview = FindViewById<WebView> (Resource.Id.WebviewActivity_webview);

			var html = Intent.GetStringExtra (Constants.WebviewUriKey);

			_webview.LoadDataWithBaseURL (null, html, "text/html", "utf-8", null);
		}
	}
}

