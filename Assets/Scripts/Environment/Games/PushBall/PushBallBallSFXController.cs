using System.Collections;
using UnityEngine;
using Audio;

namespace Environment.Games.PushBall
{
    [RequireComponent(typeof(Collider))]
    public class PushBallBallSFXController : MonoBehaviour
    {

        [SerializeField] protected AudioClip bounceClip;

        private SFXController sfxController;

        private float lastCollisionTime;
        [SerializeField] protected float minCollisionDelay = 0.01f;

        private void Start()
        {

            lastCollisionTime = 0;

            sfxController = SFXController.FindSceneController(gameObject.scene);

        }

        private void OnCollisionEnter(Collision collision)
        {

            if (Time.time - lastCollisionTime > minCollisionDelay)
            {

                float volume = (float)System.Math.Tanh(collision.impulse.magnitude / 2.0);
                print($"Impulse: {collision.impulse.magnitude}");

                sfxController.PlaySFX(bounceClip, volume);

            }

            lastCollisionTime = Time.time;

        }

    }
}