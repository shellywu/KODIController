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
                reqData.Method = Model.Helper.GetEnumMethodName(Model.System.ShutDown);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await  rpcClient.SendRequstAsync(reqData);
            };

            var btnUp = FindViewById<Button>(Resource.Id.btnUp);
            btnUp.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method =Model.Helper.GetEnumMethodName(Model.Input.Up);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnDown = FindViewById<Button>(Resource.Id.btnDown);
            btnDown.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Down);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnLeft = FindViewById<Button>(Resource.Id.btnLeft);
            btnLeft.Click+= async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Left);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnRight = FindViewById<Button>(Resource.Id.btnRight);
            btnRight.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Right);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnOk = FindViewById<Button>(Resource.Id.btnOk);
            btnOk.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Select);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click+= async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Back);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

            var btnHome = FindViewById<ImageButton>(Resource.Id.btnHome);
            btnHome.Click += async (sender, args) =>
            {
                var reqData = new Model.RPCRequestModel();
                reqData.Id = 1;
                reqData.Method = Model.Helper.GetEnumMethodName(Model.Input.Home);
                var rpcClient = new Model.JsonRpcClient(_serverHost);
                await rpcClient.SendRequstAsync(reqData);
            };

        }
    }
}

