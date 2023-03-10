using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{
    [RequireComponent(typeof(Rigidbody))]
    public class TrackingHand : MonoBehaviour
    {

        protected Rigidbody Rb => GetComponent<Rigidbody>();

        [SerializeField] protected Transform target;
        protected Vector3 TargetDisplacement => target.position - transform.position;

        [SerializeField] private float _moveSpeed = 1f;

        protected float MoveSpeed => _moveSpeed;

        private void Start()
        {

            Rb.useGravity = false;
            Rb.isKinematic = false;

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

    }
}
