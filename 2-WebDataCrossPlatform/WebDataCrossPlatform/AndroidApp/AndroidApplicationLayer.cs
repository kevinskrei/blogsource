using System;
using Common;
using Android.Content;
using Android.App;
using Android.Widget;

namespace AndroidApp
{
	public class AndroidApplicationLayer : ApplicationLayerBase
	{
		private Activity _context;
		private ProgressDialog _progressDialog;
		public AndroidApplicationLayer (Activity context)
		{
			_context = context;
		}

		#region implemented abstract members of ApplicationLayerBase

		public override void ShowProgressDialog (string message)
		{
			_context.RunOnUiThread(() => {
				if(_progressDialog != null)
				{
					_progressDialog.Dismiss ();
					_progressDialog= null;
				}
				_progressDialog = new ProgressDialog(_context);
				_progressDialog.SetMessage(message);
				_progressDialog.Show();
			});
		}

		public override void DismissProgressDialog ()
		{
			_context.RunOnUiThread (() => {
				if (_progressDialog != null && _progressDialog.IsShowing) {
					_progressDialog.Dismiss ();
					_progressDialog = null;
				}
			});
		}

		public override void ShowNotification (string message)
		{
			_context.RunOnUiThread (() => Toast.MakeText (_context, message, ToastLength.Long).Show ());
		}

		#endregion
	}
}

