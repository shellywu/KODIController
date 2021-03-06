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
    class RPCRequestModel
    {
        public int Id { get; set; } = 1;
        public string Jsonrpc { get; set; } = "2.0";
        public string Method { get; set; }
        public object Params { get; set; }
    }
}