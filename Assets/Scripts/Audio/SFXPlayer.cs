using System.Collections;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SFXPlayer : MonoBehaviour
    {

        private AudioSource Source => GetComponent<AudioSource>();

        private bool playing;

        private void Awake()
        {
            Source.playOnAwake = false;
            Source.clip = null;
        }

        private void Start()
        {
            playing = false;
        }

        private IEnumerator PlayCoroutine()
        {

            Source.Play();
            yield return new WaitUntil(() => !Source.isPlaying);
            Destroy(gameObject);

        }

        public void PlayClip(AudioClip clip, float volume = 1)
        {

            if (playing)
                Debug.LogWarning("Trying to play clip on SFXPlayer already playing clip");
            else
            {

                playing = true;

                Source.clip = clip;
                Source.volume = volume;

                StartCoroutine(PlayCoroutine());

            }

        }

    }
}