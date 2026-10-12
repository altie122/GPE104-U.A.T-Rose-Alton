using UnityEngine;

public class StarShipPawn : Pawn
{
    
    // Min and max teleport values
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    
    // Movement speeds
    public float normalSpeed = 5f;
    public float turboSpeed = 10f;
    public float normalRotateSpeed = 360f;
    public float turboRotateSpeed = 720f;
    public float worldSpaceSpeed = 1f;
    
    // Shooting
    private Shooter shooter;
    
    public override void Start()
    {
        shooter = GetComponent<Shooter>();
        minX = GameManager.instance.worldBoundaryMinX;
        maxX = GameManager.instance.worldBoundaryMaxX;
        minY = GameManager.instance.worldBoundaryMinY;
        maxY = GameManager.instance.worldBoundaryMaxY;
        GameManager.instance.playerGameObject = gameObject;
    }

    public override void Update()
    {
        if (!GameManager.instance.playerGameObject)
        {
            GameManager.instance.playerGameObject = gameObject;
        }
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

    public override void Move(Vector3 moveVector)
    {
        throw new System.NotImplementedException();
    }

    public override void Shoot()
    {
        if (shooter)
        {
            shooter.Shoot();
        }
    }
}
