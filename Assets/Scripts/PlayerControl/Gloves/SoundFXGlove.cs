using System.Collections;
using UnityEngine;
using Audio;

namespace PlayerControl.Gloves
{
    public class SoundFXGlove : Glove
    {

        [SerializeField] protected AudioClip clip;

        public override void UsePrimaryStarted()
        {
            base.UsePrimaryStarted();
            SFXController.FindSceneController(gameObject.scene).PlaySFX(clip);
        }

    }
}