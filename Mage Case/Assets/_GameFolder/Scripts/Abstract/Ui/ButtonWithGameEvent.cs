using Magecase.Abstract.Uis;
using Magecase.ScriptableObjects;
using UnityEngine;

namespace Magecase.Uis
{
    public abstract class ButtonWithGameEvent : BaseButton
    {
        [SerializeField] GameEvent _gameEvent;

        protected override void HandleOnButtonClicked()
        {
            _gameEvent.InvokeEvents();
        }
    }
}