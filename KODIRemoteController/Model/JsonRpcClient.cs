using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

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

        public async Task<bool> SendRequstAsync(RPCRequestModel reqData)
        {
            var req = HttpWebRequest.Create(GetJsonRpcUrl(reqData.Method)) as HttpWebRequest;
            req.Method = _option.Type;
            req.ContentType = _option.ContentType;
            var byteData = GetRequstByteData(reqData);
            req.ContentLength = byteData.Length;
            req.GetRequestStream().Write(byteData, 0, byteData.Length);
            var response = await req.GetResponseAsync() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(response.GetResponseStream());
                var r = reader.ReadToEnd();
                return true;
            }
            return false;
        }

        private byte[] GetRequstByteData(RPCRequestModel reqData)
        {
            var jsonStr = JsonConvert.SerializeObject(reqData
                , Formatting.Indented
                , new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                });
            return Encoding.UTF8.GetBytes(jsonStr);
        }

        private string GetJsonRpcUrl(string method)
        {
            return $"{_option.RpcServer}/jsonrpc?{method}";
        }
    }
}