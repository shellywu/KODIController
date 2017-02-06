using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KODIRemoteController.Model
{
    class JsonRpcClient
    {
        private JsonrpcDefaultOption _option;
        public JsonRpcClient(string host)
        {
            _option = new JsonrpcDefaultOption();
            _option.RpcServer = host;
        }

        public async Task<bool> SendRequstAsync(RPCRequestModel reqData) {
          var req=  HttpWebRequest.Create(GetJsonRpcUrl(reqData.Method)) as HttpWebRequest;
            req.Method = _option.Type;
            req.ContentType = _option.ContentType;
            var byteData= GetRequstByteData(reqData);
            req.GetRequestStream().Write(byteData,0, byteData.Length);
            var response =await req.GetResponseAsync() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK) {
                return true;
            }
            return false;
        }

        private byte[] GetRequstByteData(RPCRequestModel reqData)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reqData));
        }

        private string GetJsonRpcUrl(string method)
        {
            return $"{_option.RpcServer}/jsonrpc?{method}";
        }
    }
}