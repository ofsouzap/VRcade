using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Audio
{
    /// <summary>
    /// An instance of this should be in every scene using sound effects and it is used to quickly play a sound effect once.
    /// </summary>
    public class SFXController : MonoBehaviour
    {

        [SerializeField] protected GameObject sfxPlayerPrefab;

        private void Start()
        {
            if (sfxPlayerPrefab == null)
            {
                Debug.LogError("No SFX player prefab set for SFX controller");
            }
            else if (sfxPlayerPrefab.GetComponent<SFXPlayer>() == null)
            {
                Debug.LogError("SFX player prefab has no SFXPlayer component");
            }
        }

        public static SFXController FindSceneController(Scene scene)
        {

            var controllers = FindObjectsOfType<SFXController>()
                .Where(x => x.gameObject.scene == scene)
                .ToList();

            if (controllers.Count == 0 )
            {
                Debug.LogWarning("Can't find any SFX controllers in scene");
                return null;
            }
            else if (controllers.Count > 1)
            {
                Debug.LogWarning("Multiple SFX controllers found in scene");
                return null;
            }
            else
            {
                return controllers[0];
            }

        }
        
        public void PlaySFX(AudioClip clip, float volume = 1)
        {

            GameObject player = Instantiate(sfxPlayerPrefab, transform);
            player.GetComponent<SFXPlayer>().PlayClip(clip, volume);

        }

    }
}