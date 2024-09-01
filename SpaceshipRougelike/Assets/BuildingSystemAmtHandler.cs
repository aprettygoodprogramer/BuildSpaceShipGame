using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildingSystemAmtHandler : MonoBehaviour
{
    private int amtArmory;
    private int amtSheildGen;
    private int amtThrustor = 0;
    private int amtBasicGun;
    private int amtBattery;
    private int currAdd;
    private int amtStunGun;
    private int amtGenerator;
    private int amtMachineGun;
    private int amtLazerGun;
    private int amtPowerSynth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getAmount(int whatKind)
    {
        if (whatKind == 0)
        {
            return amtBasicGun;
        }
        if (whatKind == 1)
        {
            return amtBattery;
        }
        if (whatKind == 2)
        {
            return amtSheildGen;
        }
        if (whatKind == 3)
        {
            return amtStunGun;
        }
        if (whatKind == 4)
        {
            return amtGenerator;
        }
        if (whatKind == 5)
        {
            return amtMachineGun;
        }
        if (whatKind == 6)
        {
            return amtThrustor;
        }
        if (whatKind == 7)
        {
            return amtLazerGun;
        }
        if (whatKind == 8)
        {
            return amtPowerSynth;
        }

        return 0;
    }
    public void setCurrAdd(int whatType)
    {
        currAdd = whatType;
    }
    public void addAmt()
    {
        if (currAdd == 0)
        {
            amtArmory++;
        }
        if (currAdd == 1)
        {
            amtSheildGen++;
        }
        if (currAdd == 2)
        {
            amtThrustor++;
        }
        if (currAdd == 3)
        {
            amtBasicGun++;
        }
        if (currAdd == 4)
        {
            amtBattery++;
        }
        if (currAdd == 5)
        {
            amtStunGun++;   
        }
        if (currAdd == 6)
        {
            amtGenerator++;
        }
        if (currAdd == 7)
        {
            amtMachineGun++;
        }
        if (currAdd == 8)
        {
            amtLazerGun++;
        }
        if (currAdd == 9)
        {
            amtPowerSynth++;
        }
    }

}
