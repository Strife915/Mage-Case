using System;

namespace MageCase.Uis
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