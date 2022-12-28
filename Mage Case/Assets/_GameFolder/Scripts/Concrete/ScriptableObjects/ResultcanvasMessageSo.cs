﻿using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/Message/Result Canvas Message", fileName = "Resultcanva sMessage")]
    public class ResultcanvasMessageSo : ScriptableObject
    {
        [SerializeField] string _canvasSuccessMessage;
        [SerializeField] string _canvasFailMessage;

        public string CanvasSuccessMessage => _canvasSuccessMessage;
        public string CanvasFailMessage => _canvasFailMessage;
    }
}