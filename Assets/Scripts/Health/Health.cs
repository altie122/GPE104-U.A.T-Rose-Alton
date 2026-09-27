using UnityEngine;

public class Health : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;

    private Death deathComponent;

    private void Start()
    {
        deathComponent = GetComponent<Death>();
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0 && deathComponent != null)
        {
            deathComponent.Die();
        }
    }
}
