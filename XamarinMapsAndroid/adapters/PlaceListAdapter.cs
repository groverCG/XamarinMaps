using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using SharedCode.Models;

namespace XamarinMapsAndroid.adapters
{
	public class PlaceListAdapter : RecyclerView.Adapter
	{
        public class CustomArgs
        {
            public Place Place;
            public int Position;

            public CustomArgs(Place place, int position)
            {
                Place = place;
                Position = position;
            }
        }
        public event EventHandler<CustomArgs> ClickItem;
        public event EventHandler<int> UpdateSelectedRow;
        public List<Place> PlaceList;
        public int rowIndex;
        public override int ItemCount
        {
            get { return PlaceList.Count; }
        }

        class PlaceListViewHolder : RecyclerView.ViewHolder
        {
            public TextView PlaceName { get; private set; }
            public TextView Latitude { get; private set; }
            public TextView Longitude { get; private set; }
            public LinearLayout ItemContainer { get; private set; }

            public PlaceListViewHolder(View itemView) : base(itemView)
            {
                PlaceName = (TextView)itemView.FindViewById(Resource.Id.tvPlaceName);
                Latitude = (TextView)itemView.FindViewById(Resource.Id.tvLatitude);
                Longitude = (TextView)itemView.FindViewById(Resource.Id.Longitude);
                ItemContainer = (LinearLayout)itemView.FindViewById(Resource.Id.itemContainer);
            }
        }

        public PlaceListAdapter(List<Place> data)
        {
            this.PlaceList = data;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PlaceListViewHolder vh = holder as PlaceListViewHolder;
            vh.PlaceName.Text = PlaceList[position].name;
            vh.Latitude.Text = PlaceList[position].geometry.location.lat.ToString();
            vh.Longitude.Text = PlaceList[position].geometry.location.lng.ToString();
            vh.ItemContainer.Click += (s, e) =>
            {
                ClickItem?.Invoke(this, new CustomArgs(PlaceList[position], position));
                rowIndex = position;
                NotifyDataSetChanged();
            };
            if (rowIndex == position)
            {
                vh.ItemContainer.SetBackgroundColor(Color.ParseColor("#567845"));
            }
            else
            {
                vh.ItemContainer.SetBackgroundColor(Color.ParseColor("#ffffff"));
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.place_item, parent, false);
            PlaceListViewHolder vh = new PlaceListViewHolder(itemView);
            return vh;
        }
    }
}

