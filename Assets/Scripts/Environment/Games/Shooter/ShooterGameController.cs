using System.Collections;
using UnityEngine;

namespace Environment.Games.Shooter
{
    public class ShooterGameController : MonoBehaviour
    {

        [SerializeField] [Min(1)] protected int playerMaxHealth;

        private EntityStatus playerStatus;

        private void Start()
        {

            StartGame();

        }

        private void StartGame()
        {

            playerStatus = new EntityStatus(maxHealth: playerMaxHealth);

            // TODO - start waves

        }
        
    }
}