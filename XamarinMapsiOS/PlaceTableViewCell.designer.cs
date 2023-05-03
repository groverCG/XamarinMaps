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
	[Register ("PlaceTableViewCell")]
	partial class PlaceTableViewCell
	{
		[Outlet]
		UIKit.UILabel placeLatLabel { get; set; }

		[Outlet]
		UIKit.UILabel placeLngLabel { get; set; }

		[Outlet]
		UIKit.UILabel placeNameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (placeNameLabel != null) {
				placeNameLabel.Dispose ();
				placeNameLabel = null;
			}

			if (placeLatLabel != null) {
				placeLatLabel.Dispose ();
				placeLatLabel = null;
			}

			if (placeLngLabel != null) {
				placeLngLabel.Dispose ();
				placeLngLabel = null;
			}
		}
	}
}
