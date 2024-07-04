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
    public GameObject basicGun;
    public bool needsArmory = true;
    public BuildingSystemAmtHandler BsAh;
    public void setHallway()
    {
    placingScript.SetPrefab(Hallway, 0, 5,0,0,7, false, false, false);


    }
    public void setThrustor()
    {
        placingScript.SetPrefab(Thrustor, 0, 2, 3, 0, 5, true, false, false);
        BsAh.setCurrAdd(2);
    }
    public void setArmory()
    {
        placingScript.SetPrefab(Armory, 0, 3, 0, 1, 8, false, true, false);
        BsAh.setCurrAdd(0);
    }
    public void setSheildGenerator()
    {
        placingScript.SetPrefab(SheildGeneratpr, 2, 2, 1, 5, 10, false, false, false);
        BsAh.setCurrAdd(1);
    }
    public void setBasicGun()
    {
        placingScript.SetPrefab(basicGun, 3, 3, 1, 1, 3, true, false, true);
        BsAh.setCurrAdd(3);
    }
    public bool getArmory()
    {
        return needsArmory;
    }
    public void changeGetArmory()
    {
        needsArmory = false;
    }

}
