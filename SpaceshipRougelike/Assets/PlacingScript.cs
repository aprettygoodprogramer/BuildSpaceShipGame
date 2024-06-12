using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public float gridSize = 1.0f;          // Define the size of each grid cell
    public GameObject prefab;              // Reference to the prefab to be instantiated
    private HashSet<Vector2> occupiedCells; // Set to track occupied grid cells
    private bool IsUp;
    private bool IsDown;
    private bool IsLeft;
    private bool IsRight;
    private void Start()
    {
        occupiedCells = new HashSet<Vector2>();
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
        GameObject initialBlock = Instantiate(prefab, centerPosition, Quaternion.identity);
        occupiedCells.Add(centerPosition);
        prefab = null;
    }

    // Handle mouse input for placing blocks
    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && prefab!=null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 gridPosition = SnapToGrid(mousePosition);

            // Check if the grid position is already occupied
            if (!occupiedCells.Contains(gridPosition) && IsPositionAdjacent(gridPosition))
            {
                GameObject newBlock = Instantiate(prefab, gridPosition, Quaternion.identity);
                occupiedCells.Add(gridPosition);

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
        if (IsUp && occupiedCells.Contains(position + new Vector2(0, gridSize)))
        {
            return true;
        }
        if (IsDown && occupiedCells.Contains(position + new Vector2(0, -gridSize)))
        {
            return true;
        }
        if (IsLeft && occupiedCells.Contains(position + new Vector2(-gridSize, 0)))
        {
            return true;
        }
        if (IsRight && occupiedCells.Contains(position + new Vector2(gridSize, 0)))
        {
            return true;
        }

        return false;
    }

    public void SetPrefab(GameObject PrefabSetter, bool IsUpz, bool IsDownz, bool IsLeftz, bool IsRightz)
    {   
        prefab = PrefabSetter;
        IsUp = IsUpz;
        IsDown = IsDownz;
        IsLeft = IsLeftz;
        IsRight = IsRightz;

    }
}
