using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public class BasicLaserEnemy : ShooterEnemy
    {

        [SerializeField] protected int _maxHealth;

        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float turnSpeed;
        [SerializeField] protected float targetPlayerRadius;

        [SerializeField] protected Transform nozzleOriginTransform;

        [SerializeField][Min(0)] protected int shootDamage;
        [SerializeField][Min(0)] protected float shootDelay;
        [Tooltip("Maximum angle, in degrees, that this can shoot at the player at")]
        [SerializeField][Min(0)] protected float shootMaxAngle;
        [SerializeField] protected float maxShootDistance = 100;

        [Header("Laser Line")]
        [SerializeField] protected LineRenderer lineRenderer;
        [SerializeField] protected float laserRenderLifetime;

        [Header("SFX")]
        [SerializeField] protected AudioClip damageAudioClip;
        [SerializeField] protected AudioClip deathAudioClip;

        protected override int GetMaxHealth() => _maxHealth;

        protected float lastShootTime;

        protected override void Start()
        {

            base.Start();

            lastShootTime = 0;

        }

        protected override void Update()
        {

            base.Update();

            MovementUpdate();

            ShootUpdate();

        }

        protected void MovementUpdate()
        {

            // Move towards player if too far away

            Vector3 s = GameController.Player.transform.position - transform.position;

            if (s.magnitude > targetPlayerRadius)
            {
                transform.position += moveSpeed * Time.deltaTime * s.normalized;
            }

            // Rotate towards player

            Quaternion targetRotation = Quaternion.LookRotation(s, Vector3.up);
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            transform.rotation = newRotation;

        }

        protected void ShootUpdate()
        {

            // Check haven't shot too recently

            if (Time.time - lastShootTime > shootDelay)
            {

                Vector3 target = GameController.Player.GetHeadTransform().position;
                Vector3 targetDisplacement = target - nozzleOriginTransform.position;

                // Check angle is correct for shooting player

                float angle = Quaternion.Angle(Quaternion.LookRotation(targetDisplacement, Vector3.up), nozzleOriginTransform.rotation);

                if (angle <= shootMaxAngle)
                {
                    Shoot(target);
                    lastShootTime = Time.time;
                }

            }

        }

        private void Shoot(Vector3 target)
        {

            // Do damaging raycast

            Vector3 dir = (target - nozzleOriginTransform.position).normalized;

            if (Physics.Raycast(
                origin: nozzleOriginTransform.position + (dir * 0.1f),
                direction: dir,
                hitInfo: out RaycastHit hit,
                maxDistance: maxShootDistance))
            {

                IShootable shootable = hit.collider.gameObject.GetComponentInParent<IShootable>();

                shootable?.GetShot(nozzleOriginTransform.position, dir, shootDamage);

            }

            // Draw line

            StartCoroutine(LaserRenderCoroutine(target));

        }

        protected IEnumerator LaserRenderCoroutine(Vector3 lineEnd)
        {

            lineRenderer.enabled = true;
            lineRenderer.SetPositions(new Vector3[] { nozzleOriginTransform.position, lineEnd });

            yield return new WaitForSeconds(laserRenderLifetime);

            lineRenderer.enabled = false;

        }

        protected override void OnDamageTaken()
        {

            if (damageAudioClip != null)
            {
                SfxController.PlaySFX(damageAudioClip);
            }

        }

        protected override IEnumerator PreDeathCoroutine()
        {

            if (deathAudioClip != null)
            {
                SfxController.PlaySFX(deathAudioClip);
            }

            yield break;

        }

    }
}