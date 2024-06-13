using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public float gridSize = 1.0f;          // Define the size of each grid cell
    public GameObject prefab;              // Reference to the prefab to be instantiated
    private HashSet<Vector2> occupiedCells; // Set to track occupied grid cells
    private List<GameObject> blocks;       // List to track all instantiated blocks

    private void Start()
    {
        occupiedCells = new HashSet<Vector2>();
        blocks = new List<GameObject>();
        PlaceInitialBuilding();
    }

    private void Update()
    {
        HandleMouseInput();
    }

    // Place the initial building in the middle of the grid
    private void PlaceInitialBuilding()
    {
        Vector2 centerPosition = SnapToGrid(Vector2.zero); // Center of the screen
        if (prefab != null)
        {
            GameObject initialBlock = Instantiate(prefab, centerPosition, Quaternion.identity);
            occupiedCells.Add(centerPosition);
            blocks.Add(initialBlock);
        }
    }

    // Handle mouse input for placing and deleting blocks
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && prefab != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gridPosition = SnapToGrid(mousePosition);

            // Check if the grid position is already occupied
            if (!occupiedCells.Contains(gridPosition) && IsPositionAdjacent(gridPosition))
            {
                GameObject newBlock = Instantiate(prefab, gridPosition, Quaternion.identity);
                occupiedCells.Add(gridPosition);
                blocks.Add(newBlock);
            }
        }
        else if (Input.GetMouseButtonDown(1)) // Right-click to delete
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gridPosition = SnapToGrid(mousePosition);

            // Check if the grid position is occupied and on the "outside"
            if (occupiedCells.Contains(gridPosition) && IsBlockOnOutside(gridPosition))
            {
                GameObject blockToRemove = blocks.Find(block => (Vector2)block.transform.position == gridPosition);
                if (blockToRemove != null && CanRemoveBlock(gridPosition))
                {
                    blocks.Remove(blockToRemove);
                    occupiedCells.Remove(gridPosition);
                    Destroy(blockToRemove);
                }
            }
        }
    }

    // Snap a given position to the nearest grid point
    private Vector2 SnapToGrid(Vector2 originalPosition)
    {
        float x = Mathf.Round(originalPosition.x / gridSize) * gridSize;
        float y = Mathf.Round(originalPosition.y / gridSize) * gridSize;
        return new Vector2(x, y);
    }

    // Check if the given position is adjacent to any existing block
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

    // Check if the block at the given position is on the "outside"
    private bool IsBlockOnOutside(Vector2 position)
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
            if (!occupiedCells.Contains(position + offset))
            {
                return true;
            }
        }

        return false;
    }

    // Check if removing a block will disconnect the structure
    private bool CanRemoveBlock(Vector2 position)
    {
        HashSet<Vector2> visited = new HashSet<Vector2>();
        Queue<Vector2> queue = new Queue<Vector2>();

        // Find a starting point different from the block to be removed
        Vector2 start = Vector2.zero;
        foreach (Vector2 cell in occupiedCells)
        {
            if (cell != position)
            {
                start = cell;
                break;
            }
        }

        // BFS to check connectivity
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            Vector2 current = queue.Dequeue();
            visited.Add(current);

            Vector2[] adjacentOffsets = new Vector2[]
            {
                new Vector2(gridSize, 0),
                new Vector2(-gridSize, 0),
                new Vector2(0, gridSize),
                new Vector2(0, -gridSize)
            };

            foreach (Vector2 offset in adjacentOffsets)
            {
                Vector2 neighbor = current + offset;
                if (occupiedCells.Contains(neighbor) && neighbor != position && !visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                }
            }
        }

        // If the number of visited nodes is equal to the number of occupied cells minus the block to be removed
        return visited.Count == occupiedCells.Count - 1;
    }

    // Method to set the prefab
    public void SetPrefab(GameObject PrefabSetter)
    {
        prefab = PrefabSetter;
    }
}
