using UnityEngine;

namespace Magecase.Abstract.Ui.Behaviours
{
    public interface ICanvasGroupCloseBehaviour
    {
        CanvasGroup CanvasGroup { get; }
        void Close();
    }
}