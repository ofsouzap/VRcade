using System.Collections;
using UnityEngine;

namespace Environment.Games.PushBall
{
    public class PushBallGameController : MonoBehaviour
    {

        private int currentScore;
        public int CurrentScore => currentScore;

        private int highScore;
        public int HighScore => highScore;

        private void Start()
        {

            currentScore = 0;
            highScore = currentScore;

        }

        private void ResetScore()
        {
            currentScore = 0;
        }

        public void BallGrabbed()
        {
            ResetScore();
        }

        public void BallLeftArea()
        {
            ResetScore();
        }

        public void BallRespawned()
        {
            ResetScore();
        }
        
        public void IncrementScore()
        {

            currentScore++;

            if (CurrentScore > highScore)
                highScore = currentScore;

        }

    }
}