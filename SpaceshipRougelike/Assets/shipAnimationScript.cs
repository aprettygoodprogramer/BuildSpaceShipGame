using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipAnimationScript : MonoBehaviour
{
    public bool shipAnimationIsActive;
    public bool ShipIsMoving=false;
    public Vector3 whereTeleport;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool GetShipIsMoving()
    {
        return ShipIsMoving;
    }
    public void ChangeShipIsMoving()
    {
        ShipIsMoving = !ShipIsMoving;
    }
    public void ChangeWhereTeleport(float x, float y)
    {
        whereTeleport.x = x;

        whereTeleport.y = y;
    }
    public Vector3 GetWhereTeleport()
    {
        return whereTeleport;
    }
}
