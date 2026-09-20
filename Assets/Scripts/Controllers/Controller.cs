using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    // Pawn for the Controller to control
    public Pawn controlledPawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();
    
    
    public abstract void OnDisable();

    public abstract void MakeDecisions();
}
