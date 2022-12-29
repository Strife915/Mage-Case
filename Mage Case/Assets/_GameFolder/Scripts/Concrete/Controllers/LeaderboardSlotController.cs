using Magecase.DataEntities;
using UnityEngine;
using TMPro;

namespace Magecase.Uis
{
    public class LeaderboardSlotController : MonoBehaviour
    {
        [SerializeField] TMP_Text _rankText;
        [SerializeField] TMP_Text _nickText;
        [SerializeField] TMP_Text _scoreText;

        public void BindEntities(LeaderBoardPlayerEntityData entity)
        {
            _rankText.text = entity.Rank.ToString();
            _nickText.text = entity.NickName;
            _scoreText.text = entity.Score.ToString();
        }
    }
}