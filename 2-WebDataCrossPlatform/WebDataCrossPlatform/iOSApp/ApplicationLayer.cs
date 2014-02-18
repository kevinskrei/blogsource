using System;
using MonoTouch.UIKit;

namespace iOSApp
{
	public class ApplicationLayer : Common.ApplicationLayerBase
	{
		private UIViewController _controller;
		private CustomActivityIndicator _progressDialog;
		public ApplicationLayer (UIViewController controller)
		{
			_controller = controller;
		}

		#region implemented abstract members of ApplicationLayerBase

		public override void ShowProgressDialog (string message)
		{
			_controller.BeginInvokeOnMainThread(() => {
				if(_progressDialog != null) {
					_progressDialog.Dispose();
					_progressDialog = null;
				}

				_progressDialog = new CustomActivityIndicator(message);
				_progressDialog.Show();
			});    
		}

		public override void DismissProgressDialog ()
		{
			_controller.BeginInvokeOnMainThread (() => {
				if (_progressDialog != null) {
					_progressDialog.Dispose();
					_progressDialog = null;
				}
			});
		}

		public override void ShowNotification (string message)
		{
			_controller.BeginInvokeOnMainThread (() => {
				var uialert = new UIAlertView ("Hello!", message, null, "OK", null);
				uialert.Show ();
			});
		}

		#endregion
	}
}

