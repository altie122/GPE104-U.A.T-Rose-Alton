using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireForce = 25f;
    public float lifetime = 10f;
    
    private Rigidbody2D rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        if (rigidBody)
        {
            rigidBody.AddForce(transform.up * fireForce);
        }
        
        Destroy(gameObject, lifetime);
    }
}
