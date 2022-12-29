using TMPro;
using UnityEngine;

namespace MageCase.GamePlay
{
    public class PlayerScore
    {
        TMP_Text[] _scoreText;
        public int Score { get; set; }

        public PlayerScore(TMP_Text[] scoreText)
        {
            _scoreText = scoreText;
            UpdateScore(Score);
            UpdateScoreText();
        }

        public void UpdateScore(int value)
        {
            Score += value;
            Score = Mathf.Max(Score, 0);
        }

        public void UpdateScoreText()
        {
            foreach (var text in _scoreText) text.text = "SCORE : " + Score.ToString();
        }

        public void ResetScore()
        {
            Score = 0;
            UpdateScoreText();
        }
    }
}