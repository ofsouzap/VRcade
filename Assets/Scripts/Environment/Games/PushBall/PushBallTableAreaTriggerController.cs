using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Games.PushBall
{
    [RequireComponent(typeof(Collider))]
    public class PushBallTableAreaTriggerController : MonoBehaviour
    {

        public UnityEvent BallExitedArea = new();

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInChildren<PushBallBallController>() != null)
            {
                BallExitedArea.Invoke();
            }
        }

    }
}