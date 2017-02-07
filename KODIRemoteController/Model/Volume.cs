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
    class Volume
    {
        public const string Decrement = "decrement";
        public const string Increment = "increment";
        public const string Toggle = "toggle";

        public static object GetVolumeParamsObject(VolumeMethod method)
        {
            var methods = new Dictionary<VolumeMethod, string>();
            methods.Add(VolumeMethod.Up, Increment);
            methods.Add(VolumeMethod.Down, Decrement);

            return new { volume = methods[method] };
        }

        public static object GetVoulueParamsForMute()
        {
            return new { mute = Toggle };
        }
    }
}