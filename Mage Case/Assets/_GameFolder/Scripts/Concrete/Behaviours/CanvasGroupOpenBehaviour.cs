using MageCase.Abstract.Ui.Behaviours;
using UnityEngine;

namespace MageCase.Ui.Behaviours
{
    public class CanvasGroupOpenBehaviour : ICanvasGroupOpenBehaviour
    {
        public CanvasGroup CanvasGroup { get; }

        public CanvasGroupOpenBehaviour(CanvasGroup canvasGroup)
        {
            CanvasGroup = canvasGroup;
        }

        public void Open()
        {
            CanvasGroup.alpha = 1;
            CanvasGroup.interactable = true;
            CanvasGroup.blocksRaycasts = true;
        }
    }
}