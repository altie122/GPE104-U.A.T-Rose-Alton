using System;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damageAmount;

    public bool isInstaKill;
    
    private Health otherHealthComponent;
    
    private Obstacle obstacleToRemoveOnDeath;
    
    private Damager otherDamagerComponent;

    public string team;

    private void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        otherHealthComponent = collider.GetComponent<Health>();
        otherDamagerComponent = collider.GetComponent<Damager>();
        // if the other object does not have a health component or is the same team, return before running damage commands
        if (otherHealthComponent == null || (otherDamagerComponent && otherDamagerComponent.team == team))
        {
            return;
        }

        // if instaKill, make the other object take damage equal to their max health, else deal the amount of damage provided in damageAmount
        otherHealthComponent.TakeDamage(isInstaKill ? otherHealthComponent.maxHealth : damageAmount);
        
        // destroy the current game object if the other component has Health
        if (GameManager.instance)
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null)
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
            }
        }
        Destroy(gameObject);
    }
}
