using System;
using UnityEngine;

namespace Magecase.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Mage Case/Game Event/String Action", fileName = "Next Question Key")]
    public class NextQuestionDataContainer : ScriptableObject
    {
        [SerializeField] string _key;

        public string Key => _key;
        public Action<string> ActionOnNextQuestionKeyPick;

        void OnEnable()
        {
            ActionOnNextQuestionKeyPick += SetNextQuestionKey;
        }

        void SetNextQuestionKey(string context)
        {
            _key = context;
        }
    }
}