using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Environment.Games.PushBall
{
    public class PushBallScoreboardController : MonoBehaviour
    {

        [SerializeField] protected PushBallGameController gameController;
        [SerializeField] protected TMP_Text text;

        private string GenerateScoreDisplayText()
        {
            return $@"Score {gameController.CurrentScore}
High Score: {gameController.HighScore}";
        }

        private void Start()
        {

            if (gameController == null)
                Debug.LogWarning("Scoreboard controller game controller not set");

            if (text == null)
                Debug.LogWarning("Scoreboard controller TMP text not set");

        }

        private void Update()
        {

            text.text = GenerateScoreDisplayText();

        }

    }
}