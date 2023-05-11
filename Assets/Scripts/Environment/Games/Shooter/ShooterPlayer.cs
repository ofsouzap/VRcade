using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public class ShooterPlayer : ShooterEntity
    {

        [SerializeField] protected Transform headTransform;
        public Transform GetHeadTransform() => headTransform;

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