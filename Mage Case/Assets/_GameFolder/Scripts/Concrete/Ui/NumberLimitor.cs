using Magecase.Abstract.Behaviours;
using UnityEngine;

namespace Magecase.Uis
{
    public class NumberLimitor : INumberLimitor
    {
        public void LimitValue(int value, int maxLimit)
        {
            value = Mathf.Clamp(value, 0, maxLimit);
        }
    }
}