using UnityEngine;

public class UFOPawn : Pawn
{
    
    private float moveSpeed = 1f;
    public float maxSpeed = 2f;
    public float minSpeed = 0.2f;
    
    public override void Start()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
    }

    public override void Update()
    {
    }

    public override void Teleport()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveForwardLocal()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveBackwardLocal()
    {
        throw new System.NotImplementedException();
    }

    public override void RotateClockwise()
    {
        throw new System.NotImplementedException();
    }

    public override void RotateCounterClockwise()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveForwardLocalTurbo()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveBackwardLocalTurbo()
    {
        throw new System.NotImplementedException();
    }

    public override void RotateClockwiseTurbo()
    {
        throw new System.NotImplementedException();
    }

    public override void RotateCounterClockwiseTurbo()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveForwardWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveBackwardWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveLeftWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void MoveRightWorld()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(Vector3 moveVector)
    {
        transform.position += moveVector * (moveSpeed * Time.deltaTime);
    }

    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }
}

