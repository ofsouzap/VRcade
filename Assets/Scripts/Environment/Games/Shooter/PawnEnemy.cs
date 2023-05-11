using System.Collections;
using UnityEngine;
using Audio;

namespace Environment.Games.Shooter
{
    public class PawnEnemy : ShooterEnemy
    {

        [SerializeField] protected AudioClip damageClip;

        protected override int GetMaxHealth() => 5;

        protected override IEnumerator PreDeathCoroutine()
        {
            yield break;
        }

        protected override void OnDamageTaken()
        {
            SfxController.PlaySFX(damageClip);
        }

    }
}