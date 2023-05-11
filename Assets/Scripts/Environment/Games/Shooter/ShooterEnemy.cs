using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public abstract class ShooterEnemy : ShooterEntity
    {

        private bool doingDeathCoroutine;

        protected override void Start()
        {

            base.Start();

            doingDeathCoroutine = false;

        }

        protected abstract IEnumerator PreDeathCoroutine();

        protected sealed override void Die()
        {
            if (!doingDeathCoroutine)
                StartCoroutine(DeathCoroutine());
        }

        private IEnumerator DeathCoroutine()
        {

            doingDeathCoroutine = true;

            yield return PreDeathCoroutine();

            Destroy(gameObject);

        }

    }
}