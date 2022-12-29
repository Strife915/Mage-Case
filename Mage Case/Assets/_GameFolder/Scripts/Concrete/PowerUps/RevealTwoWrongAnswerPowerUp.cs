using System.Linq;
using DG.DemiEditor;

namespace Magecase.Uis
{
    public class RevealTwoWrongAnswerPowerUp : IPowerupAbility
    {
        AnswerButton[] _answerButtons;
        AnswerButton[] _wrongAnswers;

        public RevealTwoWrongAnswerPowerUp(AnswerButton[] answerButtons)
        {
            _answerButtons = answerButtons;
        }


        public void PowerUp()
        {
            _wrongAnswers = _answerButtons.Where(x => x.IsCorrectAnswer == false).ToArray();
            _wrongAnswers.Shuffle();
            _wrongAnswers[0].RevealOnPowerUp();
            _wrongAnswers[1].RevealOnPowerUp();
        }
    }
}