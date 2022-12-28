using System.Threading;
using MageCase.Scriptableobjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Magecase.Abstract.Backend
{
    public abstract class BasseApiCallClass
    {
        protected ApiUrlDataContainer _urlDataContainer;

        public BasseApiCallClass(ApiUrlDataContainer apiUrlDataContainer)
        {
            _urlDataContainer = apiUrlDataContainer;
        }

        protected T GetApiCall<T>(ApiUrlDataContainer urlDataContainer, int index)
        {
            var url = urlDataContainer.GetUrlByIndex(index);
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