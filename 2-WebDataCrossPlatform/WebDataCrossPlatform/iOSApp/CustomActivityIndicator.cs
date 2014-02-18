using System;
using MonoTouch.UIKit;

namespace iOSApp
{
	public class CustomActivityIndicator : UIView
	{
		private UIAlertView _progressDialog;

		public CustomActivityIndicator (string message = null)
		{
			_progressDialog = new UIAlertView (string.Empty, message, null, null, null);
		}

		public void Show()
		{
			if (_progressDialog != null) {
				_progressDialog.Show ();
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
			}
		}

		public void Dismiss()
		{
			if (_progressDialog != null) {
				_progressDialog.DismissWithClickedButtonIndex (0, true);
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
			}
		}

		protected override void Dispose (bool disposing)
		{
			base.Dispose (disposing);
			if (_progressDialog != null) {
				_progressDialog.DismissWithClickedButtonIndex (0, true);
				UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
				_progressDialog.Dispose ();
				_progressDialog = null;
			}
		}
	}
}


