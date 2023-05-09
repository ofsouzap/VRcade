using System.Collections;
using UnityEngine;

namespace PlayerControl.Gloves
{
    public class Glove : MonoBehaviour
    {

        [SerializeField] protected bool canGrab = true;
        public bool CanGrab => canGrab;

        protected virtual void Start() { }
        protected virtual void Update() { }

        public Collider[] GetColliders()
        {
            return GetComponentsInChildren<Collider>();
        }

        public virtual void UsePrimaryStarted() { }
        public virtual void UsePrimaryCancelled() { }
        public virtual void UseSecondaryStarted() { }
        public virtual void UseSecondaryCancelled() { }

    }
}