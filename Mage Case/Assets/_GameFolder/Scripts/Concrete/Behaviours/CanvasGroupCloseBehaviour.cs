using Magecase.Abstract.Ui.Behaviours;
using UnityEngine;

namespace Magecase.Uis.Behaviours
{
    public class CanvasGroupCloseBehaviour : ICanvasGroupCloseBehaviour
    {
        public CanvasGroup CanvasGroup { get; }

        public CanvasGroupCloseBehaviour(CanvasGroup canvasGroup)
        {
            CanvasGroup = canvasGroup;
        }

        public void Close()
        {
            CanvasGroup.alpha = 0;
            CanvasGroup.interactable = false;
            CanvasGroup.blocksRaycasts = false;
        }
    }
}