using UnityEngine;

namespace Environment.Games.Shooter
{
    public class EntityStatus
    {

        public EntityStatus(int maxHealth)
        {

            if (maxHealth <= 0)
                Debug.LogError("Max health was not positive");

            this.maxHealth = maxHealth;
            health = maxHealth;

        }

        private int maxHealth;

        private int health;
        public void SetHealth(int amount) => health = Mathf.Clamp(amount, 0, maxHealth);
        public void AddHealth(int amount) => health = Mathf.Clamp(health + amount, 0, maxHealth);
        public void LoseHealth(int amount) => health = Mathf.Clamp(health - amount, 0, maxHealth);

        public bool IsDead => health <= 0;

    }
}
