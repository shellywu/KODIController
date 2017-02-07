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

namespace KODIRemoteController.Model
{
    class Helper
    {
        public static string GetEnumMethodName(Enum code) {
            return $"{code.GetType().Name}.{code.ToString()}";
        }
    }
}