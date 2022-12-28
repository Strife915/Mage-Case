using System.Collections.Generic;
using Magecase.Abstracts.GameEventListeners;
using UnityEngine;

namespace Magecase.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Mage Case/Events/Game Event")]
    public class GameEvent : ScriptableObject
    {
        HashSet<BaseGameEventListener> _gameEventListeners;

        void OnEnable()
        {
            _gameEventListeners = new HashSet<BaseGameEventListener>();
        }

        void OnDisable()
        {
            _gameEventListeners = null;
        }

        public void AddEvent(BaseGameEventListener unityGameEventListener)
        {
            _gameEventListeners.Add(unityGameEventListener);
        }

        public void RemoveEvent(BaseGameEventListener unityGameEventListener)
        {
            if (!_gameEventListeners.Contains(unityGameEventListener)) return;

            _gameEventListeners.Remove(unityGameEventListener);
        }

        public void InvokeEvents()
        {
            foreach (BaseGameEventListener gameEventListener in _gameEventListeners)
            {
                gameEventListener.Notify();
            }
        }

        public void InvokeEventsWithObject(object value)
        {
            foreach (BaseGameEventListener gameEventListener in _gameEventListeners)
            {
                gameEventListener.Notify(value);
                gameEventListener.Notify();
            }
        }
    }
}