﻿using System.Collections;
using UnityEngine;

namespace PlayerControl
{
    public class HandController : MonoBehaviour
    {

        [SerializeField] protected bool negativeGloveScaleX;

        private Glove currGlove;

        private Collider[] currGloveColliders;

        private void Start()
        {

            // Try find initial glove and use it

            Glove[] gloves = GetComponentsInChildren<Glove>();

            if (gloves.Length == 0)
                Debug.LogError("No default glove could be found in hand. Hand must have a initial glove.");
            else if (gloves.Length > 1)
                Debug.LogError("Multiple default gloves found in hand. Hand must only have one initial glove.");
            else
            {
                SetCurrGlove(gloves[0]);
            }

        }

        private void SetCurrGlove(Glove glove)
        {

            currGlove = glove;
            currGloveColliders = glove.GetColliders();

            // Flip glove X if needed

            if (negativeGloveScaleX == (currGlove.transform.localScale.x > 0))
                currGlove.transform.localScale = new(
                    -currGlove.transform.localScale.x,
                     currGlove.transform.localScale.y,
                     currGlove.transform.localScale.z
                    );

        }

        public void ReplaceGlove(GameObject prefab)
        {

            // Destroy current glove

            Destroy(currGlove.gameObject);

            // Create new glove (and make sure it has a Glove component)

            GameObject newGloveGO = Instantiate(prefab, transform);
            Glove newGlove = newGloveGO.GetComponent<Glove>();

            if (newGlove != null)
            {

                SetCurrGlove(newGlove);

            }
            else
            {

                Debug.LogError("Glove prefab provided doesn't have Glove component");
                Destroy(newGloveGO);

            }

        }

        private Coroutine setCollidersStateCoroutine = null;

        private void SetCollidersState(bool state)
        {

            if (setCollidersStateCoroutine != null)
            {
                StopCoroutine(setCollidersStateCoroutine);
                setCollidersStateCoroutine = null;
            }

            foreach (Collider collider in currGloveColliders)
                collider.enabled = state;

        }

        private void SetCollidersStateDelayed(bool state, float delay)
        {

            if (setCollidersStateCoroutine != null)
            {
                StopCoroutine(setCollidersStateCoroutine);
                setCollidersStateCoroutine = null;
            }

            setCollidersStateCoroutine = StartCoroutine(SetCollidersStateDelay(state, delay));

        }

        private IEnumerator SetCollidersStateDelay(bool state, float delay)
        {
            yield return new WaitForSeconds(delay);
            SetCollidersState(state);
        }

        public void DisableCollidersDelayed(float delay) => SetCollidersStateDelayed(false, delay);
        public void EnableCollidersDelayed(float delay) => SetCollidersStateDelayed(true, delay);

    }
}