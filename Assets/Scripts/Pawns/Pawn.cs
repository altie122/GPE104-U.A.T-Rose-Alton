using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();

    // Teleport
    public abstract void Teleport();

    // Local movement (normal)
    public abstract void MoveForwardLocal();
    
    public abstract void MoveBackwardLocal();
    
    public abstract void RotateClockwise();
    
    public abstract void RotateCounterClockwise();

    // Local movement (turbo)
    public abstract void MoveForwardLocalTurbo();
    
    public abstract void MoveBackwardLocalTurbo();
    
    public abstract void RotateClockwiseTurbo();
    
    public abstract void RotateCounterClockwiseTurbo();

    // World-space movement
    public abstract void MoveForwardWorld();
    
    public abstract void MoveBackwardWorld();
    
    public abstract void MoveLeftWorld();
    
    public abstract void MoveRightWorld();
}

