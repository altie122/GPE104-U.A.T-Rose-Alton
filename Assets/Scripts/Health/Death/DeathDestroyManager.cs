using UnityEngine;

public class DeathDestroyManager : Death
{
    private Obstacle obstacleToRemoveOnDeath;

    public int scoreValue;
    
    public override void Start()
    {
        obstacleToRemoveOnDeath = GetComponent<Obstacle>();
    }

    public override void Update()
    {
    }

    public override void Die()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.obstacleList != null && obstacleToRemoveOnDeath != null)
            {
                GameManager.instance.obstacleList.Remove(obstacleToRemoveOnDeath);
            }
            
            GameManager.instance.score += scoreValue;
        }

        Destroy(gameObject);
    }
}
