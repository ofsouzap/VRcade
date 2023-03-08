using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Environment.Games
{
    /// <summary>
    /// Reset the position, rotation, velocity and angular velocity of a game object when the player passes their hand through a trigger zone
    /// </summary>
    public class BallHandTriggerResetter : GameHandTriggerResetter
    {

        [SerializeField] protected GameObject ball;

        [Tooltip("Whether to use the ball's starting position to reset it instead of the position defined below")]
        [SerializeField] protected bool useStartingPositionAsReset;

        [Tooltip("Initial *local* position of the ball")]
        [SerializeField] protected Vector3 _resetPosition;

        [Tooltip("Initial *local* rotation of the ball")]
        [SerializeField] protected Vector3 _resetRotation;

        [Tooltip("Initial velocity of the ball")]
        [SerializeField] protected Vector3 _resetVelocity;

        [Tooltip("Initial angular velocity of the ball")]
        [SerializeField] protected Vector3 _resetAngularVelocity;

        protected Vector3 ballStartPos;

        protected Rigidbody ballRigidbody;

        protected Vector3 GetBallResetPos() => useStartingPositionAsReset ? ballStartPos : _resetPosition;
        protected Vector3 GetBallResetRot() => _resetRotation;
        protected Vector3 GetBallResetVelocity() => _resetVelocity;
        protected Vector3 GetBallResetAngularVelocity() => _resetAngularVelocity;

        public UnityEvent ResetTriggered = new();

        protected override void Start()
        {

            base.Start();

            ballStartPos = ball.transform.localPosition;

            if (!ball.TryGetComponent(out ballRigidbody))
            {
                Debug.LogError("Ball game object has no rigidbody");
            }

        }

        protected override void ResetGame()
        {

            ResetTriggered.Invoke();

            ball.transform.localPosition = GetBallResetPos();
            ball.transform.localRotation = Quaternion.Euler(_resetRotation);

            ballRigidbody.velocity = GetBallResetVelocity();
            ballRigidbody.angularVelocity = GetBallResetAngularVelocity();

        }

    }
}