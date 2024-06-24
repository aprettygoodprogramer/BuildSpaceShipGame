using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerScript : MonoBehaviour
{

    //1 Lothonium, 2 ramaterials, 3 fule, 4 adv parts, 5 MilkyWay Dollar

    public PlacingScript placingScript;
    public GameObject Hallway;
    public GameObject Thrustor;
    public GameObject Armory;
    public GameObject SheildGeneratpr;
    public void setHallway()
    {
    placingScript.SetPrefab(Hallway, 0, 5,0,0,7);


        }
    public void setThrustor()
    {
        placingScript.SetPrefab(Thrustor, 0, 2, 3, 0, 5);
    }
    public void setArmory()
    {
        placingScript.SetPrefab(Armory, 0, 3, 0, 1, 8);
    }
    public void setSheildGenerator()
    {
        placingScript.SetPrefab(SheildGeneratpr, 2, 2, 1, 5, 10);
    }
}
