using UnityEngine;
using UnityEngine.Audio;

public class Bullet : MonoBehaviour
{
    public float fireForce = 25f;
    public float lifetime = 10f;
    
    private Rigidbody2D rigidBody;
    
    public AudioClip shootSfx;
    [SerializeField]
    private AudioMixerGroup shootMixerGroup;

    private void Start()
    {
        
        PlayShootSound();
        
        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody)
        {
            rigidBody.AddForce(transform.up * fireForce);
        }
        
        Destroy(gameObject, lifetime);
    }
    
    // Similar to how "PlayClipAtPoint" works
    private void PlayShootSound()
    {
        GameObject soundObject = new GameObject("Bullet Shoot SFX");
        soundObject.transform.position = transform.position;

        AudioSource source = soundObject.AddComponent<AudioSource>();

        source.playOnAwake = false;
        source.clip = shootSfx;
        source.outputAudioMixerGroup = shootMixerGroup;
        source.spatialBlend = 1f;

        source.Play();

        Destroy(soundObject, shootSfx.length);
    }
}
