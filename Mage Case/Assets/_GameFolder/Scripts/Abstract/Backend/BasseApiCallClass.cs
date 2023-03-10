using System.Threading;
using MageCase.Scriptableobjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MageCase.Abstract.Backend
{
    public abstract class BasseApiCallClass
    {
        protected ApiUrlDataContainerSo UrlDataContainerSo;

        public BasseApiCallClass(ApiUrlDataContainerSo apiUrlDataContainerSo)
        {
            UrlDataContainerSo = apiUrlDataContainerSo;
        }

        protected T GetApiCall<T>(ApiUrlDataContainerSo urlDataContainerSo, int index = 0)
        {
            var url = urlDataContainerSo.GetUrlByIndex(index);
            if (string.IsNullOrEmpty(url))
                Debug.Log("url is empty");
            else
                using (var webRequest = UnityWebRequest.Get(url))
                {
                    webRequest.SendWebRequest();
                    var token = new CancellationTokenSource();
                    while (!webRequest.isDone)
                        if (token.IsCancellationRequested)
                            break;

                    if (UnityWebRequest.Result.Success == webRequest.result)
                        try
                        {
                            var getResult = webRequest.downloadHandler.text;
                            var apiResult = JsonConvert.DeserializeObject<T>(getResult);
                            return apiResult;
                        }
                        catch
                        {
                            Debug.LogError("Api call failed and throw exception");
                        }
                }

            return default;
        }
    }
}