using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public float gridSize = 1.0f;          // Define the size of each grid cell
    public GameObject prefab;              // Reference to the prefab to be instantiated
    public Transform parentTransform;      // Reference to the parent GameObject's Transform
    private HashSet<Vector2> occupiedCells; // Set to track occupied grid cells
    private List<GameObject> blocks;       // List to track all instantiated blocks
    private int currCostLothonium = 0;
    private int currCostRawMaterials = 0;
    private int currCostFuel = 0;
    private int currCostAdvancedParts = 0;
    private int currCostMilkyWayDollar = 0;
    public CurrencyHandler currencyHandler;
    public GameObject arrowPrefab;         // Reference to the arrow prefab
    private GameObject arrowInstance;      // Instance of the arrow
    private int currentRotation = 0;       // Current rotation in degrees (0, 90, 180, 270)
    public BlastOffScript blastoffscript;
    private bool shouldRotate;
    private bool ArmoryIs = false;
    public ShopManagerScript SMscript;
    public bool WeaponIs = false;
    public BuildingSystemAmtHandler BsAh;
    private void Start()
    {
        occupiedCells = new HashSet<Vector2>();
        blocks = new List<GameObject>();
        PlaceInitialBuilding();

        // Instantiate and initialize the arrow
        if (arrowPrefab != null)
        {
            arrowInstance = Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);
            arrowInstance.SetActive(false); // Hide the arrow initially
        }
    }

    private void Update()
    {
        HandleMouseInput();
        if (!blastoffscript.getIsflying() && shouldRotate)
        {
            HandleRotationInput();
            UpdateArrowPosition();
        }
    }

    // Place the initial building in the middle of the grid
    private void PlaceInitialBuilding()
    {
        Vector2 centerPosition = SnapToGrid(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height / 2))); // Center of the screen
        if (prefab != null)
        {
            GameObject initialBlock = Instantiate(prefab, centerPosition, Quaternion.Euler(0, 0, currentRotation), parentTransform);
            initialBlock.transform.localScale = Vector3.one * gridSize; // Set the scale of the initial block
            occupiedCells.Add(centerPosition);
            blocks.Add(initialBlock);
            prefab = null;
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
                if (currencyHandler.getCurrency(0) > currCostLothonium && currencyHandler.getCurrency(1) > currCostRawMaterials && currencyHandler.getCurrency(2) > currCostFuel && currencyHandler.getCurrency(3) > currCostAdvancedParts && currencyHandler.getCurrency(4) > currCostMilkyWayDollar)
                {
                    if (ArmoryIs)
                    {
                        SMscript.changeGetArmory();
                    }
                    if (WeaponIs && !SMscript.getArmory())
                    {
                        currencyHandler.subtractCurrency(0, currCostLothonium);
                        currencyHandler.subtractCurrency(1, currCostRawMaterials);
                        currencyHandler.subtractCurrency(2, currCostFuel);
                        currencyHandler.subtractCurrency(3, currCostAdvancedParts);
                        currencyHandler.subtractCurrency(4, currCostMilkyWayDollar);

                        GameObject newBlock = Instantiate(prefab, gridPosition, Quaternion.Euler(0, 0, currentRotation), parentTransform);
                        newBlock.transform.localScale = Vector3.one * gridSize; // Set the scale of the new block
                        occupiedCells.Add(gridPosition);
                        blocks.Add(newBlock);
                        BsAh.addAmt();
                    }
                    else if (!WeaponIs)
                    {
                        currencyHandler.subtractCurrency(0, currCostLothonium);
                        currencyHandler.subtractCurrency(1, currCostRawMaterials);
                        currencyHandler.subtractCurrency(2, currCostFuel);
                        currencyHandler.subtractCurrency(3, currCostAdvancedParts);
                        currencyHandler.subtractCurrency(4, currCostMilkyWayDollar);

                        GameObject newBlock = Instantiate(prefab, gridPosition, Quaternion.Euler(0, 0, currentRotation), parentTransform);
                        newBlock.transform.localScale = Vector3.one * gridSize; // Set the scale of the new block
                        occupiedCells.Add(gridPosition);
                        blocks.Add(newBlock);
                        BsAh.addAmt();
                    }
                    else if (WeaponIs && SMscript.getArmory())
                    {
                        currencyHandler.noArmory();
                    }
                }
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

    private void HandleRotationInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentRotation = (currentRotation + 90) % 360;
            arrowInstance.transform.rotation = Quaternion.Euler(0, 0, currentRotation);
        }
    }

    private void UpdateArrowPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 gridPosition = SnapToGrid(mousePosition);
        arrowInstance.transform.position = gridPosition;
        arrowInstance.SetActive(true);
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
    public void SetPrefab(GameObject PrefabSetter, int prefabCostLothonium, int prefabCostRawMaterials, int prefabCostFuel, int prefabCostAdvancedParts, int prefabCostMilkyWayDollars, bool ShouldRotate, bool IsArmory, bool isWeapon)
    {
        shouldRotate = ShouldRotate;
        prefab = PrefabSetter;
        currCostLothonium = prefabCostLothonium;
        currCostRawMaterials = prefabCostRawMaterials;
        currCostFuel = prefabCostFuel;
        currCostAdvancedParts = prefabCostAdvancedParts;
        currCostMilkyWayDollar = prefabCostMilkyWayDollars;
        ArmoryIs = IsArmory;
        WeaponIs = isWeapon;
    }
}
