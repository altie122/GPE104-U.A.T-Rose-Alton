using UnityEngine;

public class PlayerLivesHandler : MonoBehaviour
{
    public Health healthComponent;
    public Death deathComponent;
    
    void Update()
    {
        if (GameManager.instance && healthComponent && deathComponent)
        {
            if (healthComponent.currentHealth <= 0)
            {
                // Debug.Log("Player Lives Handler: - 1 life");
                healthComponent.currentHealth = healthComponent.maxHealth;
                GameManager.instance.playerLiveCount--;
            }

            if (GameManager.instance.playerLiveCount <= 0)
            {
                // Debug.Log("Player Lives Handler: Death");
                deathComponent.Die();
            }
        }
    }
}
