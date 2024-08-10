using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystemAmtHandler : MonoBehaviour
{
    private int amtArmory;
    private int amtSheildGen;
    private int amtThrustor;
    private int amtBasicGun;
    private int amtBattery;
    private int currAdd;
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
    }

}
