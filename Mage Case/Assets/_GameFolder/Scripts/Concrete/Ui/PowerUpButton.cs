using MageCase.Abstract.Uis;

namespace MageCase.Uis
{
    public class PowerUpButton : ButtonWithGameEvent
    {
        protected override void HandleOnButtonClicked()
        {
            base.HandleOnButtonClicked();
            _button.interactable = false;
        }
    }

    public interface IPowerupAbility
    {
        void PowerUp();
    }

    public interface IPowerAbilityWithEvent : IPowerupAbility
    {
        public event System.Action PowerUpAction;
    }
}