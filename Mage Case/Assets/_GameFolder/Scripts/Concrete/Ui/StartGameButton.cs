using MageCase.Abstract.Uis;
using UnityEngine;

namespace MageCase.Uis
{
    public class StartGameButton : ButtonWithGameEvent
    {
        [SerializeField] CanvasGroup _canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            _canvasGroup = GetComponentInParent<CanvasGroup>();
        }
    }
}