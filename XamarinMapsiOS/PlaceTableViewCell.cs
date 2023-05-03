using System;

using Foundation;
using SharedCode.Models;
using UIKit;

namespace XamarinMapsiOS
{
	public partial class PlaceTableViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("PlaceTableViewCell");
		public static readonly UINib Nib;

		static PlaceTableViewCell ()
		{
			Nib = UINib.FromName ("PlaceTableViewCell", NSBundle.MainBundle);
		}

		protected PlaceTableViewCell (IntPtr handle) : base (handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateCell(Place place)
		{
			placeNameLabel.Text = place.name;
			placeLatLabel.Text = place.geometry.location.lat.ToString();
			placeLngLabel.Text = place.geometry.location.lng.ToString();
		}
	}
}
