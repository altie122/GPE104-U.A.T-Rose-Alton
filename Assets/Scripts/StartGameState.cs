using UnityEngine;

public class StartGameState : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.ResetGameState();
    }
}
