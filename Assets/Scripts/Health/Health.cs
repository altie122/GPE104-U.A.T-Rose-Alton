using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float currentHealth = 100;
    public float maxHealth = 100;

    private Death deathComponent;

    public Image healthBar;
    
    public AudioSource audioSource;
    public AudioMixerGroup audioMixerGroup;
    public AudioClip takeDamageSound;

    private void Start()
    {
        deathComponent = GetComponent<Death>();

        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (audioSource)
        {
            if (audioMixerGroup)
            {
                audioSource.outputAudioMixerGroup = audioMixerGroup;
            }
            
            audioSource.PlayOneShot(takeDamageSound);
        }
        
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }

        if (currentHealth <= 0 && deathComponent != null)
        {
            deathComponent.Die();
        }
    }
}