using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/ApiUrlDataContainer", fileName = "Api Url Data Container")]
    public class ApiUrlDataContainerSo : ScriptableObject
    {
        [SerializeField] string[] _apiUrl;
        public int PageLength => _apiUrl.Length;

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