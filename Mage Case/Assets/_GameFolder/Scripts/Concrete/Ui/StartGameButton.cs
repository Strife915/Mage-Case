using System;
using UnityEngine;

namespace Magecase.Uis
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