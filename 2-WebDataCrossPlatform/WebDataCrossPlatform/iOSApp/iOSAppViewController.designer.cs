// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace iOSApp
{
	[Register ("iOSAppViewController")]
	partial class iOSAppViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton _realDownload { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton _simulateButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_simulateButton != null) {
				_simulateButton.Dispose ();
				_simulateButton = null;
			}

			if (_realDownload != null) {
				_realDownload.Dispose ();
				_realDownload = null;
			}
		}
	}
}
