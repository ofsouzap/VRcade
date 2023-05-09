using System.Collections.Generic;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public abstract class ShooterEntity : MonoBehaviour, IShootable
    {

        protected abstract int GetMaxHealth();

        protected EntityStatus status;
        protected bool IsDead => status.IsDead;

        protected virtual void Start()
        {

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

        public void Shoot(Vector3 origin, Vector3 direction, int damage)
        {

            TakeDamage(damage);

        }
    }
}