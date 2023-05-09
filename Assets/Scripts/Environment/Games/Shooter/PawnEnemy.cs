using System.Collections;
using UnityEngine;
using Audio;

namespace Environment.Games.Shooter
{
    public class PawnEnemy : ShooterEnemy
    {

        [SerializeField] protected AudioClip damageClip;

        protected override int GetMaxHealth() => 5;

        protected override void Die()
        {
            Debug.Log("Enemy died");  // TODO - do something proper eventually
        }

        protected override void OnDamageTaken()
        {
            SFXController.FindSceneController(gameObject.scene).PlaySFX(damageClip); // TODO - store SFXController instead of fetching each time
        }

    }
}