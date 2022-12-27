using System;
using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/ApiUrlDataContainer", fileName = "Api Url Data Container")]
    public class ApiUrlDataContainer : ScriptableObject
    {
        [SerializeField] string[] _apiUrl;

        public string GetUrlByIndex(int index)
        {
            try
            {
                var result = _apiUrl[index];
                return result;
            }
            catch
            {
                Debug.Log($"cant find api url this index number {index}");
                return string.Empty;
            }
        }
    }
}