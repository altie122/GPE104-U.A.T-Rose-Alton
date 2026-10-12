using System;
using UnityEngine;

public class SideWarping : MonoBehaviour
{
    public Transform parentTransform;

    // Mins and maxes are gotten from the GameManager
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    // On start runs just after Awake so GameManager is practically guaranteed to exist by this point.
    private void Start()
    {
        // If the game manager doesn't exist, set mins and maxes to 0
        if (GameManager.instance == null)
        {
            minX = 0;
            minY = 0;
            maxX = 0;
            minY = 0;
        }
        // If the game manager exists, set mins and maxes to the values from it
        minX = GameManager.instance.worldBoundaryMinX;
        maxX = GameManager.instance.worldBoundaryMaxX;
        minY = GameManager.instance.worldBoundaryMinY;
        maxY = GameManager.instance.worldBoundaryMaxY;
    }

    private void Update()
    {
        // if mins and maxes are the default value (0) and game manager exists, attempt to set mins and maxes again
        if ((minX == 0 && minY == 0 && maxX == 0 && maxY == 0)&& GameManager.instance)
        {
            minX = GameManager.instance.worldBoundaryMinX;
            maxX = GameManager.instance.worldBoundaryMaxX;
            minY = GameManager.instance.worldBoundaryMinY;
            maxY = GameManager.instance.worldBoundaryMaxY;
        }
        // return early if parent transform doesn't exist
        if (!parentTransform)
        {
            return;
        }
        // Teleports
        // Left
        if (parentTransform.localPosition.x < minX)
        {
            parentTransform.localPosition = new Vector3(maxX, parentTransform.localPosition.y, parentTransform.localPosition.z);
        }
        // Right
        else if (parentTransform.localPosition.x > maxX)
        {
            parentTransform.localPosition = new Vector3(minX, parentTransform.localPosition.y, parentTransform.localPosition.z);
        }
        
        // Down
        if (parentTransform.localPosition.y < minY)
        {
            parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, maxY, parentTransform.localPosition.z);
        }
        // Up
        else if (parentTransform.localPosition.y > maxY)
        {
            parentTransform.localPosition = new Vector3(parentTransform.localPosition.x, minY, parentTransform.localPosition.z);
        }
    }
}
