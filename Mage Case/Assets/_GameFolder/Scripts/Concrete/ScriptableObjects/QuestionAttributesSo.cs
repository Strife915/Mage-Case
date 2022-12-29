using UnityEngine;

namespace MageCase.Scriptableobjects
{
    [CreateAssetMenu(menuName = "Mage Case/Attributes/Question", fileName = "Question Attributes")]
    public class QuestionAttributesSo : ScriptableObject
    {
        [SerializeField] int _correctAnswerPoint;
        [SerializeField] int _unCorrectAnswerPoint;
        [SerializeField] int _timeLapsePoint;
        [SerializeField] float _giveAnswerTime;

        public int CorrectAnswerPoint => _correctAnswerPoint;
        public int UnCorrectAnswerPoint => _unCorrectAnswerPoint;
        public int TimeLapsePoint => _timeLapsePoint;
        public float GiveAnswerTime => _giveAnswerTime;
    }
}