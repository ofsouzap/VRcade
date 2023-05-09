using Environment.Games.Shooter;
using System.Collections;
using UnityEngine;

namespace PlayerControl.Gloves
{
    public class SimpleLaserGunGlove : Glove
    {

        [Tooltip("The transform at the position where the ray should start. The ray will shoot in the direction of the transform's positive-z axis")]
        [SerializeField] protected Transform rayStartTransform;
        private Vector3 RayStart => rayStartTransform.position;
        private Vector3 RayDir => rayStartTransform.forward;

        [SerializeField] protected LineRenderer lineRenderer;

        [SerializeField] protected float maxShootDistance = 100;

        [SerializeField] [Min(1)] protected int damageDone;

        [SerializeField] protected float shootDelay = 0;
        private float lastShoot;

        protected const float laserRenderLifetime = 0.1f;

        protected override void Start()
        {

            base.Start();

            lastShoot = 0;

        }

        public override void UsePrimaryStarted()
        {

            base.UsePrimaryStarted();

            if (Time.time - lastShoot >= shootDelay)
            {
                lastShoot = Time.time;
                Shoot();
            }

        }

        protected void Shoot()
        {

            RaycastHit hit;

            bool hitFound = Physics.Raycast(
                origin: RayStart,
                direction: RayDir,
                maxDistance: maxShootDistance,
                hitInfo: out hit);

            // Perform shooting hit code

            if (hitFound)
            {

                IShootable shootable = hit.collider.gameObject.GetComponentInParent<IShootable>();

                shootable?.Shoot(RayStart, RayDir, damageDone);

            }

            // Render laser

            Vector3 lineEnd = hitFound ? hit.point : RayStart + (maxShootDistance * RayDir);

            StartCoroutine(LaserRenderCoroutine(lineEnd));

        }

        protected IEnumerator LaserRenderCoroutine(Vector3 lineEnd)
        {

            lineRenderer.enabled = true;
            lineRenderer.SetPositions(new Vector3[] { RayStart, lineEnd });

            yield return new WaitForSeconds(laserRenderLifetime);

            lineRenderer.enabled = false;

        }

    }
}