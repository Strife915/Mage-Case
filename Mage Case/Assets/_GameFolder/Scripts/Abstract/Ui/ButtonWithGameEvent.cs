using MageCase.ScriptableObjects;
using UnityEngine;

namespace MageCase.Abstract.Uis
{
    public abstract class ButtonWithGameEvent : BaseButton
    {
        [SerializeField] protected GameEvent _gameEvent;

        protected override void HandleOnButtonClicked()
        {
            _gameEvent.InvokeEvents();
        }
    }
}