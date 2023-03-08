using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using PlayerControl;

namespace Environment
{
    [RequireComponent(typeof(Collider))]
    public class HandTriggerZone : MonoBehaviour
    {

        public UnityEvent<TrackingHandController> OnHandEnter;
        public UnityEvent<TrackingHandController> OnHandExit;

        private void OnTriggerEnter(Collider other)
        {

            TrackingHandController otherHand = other.GetComponentInParent<TrackingHandController>();
            
            if (otherHand != null)
            {
                OnHandEnter.Invoke(otherHand);
            }

        }

        private void OnTriggerExit(Collider other)
        {

            TrackingHandController otherHand = other.GetComponentInParent<TrackingHandController>();

            if (otherHand != null)
            {
                OnHandExit.Invoke(otherHand);
            }

        }

    }
}