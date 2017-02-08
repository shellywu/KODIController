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
    class RPCModelFactory
    {
        public static RPCRequestModel GetRequestModel<T>(T enumCode,params Enum[] args) {
            if (enumCode is System) {
                return GetSystemRequestModel((System)Enum.Parse(typeof(System), enumCode.ToString()));
            }
            if (enumCode is Input) {
                return GetInputRequestModel((Input)Enum.Parse(typeof(Input), enumCode.ToString()));
            }
            if (enumCode is Application) {
                return GetVolumeMethodRequestModel((Application)Enum.Parse(typeof(Application), enumCode.ToString()),(VolumeMethod)args[0]);
            }
            throw new NotImplementedException();
        }

        private static RPCRequestModel GetVolumeMethodRequestModel(Application appMethod,VolumeMethod volumeMethod)
        {
            var reqData = new RPCRequestModel();
            reqData.Id = 1;
            reqData.Method = Helper.GetEnumMethodName(appMethod);
            reqData.Params = appMethod == Application.SetVolume ? Volume.GetVolumeParamsObject(volumeMethod) : Volume.GetVoulueParamsForMute();
            return reqData;
        }

        private static RPCRequestModel GetSystemRequestModel(System system)
        {
            var reqData = new RPCRequestModel();
            reqData.Id = 1;
            reqData.Method = Helper.GetEnumMethodName(system);
            return reqData;
        }

        private static RPCRequestModel GetInputRequestModel(Input enumCode)
        {
            var reqData = new RPCRequestModel();
            reqData.Id = 1;
            reqData.Method = Helper.GetEnumMethodName(enumCode);
            return reqData;
        }
    }
}