using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    
    public bool isPaused = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
