using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public GameObject TestObject;

    public float gridSize = 1.0f;          // Define the size of each grid cell
    public GameObject prefab;              // Reference to the prefab to be instantiated
    private HashSet<Vector2> occupiedCells; // Set to track occupied grid cells

    private void Start()
    {
        occupiedCells = new HashSet<Vector2>();
    }

    private void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world space
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Snap the mouse position to the nearest grid point
            Vector2 gridPosition = SnapToGrid(mousePosition);

            // Check if the grid position is adjacent to any existing blocks
            if (IsPositionAdjacent(gridPosition) || occupiedCells.Count == 0)
            {
                // Instantiate the prefab at the snapped grid position
                Instantiate(prefab, gridPosition, Quaternion.identity);

                // Add the new block's position to the set of occupied cells
                occupiedCells.Add(gridPosition);
            }
        }
    }

    // This method snaps a given position to the nearest grid point
    private Vector2 SnapToGrid(Vector2 originalPosition)
    {
        float x = Mathf.Round(originalPosition.x / gridSize) * gridSize;
        float y = Mathf.Round(originalPosition.y / gridSize) * gridSize;
        return new Vector2(x, y);
    }

    // This method checks if the given position is adjacent to any existing block
    private bool IsPositionAdjacent(Vector2 position)
    {
        Vector2[] adjacentOffsets = new Vector2[]
        {
            new Vector2(gridSize, 0),
            new Vector2(-gridSize, 0),
            new Vector2(0, gridSize),
            new Vector2(0, -gridSize)
        };

        foreach (Vector2 offset in adjacentOffsets)
        {
            if (occupiedCells.Contains(position + offset))
            {
                return true;
            }
        }

        return false;
    }

}
