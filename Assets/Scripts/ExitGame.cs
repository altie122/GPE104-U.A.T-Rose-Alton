using UnityEngine;
using UnityEngine.InputSystem;

public class ExitGame : MonoBehaviour
{
    // Variables to hold input actions
    private InputAction quitAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        quitAction = InputSystem.actions.FindAction("quit");
    }

    // Update is called once per frame
    private void Update()
    {
        if (quitAction.WasPressedThisFrame())
        { 
            Application.Quit();
        }
    }
}
