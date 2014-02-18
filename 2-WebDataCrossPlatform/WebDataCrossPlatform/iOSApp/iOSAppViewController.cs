using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace iOSApp
{
	public partial class iOSAppViewController : UIViewController
	{
		private ApplicationLayer _appLayer;
		public iOSAppViewController () : base ("iOSAppViewController", null)
		{
			_appLayer = new ApplicationLayer (this);
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			_simulateButton.TouchUpInside += async delegate {
				var message = await _appLayer.SimulatedDownload();
				_appLayer.ShowNotification(message);
			};

			_realDownload.TouchUpInside += async delegate {
				var message = await _appLayer.RealDownload();
				_appLayer.ShowNotification(message);
			};

		}
	}
}

