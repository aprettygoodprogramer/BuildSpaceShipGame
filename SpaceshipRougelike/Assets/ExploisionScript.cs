using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 0.23f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
