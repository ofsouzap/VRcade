using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Games.PushBall
{
    [RequireComponent(typeof(Collider))]
    public class PushBallBackWallTriggerController : MonoBehaviour
    {

        public UnityEvent BallExited = new();

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponentInChildren<PushBallBallController>() != null)
                BallExited.Invoke();
        }

    }
}