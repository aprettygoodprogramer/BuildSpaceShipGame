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
    public GameObject StunGunPrefab;
    public GameObject Generator;
    public GameObject MachineGunPrefab;
    public GameObject PowerSynth; 
    public GameObject LazerGunPrefab;
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
    public void setStunGun()
    {
        placingScript.SetPrefab(StunGunPrefab, 2, 1, 1, 4, 6, true, false, true);
        BsAh.setCurrAdd(5);
        HSS.ChangeMuchHull(2);
    }
    public void setGenerator()
    {
        placingScript.SetPrefab(Generator, 6, 4, 0, 10, 10, false, false, false);
        BsAh.setCurrAdd(6);
        HSS.ChangeMuchHull(3);
    }
    public void setMachineGun()
    {
        placingScript.SetPrefab(MachineGunPrefab, 2, 3, 4, 2, 10, true, false, true);
        BsAh.setCurrAdd(7);
        HSS.ChangeMuchHull(2);
    }
    public void setLazerGun()
    {
        placingScript.SetPrefab(LazerGunPrefab, 1, 2, 4, 5, 7, true, false, true);
        BsAh.setCurrAdd(8);
        HSS.ChangeMuchHull(1);
    }
    public void setPowerSynth()
    {
        placingScript.SetPrefab(PowerSynth, 3, 1, 0, 5, 7, false, false, false);
        BsAh.setCurrAdd(9);
        HSS.ChangeMuchHull(3);
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
            if (currentShopIndex>1)
            {
                currentShopIndex = 1;
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
        if (currentShopIndex > 0)
        {
            currentShopIndex -= 1;
            audioSource.Play();
        }

    }
}
