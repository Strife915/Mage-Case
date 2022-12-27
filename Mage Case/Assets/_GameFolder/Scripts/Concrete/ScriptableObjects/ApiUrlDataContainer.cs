using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/ApiUrlDataContainer", fileName = "Api Url Data Container")]
    public class ApiUrlDataContainer : ScriptableObject
    {
        [SerializeField] string[] _apiUrl;
    }
}