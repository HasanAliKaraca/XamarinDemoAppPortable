using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.View.Menu;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using DemoAppPortable.BusinessLayer.Entities;

namespace DemoAppPortable.Droid
{
    public interface IRecyclerViewOnClickListener
    {
        void OnClick(View v, int adapterPosition, int layoutPosition);
    }
    public class TaskRecyclerViewAdapter : RecyclerView.Adapter
    {
        //private readonly View.IOnClickListener _clickListener;
        private readonly IRecyclerViewOnClickListener _clickListener;
        private readonly List<TaskEntity> _taskList;

        public TaskRecyclerViewAdapter(List<TaskEntity> tasks, IRecyclerViewOnClickListener clickListener)
        {
            this._clickListener = clickListener;
            this._taskList = tasks.ToList();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as TaskViewHolder;

            if (viewHolder == null)
            {
                return;
            }

            var task = _taskList[position];

            viewHolder.TaskNameView.Text = task.Name;
            //viewHolder.View.SetOnClickListener(_clickListener);
            //viewHolder.View.SetOnClickListener(this);



            //if (string.IsNullOrWhiteSpace(acquaintance.SmallPhotoUrl))
            //    viewHolder.ProfilePhotoImageView.SetImageBitmap(null);
            //else
            //    // use FFImageLoading library to asynchronously:
            //    await ImageService
            //        .Instance
            //        .LoadUrl(acquaintance.SmallPhotoUrl, TimeSpan.FromHours(Settings.ImageCacheDurationHours))  // get the image from a URL
            //        .LoadingPlaceholder("placeholderProfileImage.png")                                          // specify a placeholder image
            //        .Transform(new CircleTransformation())                                                      // transform the image to a circle
            //        .Error(e => System.Diagnostics.Debug.WriteLine(e.Message))
            //        .IntoAsync(viewHolder.ProfilePhotoImageView);

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var context = parent.Context;

            var itemView = LayoutInflater.From(context).Inflate(Resource.Layout.TaskRecyclerViewRow, parent, false);

            var viewHolder = new TaskViewHolder(context, itemView, _clickListener);

            return viewHolder;
        }

        public void OnClick(View view)
        {

            //_clickListener.OnClick(view);

            //int position = AdapterPosition;
            //if (position != RecyclerView.NoPosition)
            //{

            //}

            //Toast.MakeText(view.Context, " týklandý ", ToastLength.Long);
            //// setup an intent
            //var detailIntent = new Intent(view.Context, typeof(AcquaintanceDetailActivity));

            //// get an item by position (index)
            //var acquaintance = Acquaintances[(int)view.Tag];

            //// Add some identifying item data to the intent. In this case, the id of the acquaintance for which we're about to display the detail screen.
            //detailIntent.PutExtra(view.Context.Resources.GetString(Resource.String.acquaintanceDetailIntentKey), acquaintance.Id);

            //// get a referecne to the profileImageView
            //var profileImageView = view.FindViewById(Resource.Id.profilePhotoImageView);

            //// shared element transitions are only supported on Android 5.0+
            //if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            //{
            //    // define transitions 
            //    var transitions = new List<Android.Util.Pair>() {
            //        Android.Util.Pair.Create(profileImageView, view.Context.Resources.GetString(Resource.String.profilePhotoTransition)),
            //    };

            //    // create an activity options instance and bind the above-defined transitions to the current activity
            //    var transistionOptions = ActivityOptions.MakeSceneTransitionAnimation(view.Context as Activity, transitions.ToArray());

            //    // start (navigate to) the detail activity, passing in the activity transition options we just created
            //    view.Context.StartActivity(detailIntent, transistionOptions.ToBundle());
            //}
            //else
            //{
            //    view.Context.StartActivity(detailIntent);
            //}
        }

        public override int ItemCount => _taskList.Count;

        public class TaskViewHolder : RecyclerView.ViewHolder, View.IOnClickListener
        {
            private Context Context { get; }
            public View ItemView { get; }
            private IRecyclerViewOnClickListener _clickListener;
            public TextView TaskNameView { get; }
            //public ImageViewAsync ProfilePhotoImageView { get; }
            public TaskViewHolder(Context context, View itemView, IRecyclerViewOnClickListener clickListener) : base(itemView)
            {
                _clickListener = clickListener;
                this.Context = context;
                this.ItemView = itemView;

                TaskNameView = (TextView)itemView.FindViewById(Resource.Id.tv_task_name);

                itemView.SetOnClickListener(this);
            }

            public void OnClick(View v)
            {
                //LayoutPosition
                int adapterPosition = AdapterPosition;
                var layoutPosition = LayoutPosition;

                //String weatherForDay = mWeatherData[adapterPosition];
                _clickListener.OnClick(v, adapterPosition, layoutPosition); //.onClick(weatherForDay);
            }
        }
    }

}