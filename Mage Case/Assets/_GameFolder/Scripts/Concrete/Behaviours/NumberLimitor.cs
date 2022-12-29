using MageCase.Abstract.Behaviours;
using UnityEngine;

namespace MageCase.Uis
{
    public class NumberLimitor : INumberLimitor
    {
        public void LimitValue(int value, int maxLimit)
        {
            value = Mathf.Clamp(value, 0, maxLimit);
        }
    }
}