using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyHandler : MonoBehaviour
{
    int LothoniumAmt = 1000;
    int RawMaterialsAmt = 1000;
    int FuleAmt = 1000;
    int AdvancedPartsAmt = 1000;
    int MilkyWayDollarsAmt = 1000;

    public TMP_Text LothoniumTxt;
    public TMP_Text RawMaterialsTxt;
    public TMP_Text FuleTxt;
    public TMP_Text AdvancedPartsTxt;
    public TMP_Text MilkyWayDollarsTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LothoniumTxt.text = "Lothonium: " + LothoniumAmt.ToString();
        RawMaterialsTxt.text = "Raw Materials: " + RawMaterialsAmt.ToString();
        FuleTxt.text = "Fule: " + FuleAmt.ToString();
        AdvancedPartsTxt.text = "Advanced Parts: " + AdvancedPartsAmt.ToString();
        MilkyWayDollarsTxt.text = "Milky Way Dollars: " + MilkyWayDollarsAmt.ToString();
    }

    public int getCurrency(int whatKind)
    {
        if (whatKind == 0)
        {
            return LothoniumAmt;
        }
        if (whatKind == 1)
        {
            return RawMaterialsAmt;
        }
        if (whatKind == 2)
        {
            return FuleAmt;
        }
        if (whatKind == 3)
        {
            return AdvancedPartsAmt;
        }
        if (whatKind == 4)
        {
            return MilkyWayDollarsAmt;
        }
        else
        {
            return 0;
        }
    }
    public void subtractCurrency(int whatKind, int howMuch)
    {
        if (whatKind == 0)
        {
           LothoniumAmt-=howMuch; 
        }
        if (whatKind == 1)
        {
            RawMaterialsAmt-=howMuch;
        }
        if (whatKind == 2)
        {
            FuleAmt-=howMuch;
        }
        if (whatKind == 3)
        {
            AdvancedPartsAmt-=howMuch;
        }
        if (whatKind == 4)
        {
           MilkyWayDollarsAmt-=howMuch;
        }
    }

}
