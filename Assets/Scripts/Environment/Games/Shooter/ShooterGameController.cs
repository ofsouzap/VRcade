using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public class ShooterGameController : MonoBehaviour
    {

        public static ShooterGameController Singleton { get; private set; }

        public ShooterPlayer Player => ShooterPlayer.Singleton;

        private void Awake()
        {

            if (Singleton == null)
                Singleton = this;
            else
            {
                Debug.LogWarning("Trying to create a ShooterGameController when there is already a singleton");
                Destroy(gameObject);
            }

        }

        private void Start()
        {

            StartGame();

        }

        private void StartGame()
        {

            // TODO - start waves

        }
        
    }
}