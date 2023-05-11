using Environment.Games.Shooter;
using System.Collections;
using UnityEngine;

namespace PlayerControl.Gloves
{
    public class SimpleLaserGunGlove : Glove
    {

        [SerializeField] protected DamageLaserProjector laser;

        [Tooltip("The transform at the position where the ray should start. The ray will shoot in the direction of the transform's positive-z axis")]
        [SerializeField] protected Transform rayStartTransform;
        private Vector3 RayStart => rayStartTransform.position;
        private Vector3 RayDir => rayStartTransform.forward;

        [SerializeField] protected float maxShootDistance = 100;

        [SerializeField] [Min(1)] protected int damageDone;

        [SerializeField] protected float shootDelay = 0;
        private float lastShoot;

        [SerializeField] [Min(0)] protected float laserRenderLifetime;

        protected override void Start()
        {

            base.Start();

            if (laser == null)
            {
                Debug.LogError("No laser projector set");
            }

            lastShoot = 0;

        }

        public override void UsePrimaryStarted()
        {

            base.UsePrimaryStarted();

            if (Time.time - lastShoot >= shootDelay)
            {
                lastShoot = Time.time;
                laser.Shoot(RayStart, RayDir);
            }

        }

    }
}