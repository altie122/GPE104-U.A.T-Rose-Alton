using UnityEngine;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemoveOnDeath;
    
    public override void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Update()
    {
    }

    public override void Die()
    {
        if (GameManager.instance != null && GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null)
        {
            GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
        }
        Destroy(gameObject);
    }
}
