using Magecase.Abstract.Uis;
using Magecase.ScriptableObjects;
using UnityEngine;

namespace Magecase.Uis
{
    public class ButtonWithGameEvent : BaseButton
    {
        [SerializeField] GameEvent _gameEvent;

        protected override void HandleOnButtonClicked()
        {
            _gameEvent.InvokeEvents();
        }
    }
}