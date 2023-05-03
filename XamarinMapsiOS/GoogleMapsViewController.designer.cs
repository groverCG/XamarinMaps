// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinMapsiOS
{
	[Register ("GoogleMapsViewController")]
	partial class GoogleMapsViewController
	{
		[Outlet]
		UIKit.UIButton goToMarkerButton { get; set; }

		[Outlet]
		UIKit.UIView mapContainerView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (mapContainerView != null) {
				mapContainerView.Dispose ();
				mapContainerView = null;
			}

			if (goToMarkerButton != null) {
				goToMarkerButton.Dispose ();
				goToMarkerButton = null;
			}
		}
	}
}
