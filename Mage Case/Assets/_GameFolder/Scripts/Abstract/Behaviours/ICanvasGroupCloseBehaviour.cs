using UnityEngine;

namespace MageCase.Abstract.Ui.Behaviours
{
    public interface ICanvasGroupCloseBehaviour
    {
        CanvasGroup CanvasGroup { get; }
        void Close();
    }
}