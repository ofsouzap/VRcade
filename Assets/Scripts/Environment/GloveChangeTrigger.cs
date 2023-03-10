using System.Collections;
using UnityEngine;
using PlayerControl;

namespace Environment
{
    public class GloveChangeTrigger : MonoBehaviour
    {

        [SerializeField] protected HandTriggerZone handTriggerZone;

        [Tooltip("The glove to allow the player to change to")]
        [SerializeField] protected GameObject glovePrefab;

        [Tooltip("The transform to be the parent of the sample glove displayed. If none, won't display a sample")]
        [SerializeField] protected Transform sampleDisplayParent;

        private const float repeatDelay = 1.0f;
        private float lastChange;

        private void Start()
        {

            lastChange = 0;

            if (glovePrefab == null)
                Debug.LogWarning("Glove prefab not set");
            else
            {

                // Display the glove sample

                if (sampleDisplayParent != null)
                {
                    CreateSampleGlove();
                }

                // Set up trigger zone listening

                if (handTriggerZone == null)
                {
                    Debug.LogWarning("Hand trigger zone hasn't been set");
                }
                else
                {
                    handTriggerZone.OnHandEnter.AddListener((HandController hand) => SetHandGlove(hand));
                }

            }

        }

        private void CreateSampleGlove()
        {

            GameObject sample = Instantiate(glovePrefab, sampleDisplayParent);

            Glove sampleGlove = sample.GetComponent<Glove>();

            if (sampleGlove == null)
            {
                Debug.LogWarning("Glove prefab doesn't have glove component");
            }
            else
            {

                // Disable glove colliders

                foreach (Collider c in sampleGlove.GetColliders())
                    c.enabled = false;

            }

        }

        private void SetHandGlove(HandController hand)
        {

            if (Time.time - lastChange > repeatDelay)
            {

                hand.ReplaceGlove(glovePrefab);

                lastChange = Time.time;

            }

        }

    }
}