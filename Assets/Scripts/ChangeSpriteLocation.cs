using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeSpriteLocation : MonoBehaviour
{
    // Variables to hold input actions
    private InputAction interactAction;
    private InputAction quitAction;
    
    // Min and Max values
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;
    
    // Other Variables
    private Transform spriteTransformer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("interact");
        quitAction = InputSystem.actions.FindAction("quit");
        spriteTransformer = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            spriteTransformer.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
        if (quitAction.WasPressedThisFrame())
        { 
            Application.Quit();
        }
    }
}
