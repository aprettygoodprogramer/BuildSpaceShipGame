using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerScript : MonoBehaviour
{
    public PlacingScript placingScript;
    public GameObject Hallway;
    public GameObject Thrustor;
    public void setHallway()
    {
    placingScript.SetPrefab(Hallway, true, true, true, true);


        }
    public void setThrustor()
    {
        placingScript.SetPrefab(Thrustor, true, true, true, true);
    }
}
