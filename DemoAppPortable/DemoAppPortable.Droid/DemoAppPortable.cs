using System;
using System.IO;
using Android.App;
using DemoAppPortable.BusinessLayer.Managers;

namespace DemoAppPortable.Droid
{
    [Application]
    public class DemoAppPortable : Application
    {
        public static DemoAppPortable Current { get; set; }
        public TaskManager TaskManager { get; set; }

        public DemoAppPortable(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var databaseFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            
            var dbFullPath = Path.Combine(databaseFolderPath, "DemoAppDatabaseTestt222tt.db3");
           
            TaskManager = new TaskManager(databaseFolderPath);
        }
    }
}