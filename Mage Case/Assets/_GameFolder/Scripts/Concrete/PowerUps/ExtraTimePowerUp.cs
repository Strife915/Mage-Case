using System;

namespace Magecase.Uis
{
    public class ExtraTimePowerUp : IPowerAbilityWithEvent
    {
        public void PowerUp()
        {
            PowerUpAction?.Invoke();
        }

        public event Action PowerUpAction;
    }
}