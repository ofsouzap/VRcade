using System.Collections;
using UnityEngine;

namespace PlayerControl
{
    public class Glove : MonoBehaviour
    {

        [SerializeField] protected bool canGrab = true;
        public bool CanGrab => canGrab; // TODO - make this actually mean something

        public Collider[] GetColliders()
        {
            return GetComponentsInChildren<Collider>();
        }
        
    }
}