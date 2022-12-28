using TMPro;
using UnityEngine;

namespace MageCase.GamePlay
{
    public class PlayerScore
    {
        TMP_Text _scoreText;
        public int Score { get; set; }

        public PlayerScore(TMP_Text scoreText)
        {
            _scoreText = scoreText;
            UpdateScoreText(Score);
        }

        public void UpdateScoreText(int value)
        {
            Score += value;
            Score = Mathf.Max(Score, 0);
            _scoreText.text = "SCORE : " + Score.ToString();
        }
    }
}