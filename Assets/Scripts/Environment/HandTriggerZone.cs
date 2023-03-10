using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using PlayerControl;

namespace Environment
{
    [RequireComponent(typeof(Collider))]
    public class HandTriggerZone : MonoBehaviour
    {

        public UnityEvent<HandController> OnHandEnter;
        public UnityEvent<HandController> OnHandExit;

        private void OnTriggerEnter(Collider other)
        {

            HandController otherHand = other.GetComponentInParent<HandController>();
            
            if (otherHand != null)
            {
                OnHandEnter.Invoke(otherHand);
            }

        }

        private void OnTriggerExit(Collider other)
        {

            HandController otherHand = other.GetComponentInParent<HandController>();

            if (otherHand != null)
            {
                OnHandExit.Invoke(otherHand);
            }

        }

    }
}