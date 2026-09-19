using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeSpriteLocation : MonoBehaviour
{
    // Variables to hold input actions
    private InputAction interactAction;
    
    // Min and Max values
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        interactAction = InputSystem.actions.FindAction("interact");
    }

    // Update is called once per frame
    private void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {
            // Change sprite's location to be a random point between the min and max values for both X and Y (Z stays at 0)
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }
    }
}
