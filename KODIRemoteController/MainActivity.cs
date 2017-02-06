using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace KODIRemoteController
{
    [Activity(Label = "KODIRemoteController", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private string _serverHost = "http://192.168.88.106:8080";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            InitControlAction();
        }

        private void InitControlAction()
        {
            var btnShutDown = FindViewById<ImageView>(Resource.Id.btnShutDown);
            btnShutDown.Click +=async (sender, args) =>
            {
               
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = "System.Shutdown";
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await  rpcClient.SendRequstAsync(reqData);
            };

            var btnUp = FindViewById<Button>(Resource.Id.btnUp);
            btnUp.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = "Input.Up";
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };
        }
    }
}

