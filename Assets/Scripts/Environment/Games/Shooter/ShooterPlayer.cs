using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public class ShooterPlayer : ShooterEntity
    {

        [SerializeField] protected Transform headTransform;
        public Transform GetHeadTransform() => headTransform;

        [SerializeField] protected CharacterController characterController;

        [SerializeField] protected int _maxHealth;
        protected override int GetMaxHealth() => _maxHealth;

        public static ShooterPlayer Singleton { get; private set; }

        protected override void Awake()
        {

            if (Singleton == null)
                Singleton = this;
            else
            {
                Debug.LogWarning("Trying to create a ShooterPlayer when there is already a singleton");
                Destroy(gameObject);
            }

            base.Awake();

        }

        protected override void Start()
        {

            base.Start();

            if (characterController == null)
            {

                if (!TryGetComponent(out characterController))
                {
                    Debug.LogWarning("No character controller set");
                }

            }

        }

        /// <summary>
        /// Get the position on the player that the enemies should be aiming to shoot at
        /// </summary>
        public Vector3 GetShootTargetPosition()
        {

            Vector3 characterControllerCenter = characterController.center + characterController.transform.position;

            return (characterControllerCenter + GetHeadTransform().position) / 2; // Takes halfway between headset and center of body

        }

        protected override void Die()
        {

            // TODO - let game controller handle it

        }

        protected override void OnDamageTaken()
        {

            // TODO - damage SFX, maybe VFX, update potential health bar, etc. etc.

        }

    }
}