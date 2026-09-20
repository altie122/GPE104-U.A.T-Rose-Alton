using UnityEngine;

public class StarShipPawn : Pawn
{
    
    // Min and max teleport values
    public float minX = -1f;
    public float maxX = 1f;
    public float minY = -1f;
    public float maxY = 1f;
    
    // Movement speeds
    public float normalSpeed = 5f;
    public float turboSpeed = 10f;
    public float normalRotateSpeed = 360f;
    public float turboRotateSpeed = 720f;
    public float worldSpaceSpeed = 1f;
    
    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void Teleport()
    {
        // Change sprite's location to be a random point between the min and max values for both X and Y (Z stays at 0)
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    public override void MoveForwardLocal()
    {
        transform.position += transform.up * (normalSpeed * Time.deltaTime);
    }

    public override void MoveBackwardLocal()
    {
        transform.position -= transform.up * (normalSpeed * Time.deltaTime);
    }

    public override void RotateClockwise()
    {
        transform.Rotate(0, 0, normalRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClockwise()
    {
        transform.Rotate(0, 0, normalRotateSpeed * Time.deltaTime);
    }

    public override void MoveForwardLocalTurbo()
    {
        transform.position += transform.up * (turboSpeed * Time.deltaTime);
    }

    public override void MoveBackwardLocalTurbo()
    {
        transform.position -= transform.up * (turboSpeed * Time.deltaTime);
    }

    public override void RotateClockwiseTurbo()
    {
        transform.Rotate(0, 0, turboRotateSpeed * -Time.deltaTime);
    }

    public override void RotateCounterClockwiseTurbo()
    {
        transform.Rotate(0, 0, turboRotateSpeed * Time.deltaTime);
    }

    public override void MoveForwardWorld()
    {
        transform.position += Vector3.up * worldSpaceSpeed;
    }

    public override void MoveBackwardWorld()
    {
        transform.position -= Vector3.up * worldSpaceSpeed;
    }

    public override void MoveLeftWorld()
    {
        transform.position -= Vector3.right * worldSpaceSpeed;
    }

    public override void MoveRightWorld()
    {
        transform.position += Vector3.right * worldSpaceSpeed;
    }
}
