using UnityEngine;

namespace Magecase.Abstract.Ui.Behaviours
{
    public interface ICanvasGroupOpenBehaviour
    {
        CanvasGroup CanvasGroup { get; }
        void Open();
    }
}