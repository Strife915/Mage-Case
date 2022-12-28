using Magecase.Abstract.Ui.Behaviours;
using Magecase.Uis.Behaviours;
using UnityEngine;

namespace Magecase.Abstract.Uis
{
    public abstract class BaseCanvasGroup : MonoBehaviour
    {
        ICanvasGroupOpenBehaviour _canvasGroupOpenBehaviour;
        ICanvasGroupCloseBehaviour _canvasGroupCloseBehaviour;

        public virtual void Awake()
        {
            var canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroupOpenBehaviour = new CanvasGroupOpenBehaviour(canvasGroup);
            _canvasGroupCloseBehaviour = new CanvasGroupCloseBehaviour(canvasGroup);
        }

        public void OpenCanvas()
        {
            _canvasGroupOpenBehaviour.Open();
        }

        public void CloseCanvas()
        {
            _canvasGroupCloseBehaviour.Close();
        }
    }
}