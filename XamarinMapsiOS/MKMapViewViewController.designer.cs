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
	[Register ("MKMapViewViewController")]
	partial class MKMapViewViewController
	{
		[Outlet]
		UIKit.UIButton goToMarkerButton { get; set; }

		[Outlet]
		UIKit.UIView mapContainerView { get; set; }

		[Outlet]
		UIKit.UITableView placesTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (goToMarkerButton != null) {
				goToMarkerButton.Dispose ();
				goToMarkerButton = null;
			}

			if (mapContainerView != null) {
				mapContainerView.Dispose ();
				mapContainerView = null;
			}

			if (placesTableView != null) {
				placesTableView.Dispose ();
				placesTableView = null;
			}
		}
	}
}
