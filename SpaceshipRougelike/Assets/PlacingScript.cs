using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : MonoBehaviour
{
    public GameObject TestObject;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Instantiate(TestObject, mouseWorldPos, Quaternion.identity);
        }

    }
}
