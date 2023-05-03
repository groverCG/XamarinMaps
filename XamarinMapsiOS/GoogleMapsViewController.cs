// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;
using Google.Maps;
using CoreGraphics;
using Xamarin.Essentials;

namespace XamarinMapsiOS
{
	public partial class GoogleMapsViewController : UIViewController
	{
        MapView mapView;
		public GoogleMapsViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var camera = CameraPosition.FromCamera(latitude: 37.79, longitude: -122.40, zoom: 6);
            mapView = MapView.FromCamera(CGRect.Empty, camera);
            mapView.MyLocationEnabled = true;
            mapView.MapType = MapViewType.Hybrid;
            (mapContainerView as MapView).MapType = MapViewType.Hybrid;
            goToMarkerButton.TouchUpInside += (s, e) =>
            {
                SetPosition();
            };
            AddMarker();
            //mapContainerView.AddSubview(mapView);
            //mapContainerView = mapView;
            //View.AddSubview(mapView);
            //View = mapView
        }

        public void AddMarker()
        {
            var marker = new Marker();
            marker.Position = new CoreLocation.CLLocationCoordinate2D(50.379444, 2.773611);
            marker.Title = "Test title";
            marker.Snippet = "Test snippet";
            marker.Map = mapContainerView as MapView;
        }

        public void SetPosition()
        {
            var camera = CameraPosition.FromCamera(new CoreLocation.CLLocationCoordinate2D(50.379444, 2.773611), 18);
            (mapContainerView as MapView).Animate(camera);
        }
    }
}