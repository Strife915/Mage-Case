using DG.Tweening;
using MageCase.Abstract.Attributes;
using MageCase.Abstract.Ui.Behaviours;
using MageCase.Scriptableobjects;
using UnityEngine;

namespace MageCase.Ui.Behaviours
{
    public class ShakeBehaviour : IShakeBehaviour
    {
        Transform _transformToShake;
        public IShakeAttributes ShakeAttributes { get; private set; }

        public ShakeBehaviour(Transform transformToShake, ShakeAttributesSo shakeAttributesSo)
        {
            _transformToShake = transformToShake;
            ShakeAttributes = shakeAttributesSo;
        }


        public void Shake()
        {
            _transformToShake.DOShakePosition(ShakeAttributes.Duration, Vector3.up * ShakeAttributes.DistanceMultiplier, ShakeAttributes.Vibrato);
        }
    }
}