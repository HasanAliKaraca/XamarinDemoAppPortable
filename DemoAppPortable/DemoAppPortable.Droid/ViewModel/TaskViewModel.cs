using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoAppPortable.BusinessLayer.Entities;
using Java.IO;

namespace DemoAppPortable.Droid.ViewModel
{
    public class TaskViewModel : TaskEntity, ISerializable
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public IntPtr Handle { get; }
    }
}