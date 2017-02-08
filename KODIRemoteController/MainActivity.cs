using Android.App;
using Android.Widget;
using Android.OS;
using System;
using KODIRemoteController.Model;

namespace KODIRemoteController
{
    [Activity(Label = "KODIRemoteController", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private JsonRpcClient _jsonClient;
        private string _serverHost = "http://192.168.88.106:8080";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _jsonClient = new Model.JsonRpcClient(_serverHost);
            InitControlAction();
        }

        private void InitControlAction()
        {
            var btnShutDown = FindViewById<ImageView>(Resource.Id.btnShutDown);
            btnShutDown.Click += async (sender, args) =>
             {
                 await _jsonClient.SendRequstAsync(Model.RPCModelFactory.GetRequestModel(Model.System.ShutDown));
             };

            var btnUp = FindViewById<Button>(Resource.Id.btnUp);
            btnUp.Click += async (sender, args) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Up));
            };

            var btnDown = FindViewById<Button>(Resource.Id.btnDown);
            btnDown.Click += async (sender, args) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Down));

            };

            var btnLeft = FindViewById<Button>(Resource.Id.btnLeft);
            btnLeft.Click += async (sender, args) =>
             {
                 await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Left));

             };

            var btnRight = FindViewById<Button>(Resource.Id.btnRight);
            btnRight.Click += async (sender, args) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Right));

            };

            var btnOk = FindViewById<Button>(Resource.Id.btnOk);
            btnOk.Click += async (sender, args) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Select));
            };

            var btnBack = FindViewById<Button>(Resource.Id.btnBack);
            btnBack.Click += async (sender, args) =>
             {
                 await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Back));

             };

            var btnHome = FindViewById<ImageButton>(Resource.Id.btnHome);
            btnHome.Click += async (sender, args) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Input.Home));
            };

            var volUp = FindViewById<Button>(Resource.Id.btnVolUp);
            volUp.Click += async (s, e) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Model.Application.SetVolume, VolumeMethod.Up));
            };

            var volDown = FindViewById<Button>(Resource.Id.btnVolDown);
            volDown.Click += async (s, e) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Model.Application.SetVolume, VolumeMethod.Down));
            };

            var volMute = FindViewById<ImageButton>(Resource.Id.btnVolZero);
            volMute.Click += async (s, e) =>
            {
                await _jsonClient.SendRequstAsync(RPCModelFactory.GetRequestModel(Model.Application.SetMute,VolumeMethod.Down));
            };
        }
    }
}

