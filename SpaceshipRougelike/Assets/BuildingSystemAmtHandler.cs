using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystemAmtHandler : MonoBehaviour
{
    private int amtArmory;
    private int amtSheildGen;
    private int amtThrustor;
    private int amtBasicGun;
    private int currAdd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

}