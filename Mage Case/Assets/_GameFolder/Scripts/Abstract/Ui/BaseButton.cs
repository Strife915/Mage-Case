using UnityEngine;
using UnityEngine.UI;

namespace MageCase.Abstract.Uis
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected virtual void Awake()
        {
            GetReference();
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(HandleOnButtonClicked);
        }

        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(HandleOnButtonClicked);
        }

        protected abstract void HandleOnButtonClicked();

        protected virtual void OnValidate()
        {
            GetReference();
        }

        protected virtual void GetReference()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
        }
    }
}