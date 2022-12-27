using System;
using System.Threading;
using Magecase.Abstract.Backend;
using MageCase.Scriptableobjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace Magecase.Backend
{
    public class ApiCall : IApiCall
    {
        ApiUrlDataContainer _leaderBoardUrl;
        ApiUrlDataContainer _questionUrl;

        public void GetLeaderboard(int pageCount)
        {
        }

        public void GetQuestions()
        {
        }

        T GetApiCall<T>(ApiUrlDataContainer urlDataContainer, int index)
        {
            var url = urlDataContainer.GetUrlByIndex(index);
            if (string.IsNullOrEmpty(url))
            {
                Debug.Log("url is empty");
            }
            else
            {
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

                {
                }
            }

            return default;
        }
    }
}