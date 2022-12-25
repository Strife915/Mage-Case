using Magecase.ScriptableObjects.GameEventListeners;
using UnityEngine;

namespace Magecase.Uis
{
    public class Leaderboard : MonoBehaviour
    {
        NormalGameEventListener _normalGameEventListener;
        CanvasGroup _canvasGroup;

        void Awake()
        {
            GetReference();
        }

        void OnValidate()
        {
            GetReference();
        }

        void GetReference()
        {
            if (_canvasGroup == null || _normalGameEventListener == null)
            {
                _canvasGroup = GetComponent<CanvasGroup>();
                _normalGameEventListener = GetComponent<NormalGameEventListener>();
            }
        }
    }
}