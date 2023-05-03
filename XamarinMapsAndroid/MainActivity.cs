using System.ComponentModel;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using SharedCode.Services;
using SharedCode.ViewModels;
using XamarinMapsAndroid.adapters;

namespace XamarinMapsAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, IOnMapReadyCallback
    {
        private GoogleMap GMap;
        private RecyclerView placesRecyclerView;

        private PlacesViewModel viewModel = IocService.GetService<PlacesViewModel>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            if (GMap == null)
            {
                var mapFragment = (MapFragment)FragmentManager.FindFragmentById(Resource.Id.mapContainer);
                mapFragment.GetMapAsync(this);
            }

        }
        public void OnMapReady(GoogleMap googleMap)
        {
            googleMap.MapType = GoogleMap.MapTypeHybrid;
            googleMap.UiSettings.ZoomControlsEnabled = true;
            googleMap.UiSettings.CompassEnabled = true;
            this.GMap = googleMap;
            viewModel.PropertyChanged += UpdateUI;
            viewModel.LoadPlacesCommand.Execute(null);
            GMap.MarkerClick += GMap_MarkerClick;
        }

        private void GMap_MarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
        {
            var item = viewModel.Places.FindIndex(i => i.name == e.Marker.Title);
            viewModel.CurrentPlaceIndex = item;
            viewModel.CurrentPlace = viewModel.Places[item];
        }

        public void UpdateUI(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName) {
                case nameof(viewModel.Places):
                    SetAdapter();
                    var places = viewModel.Places;
                    foreach (var place in places)
                    {
                        var position = new LatLng(place.geometry.location.lat, place.geometry.location.lng);
                        AddMarker(position, place.name);
                    }
                    var location = new LatLng(places[0].geometry.location.lat, places[0].geometry.location.lng);
                    SetPosition(location);
                    break;
                case nameof(viewModel.CurrentPlace):
                    var loc = new LatLng(viewModel.CurrentPlace.geometry.location.lat, viewModel.CurrentPlace.geometry.location.lng);
                    SetPosition(loc);
                    placesRecyclerView.SmoothScrollToPosition(viewModel.CurrentPlaceIndex);
                    (placesRecyclerView.GetAdapter() as PlaceListAdapter).rowIndex = viewModel.CurrentPlaceIndex;
                    (placesRecyclerView.GetAdapter() as PlaceListAdapter).NotifyDataSetChanged();
                    break;
            }
            
        }

        public void AddMarker(LatLng position, string name)
        {
            MarkerOptions markerOpt = new MarkerOptions();
            markerOpt.SetPosition(position);
            markerOpt.SetTitle(name);
            GMap.AddMarker(markerOpt);
        }

        public void SetPosition(LatLng location)
        {
            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();
            builder.Target(location);
            builder.Zoom(18);
            //builder.Bearing(155);
            //builder.Tilt(65);

            CameraPosition cameraPosition = builder.Build();

            CameraUpdate cameraUpdate = CameraUpdateFactory.NewCameraPosition(cameraPosition);
            GMap.AnimateCamera(cameraUpdate);
        }

        public void SetAdapter()
        {
            placesRecyclerView = FindViewById<RecyclerView>(Resource.Id.rvPlaceItems);
            placesRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            var placeListAdapter = new PlaceListAdapter(viewModel.Places);
            placeListAdapter.ClickItem += (o, e) =>
            {
                viewModel.CurrentPlaceIndex = e.Position;
                viewModel.CurrentPlace = e.Place;
            };
            placesRecyclerView.SetAdapter(placeListAdapter);
        }
    }
}
