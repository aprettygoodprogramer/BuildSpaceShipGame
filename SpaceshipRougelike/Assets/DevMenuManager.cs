using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevMenuManager : MonoBehaviour
{
    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
}
