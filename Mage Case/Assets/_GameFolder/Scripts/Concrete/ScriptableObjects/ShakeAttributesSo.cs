using MageCase.Abstract.Attributes;
using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/Attributes/Answer Button Shake Att", fileName = "Shake Attributes So")]
    public class ShakeAttributesSo : ScriptableObject, IShakeAttributes
    {
        [SerializeField] float _duration;
        [SerializeField] int _vibrato;
        [SerializeField] float _distanceMultiplier;

        public int Vibrato => _vibrato;
        public float Duration => _duration;
        public float DistanceMultiplier => _distanceMultiplier;
    }
}