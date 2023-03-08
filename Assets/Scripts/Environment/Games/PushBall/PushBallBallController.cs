using System.Collections;
using UnityEngine;

namespace Environment.Games.PushBall
{
    public class PushBallBallController : MonoBehaviour
    {

        [SerializeField] protected PushBallGameController gameController;

        private SpringJoint spring;
        private float springAmount;

        private void Start()
        {

            if (gameController == null)
                Debug.LogWarning("Game controller not set");

            spring = GetComponent<SpringJoint>();
            springAmount = spring.spring;

        }

        public void OnGrabbed()
        {
            gameController.BallGrabbed();
            DisableSpringJoint();
        }

        public void OnReleased()
        {
            gameController.BallGrabbed();
        }

        public void EnableSpringJoint()
        {
            spring.spring = springAmount;
        }

        public void DisableSpringJoint()
        {
            spring.spring = 0;
        }

    }
}