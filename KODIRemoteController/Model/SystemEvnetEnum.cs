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
    enum System
    {
        ShutDown = 0,

    }

    enum Input
    {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3,
        Select = 4,
        Home = 5,
        Back=6
    }
    enum Application
    {
        SetVolume = 0,
        SetMute=1,
    }

    enum VolumeMethod {
        Up=0,
        Down=1
    }

    enum Player {
        PlayPause=0,
        Stop=1,
    }
}