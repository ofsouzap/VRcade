using System.Collections;
using UnityEngine;

namespace Environment.Games
{
    /// <summary>
    /// Abstract controller that resets a game when the player's hand passes through the associated hand trigger zone
    /// </summary>
    public abstract class GameHandTriggerResetter : MonoBehaviour
    {

        [SerializeField] private HandTriggerZone handTriggerZone;

        protected virtual void Start()
        {
            
            if (handTriggerZone == null)
            {
                Debug.LogWarning("Hand trigger zone hasn't been set");
            }
            else
            {
                handTriggerZone.OnHandEnter.AddListener((_) => ResetGame());
            }

        }

        protected abstract void ResetGame();

    }
}