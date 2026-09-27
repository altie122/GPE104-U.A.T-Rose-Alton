using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damageAmount;

    public bool isInstaKill;
    
    private Health otherHealthComponent;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        otherHealthComponent = collider.GetComponent<Health>();
        // if the other object does not have a health component, return before running damage commands
        if (otherHealthComponent == null)
        {
            return;
        }

        // if instaKill, make the other object take damage equal to their max health, else deal the amount of damage provided in damageAmount
        otherHealthComponent.TakeDamage(isInstaKill ? otherHealthComponent.maxHealth : damageAmount);
        
        // destroy the current game object if the other component has health
        Destroy(gameObject);
    }
}
