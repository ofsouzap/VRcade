using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    [RequireComponent(typeof(Rigidbody))]
    public class TrackingHandController : MonoBehaviour
    {

        protected Rigidbody Rb => GetComponent<Rigidbody>();

        [SerializeField] protected Transform target;
        protected Vector3 TargetDisplacement => target.position - transform.position;

        [SerializeField] private float _moveSpeed = 1f;

        protected float MoveSpeed => _moveSpeed;

        protected Collider[] colliders;

        private void Start()
        {

            Rb.useGravity = false;
            Rb.isKinematic = false;

            colliders = GetComponentsInChildren<Collider>();

        }

        private void FixedUpdate()
        {

            Rb.velocity = TargetDisplacement * MoveSpeed / Time.fixedDeltaTime;

            transform.rotation = target.rotation;

            // Below code doesn't seem to work but would be nice to have it work sometime
            //Quaternion rotationDiff = target.rotation * Quaternion.Inverse(transform.rotation);
            //rotationDiff.ToAngleAxis(out float rotAngle, out Vector3 rotAxis);
            //Vector3 rotDiffVec3 = rotAngle * rotAxis;
            //Rb.angularVelocity = Mathf.Deg2Rad * rotDiffVec3 / Time.fixedDeltaTime;

        }

        private Coroutine setCollidersStateCoroutine = null;

        private void SetCollidersState(bool state)
        {

            if (setCollidersStateCoroutine != null)
            {
                StopCoroutine(setCollidersStateCoroutine);
                setCollidersStateCoroutine = null;
            }

            foreach (Collider collider in colliders)
                collider.enabled = state;

        }

        private void SetCollidersStateDelayed(bool state, float delay)
        {

            if (setCollidersStateCoroutine != null)
            {
                StopCoroutine(setCollidersStateCoroutine);
                setCollidersStateCoroutine = null;
            }

            setCollidersStateCoroutine = StartCoroutine(SetCollidersStateDelay(state, delay));

        }

        private IEnumerator SetCollidersStateDelay(bool state, float delay)
        {
            yield return new WaitForSeconds(delay);
            SetCollidersState(state);
        }

        public void DisableCollidersDelayed(float delay) => SetCollidersStateDelayed(false, delay);
        public void EnableCollidersDelayed(float delay) => SetCollidersStateDelayed(true, delay);

    }
}
