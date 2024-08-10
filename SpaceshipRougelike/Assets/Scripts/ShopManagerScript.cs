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
    public GameObject Battery;
    public bool needsArmory = true;
    public BuildingSystemAmtHandler BsAh;
    public HullStrengthScript HSS;
    public AudioSource audioSource;
    public BlastOffScript BOS;
    public GameObject Pg1;
    public GameObject Pg2;
    public int currentShopIndex = 0;
    public void setHallway()
    {
        placingScript.SetPrefab(Hallway, 0, 5, 0, 0, 7, false, false, false);
        HSS.ChangeMuchHull(9);
    }

    
    public void setThrustor()
    {
        placingScript.SetPrefab(Thrustor, 0, 2, 3, 0, 5, true, false, false);
        BsAh.setCurrAdd(2);
        HSS.ChangeMuchHull(3);
    }
    public void setArmory()
    {
        placingScript.SetPrefab(Armory, 0, 3, 0, 1, 8, false, true, false);
        BsAh.setCurrAdd(0);
        HSS.ChangeMuchHull(9);
            }
    public void setSheildGenerator()
    {
        placingScript.SetPrefab(SheildGeneratpr, 2, 2, 1, 5, 10, false, false, false);
        BsAh.setCurrAdd(1);
        HSS.ChangeMuchHull(6);
            }
    public void setBasicGun()
    {
        placingScript.SetPrefab(basicGun, 3, 3, 1, 1, 3, true, false, true);
        BsAh.setCurrAdd(3);
        HSS.ChangeMuchHull(3);
            }
    public void setBattery()
    {
        placingScript.SetPrefab(Battery, 1, 2, 3, 1, 2, false, false, false);
        BsAh.setCurrAdd(4);
        HSS.ChangeMuchHull(1);
    }
    public bool getArmory()
    {
        return needsArmory;
    }
    public void changeGetArmory()
    {
        needsArmory = false;
    }
    void Update()
    {
        if (BOS.getIsflying() == false)
        {
            if (currentShopIndex == 0)
            {
                Pg1.SetActive(true);
                Pg2.SetActive(false);
            }
            else if (currentShopIndex == 1)
            {
                Pg2.SetActive(true);
                Pg1.SetActive(false);
            }
        }
    }
    public void IncreaseShopIndex()
    {
        currentShopIndex += 1;
        audioSource.Play();
    }
    public void DecreaseShopIndex()
    {
        if (currentShopIndex > -1)
        {
            currentShopIndex -= 1;
            audioSource.Play();
        }

    }
}
