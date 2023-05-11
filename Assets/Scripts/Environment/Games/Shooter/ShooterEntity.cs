using Audio;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public abstract class ShooterEntity : MonoBehaviour, IShootable
    {

        protected ShooterGameController GameController => ShooterGameController.Singleton;
        protected SFXController SfxController { get; private set; }

        protected abstract int GetMaxHealth();

        protected EntityStatus status;
        protected bool IsDead => status.IsDead;

        protected virtual void Awake()
        {
        }

        protected virtual void Start()
        {

            SfxController = SFXController.FindSceneController(gameObject.scene);

            status = new(GetMaxHealth());

        }

        protected virtual void Update()
        {
        }

        protected abstract void OnDamageTaken();

        protected abstract void Die();

        private void TakeDamage(int amount)
        {

            OnDamageTaken();

            status.LoseHealth(amount);

            if (IsDead)
            {
                Die();
            }

        }

        public void GetShot(Vector3 origin, Vector3 direction, int damage)
        {

            if (!IsDead)
                TakeDamage(damage);

        }
    }
}