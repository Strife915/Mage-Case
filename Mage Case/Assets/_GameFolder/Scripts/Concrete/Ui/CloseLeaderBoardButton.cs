using UnityEngine;

namespace Magecase.Uis
{
    public class CloseLeaderBoardButton : ButtonWithGameEvent
    {
        protected override void HandleOnButtonClicked()
        {
            base.HandleOnButtonClicked();
            Debug.Log("clicked");
        }
    }
}