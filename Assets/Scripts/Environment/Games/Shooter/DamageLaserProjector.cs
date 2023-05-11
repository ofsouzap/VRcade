using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    /// <summary>
    /// A component for laser guns and the like that project lasers rendered with a LineRenderer andd also cause a constant amount of damage to IShootable's that they hit
    /// </summary>
    [RequireComponent(typeof(LineRenderer))]
    public class DamageLaserProjector : MonoBehaviour
    {

        protected LineRenderer LineRenderer => GetComponent<LineRenderer>();

        [SerializeField] protected float laserRenderLifetime;

        [SerializeField] protected float maxDistance;
        [SerializeField][Min(0)] protected int damageInflicted;

        public void Shoot(Vector3 origin, Vector3 direction)
        {

            bool hitFound = Physics.Raycast(
                origin: origin,
                direction: direction,
                maxDistance: maxDistance,
                hitInfo: out RaycastHit hit);

            // Perform shooting hit code

            if (hitFound)
            {

                IShootable shootable = hit.collider.gameObject.GetComponentInParent<IShootable>();

                shootable?.GetShot(origin, direction, damageInflicted);

            }

            // Render laser

            Vector3 lineEnd = hitFound ? hit.point : origin + (maxDistance * direction);

            StartLaserRenderCoroutine(origin, lineEnd);

        }

        public void ShootFromTo(Vector3 from, Vector3 to) => Shoot(from, to - from);

        private Coroutine laserRenderCoroutine;

        private void StartLaserRenderCoroutine(Vector3 lineStart, Vector3 lineEnd)
        {

            if (laserRenderCoroutine != null)
            {
                StopCoroutine(laserRenderCoroutine);
            }

            laserRenderCoroutine = StartCoroutine(LaserRenderCoroutine(lineStart, lineEnd));

        }

        private IEnumerator LaserRenderCoroutine(Vector3 lineStart, Vector3 lineEnd)
        {

            LineRenderer.enabled = true;
            LineRenderer.SetPositions(new Vector3[] { lineStart, lineEnd });

            yield return new WaitForSeconds(laserRenderLifetime);

            LineRenderer.enabled = false;

        }

    }
}