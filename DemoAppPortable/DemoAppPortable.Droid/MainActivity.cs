using System;
using System.Linq;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using DemoAppPortable.BusinessLayer.Entities;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using DemoAppPortable.Droid.ViewModel;


namespace DemoAppPortable.Droid
{
    [Activity(MainLauncher = true, Icon = "@drawable/icon")]
    //[Activity(Label = "DemoAppPortable.Droid",  Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity, IRecyclerViewOnClickListener
    {
        TaskRecyclerViewAdapter _adapter;

        private SwipeRefreshLayout _swipeRefreshLayout;
        private RecyclerView _recyclerView;

        public List<TaskEntity> TaskList { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var layoutManager = new LinearLayoutManager(this);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_task);
            _recyclerView.SetLayoutManager(layoutManager);

            // setup the action bar
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.Title = "Test";
            SetSupportActionBar(toolbar);

            var newTaskButton = FindViewById<FloatingActionButton>(Resource.Id.fab_new_task);

            newTaskButton.Click += NewTaskButton_Click;

            //Title = SupportActionBar.Title = "Acquaintances";

            _swipeRefreshLayout = (SwipeRefreshLayout)FindViewById(Resource.Id.srl_task);

            _swipeRefreshLayout.Refresh += (sender, e) => { LoadTasks(); };

        }

        private void LoadTasks()
        {
            TaskList = DemoAppPortable.Current.TaskManager.GetTaskList();

            _swipeRefreshLayout.Refreshing = false;
            _adapter = new TaskRecyclerViewAdapter(TaskList, this);
            _recyclerView.SetAdapter(_adapter);
        }

        private void NewTaskButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TaskDetailActivity));
            //intent.PutExtra(TaskDetailActivity.TASK_INTENT_KEY,)
            StartActivity(new Intent(this, typeof(TaskDetailActivity)));
        }

        protected override void OnResume()
        {
            base.OnResume();

            LoadTasks();
        }

        public void OnClick(View v, int adapterPosition, int layoutPosition)
        {
            var position = adapterPosition;
            var task = position >= 0 ? TaskList[position] : null;
            if (position == RecyclerView.NoPosition || task == null)
            {
                return;
            }

            var context = v.Context;
            var text = "position: " + position.ToString() + " taskName: " + task.Name;
            Toast.MakeText(context, text, ToastLength.Short).Show();

            var bundle = new Bundle();

            int taskId = task.Id;

            Intent intent = new Intent(this, typeof(TaskDetailActivity));
            intent.PutExtra(TaskDetailActivity.TASK_INTENT_KEY, taskId);
            //intent.PutExtra(TaskDetailActivity.TASK_INTENT_KEY,taskViewModel);

            StartActivity(intent);
        }
    }





}


