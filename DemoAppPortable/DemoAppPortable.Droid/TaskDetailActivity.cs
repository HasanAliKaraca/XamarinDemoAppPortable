using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using DemoAppPortable.BusinessLayer.Entities;

namespace DemoAppPortable.Droid
{
    [Activity(Label = "TaskDetailActivity")]
    public class TaskDetailActivity : AppCompatActivity
    {
        public static string TASK_INTENT_KEY = "task_name";

        private TaskEntity _task;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TaskDetail);

            // setup the action bar
            Android.Support.V7.Widget.Toolbar toolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.toolbar);
            toolbar.Title = "Task Detail";
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var intent = Intent;
            int taskId = intent.GetIntExtra(TASK_INTENT_KEY, 0);
            if (taskId > 0)
            {
                _task = DemoAppPortable.Current.TaskManager.GetTask(taskId);
                SupportActionBar.Title = _task.Name;

                FillViewData(_task);
            }
        }

        private void FillViewData(TaskEntity task)
        {
            EditText edTaskName = (EditText)FindViewById(Resource.Id.et_task_name);
            EditText edTaskDetail = (EditText)FindViewById(Resource.Id.et_task_detail);

            edTaskName.Text = task.Name;
            edTaskDetail.Text = task.Detail;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_save, menu);

            return true; // base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_save:
                    SaveTask();
                    return true;

                case Android.Resource.Id.Home:
                    Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void SaveTask()
        {
            EditText edTaskName = (EditText)FindViewById(Resource.Id.et_task_name);
            EditText edTaskDetail = (EditText)FindViewById(Resource.Id.et_task_detail);

            var taskName = edTaskName.Text;
            var taskDetail = edTaskDetail.Text;

            //TODO VALIDATION

            TaskEntity entity = new TaskEntity();
            entity.Name = taskName;
            entity.Detail = taskDetail;
            if (_task != null)
            {
                entity.Id = _task.Id;
            }

            DemoAppPortable.Current.TaskManager.SaveTask(entity);

            Finish();

        }
    }
}