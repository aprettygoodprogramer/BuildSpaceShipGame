using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystemScript : MonoBehaviour
{
    public float gridSize = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 currentPosition = transform.position;

        Vector3 snappedPosition = new Vector3(
            Mathf.Round(currentPosition.x / gridSize) * gridSize,
            Mathf.Round(currentPosition.y / gridSize) * gridSize,
            currentPosition.z
        );

        
        transform.position = snappedPosition;
    }
}

