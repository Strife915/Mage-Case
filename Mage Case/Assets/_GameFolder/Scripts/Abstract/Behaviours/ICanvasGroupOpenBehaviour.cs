using UnityEngine;

namespace MageCase.Abstract.Ui.Behaviours
{
    public interface ICanvasGroupOpenBehaviour
    {
        CanvasGroup CanvasGroup { get; }
        void Open();
    }
}