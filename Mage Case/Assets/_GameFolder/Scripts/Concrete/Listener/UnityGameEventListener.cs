using Magecase.Abstracts.GameEventListeners;
using UnityEngine;
using UnityEngine.Events;

namespace Magecase.ScriptableObjects.GameEventListeners
{
    public class UnityGameEventListener : BaseGameEventListener
    {
        [SerializeField] UnityEvent _untiyEvent;
        [SerializeField] UnityEvent<object> _untiyEventObject;

        public override void Notify()
        {
            _untiyEvent?.Invoke();
        }

        public override void Notify(object value)
        {
            _untiyEventObject?.Invoke(value);
        }
    }
}