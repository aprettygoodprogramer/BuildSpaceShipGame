using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerScript : MonoBehaviour
{
    public PlacingScript placingScript;
    public GameObject Hallway;
    public GameObject Thrustor;
    public GameObject Armory; 
    public void setHallway()
    {
    placingScript.SetPrefab(Hallway);


        }
    public void setThrustor()
    {
        placingScript.SetPrefab(Thrustor);
    }
    public void setArmory()
    {
        placingScript.SetPrefab(Armory);
    }
}
