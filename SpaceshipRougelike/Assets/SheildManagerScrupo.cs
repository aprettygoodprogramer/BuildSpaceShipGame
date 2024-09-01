using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class SheildManagerScrupo : MonoBehaviour
{
    public BuildingSystemAmtHandler BSAH;
    public BlastOffScript BOS;
    public int MaxSheildHealth;
    public int SheildHealth;
    public bool isSheildActiveSheild;
    public GameObject SheiildGameobject;
    public TMP_Text sheildText;
    public bool hasDoneStuff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BOS.getIsflying() == true && BSAH.getAmount(2) != 0 && hasDoneStuff == false)
        {
            MaxSheildHealth = BSAH.getAmount(2) * 3;
            SheildHealth = MaxSheildHealth;
            hasDoneStuff = true;
        }
        if (SheildHealth <= 0)
        {
            SheiildGameobject.SetActive(false);
            isSheildActiveSheild = false;
            isSheildActiveSheild = false;

        }
        if (isSheildActiveSheild)
        {
            sheildText.text = "Sheild Health: " + SheildHealth.ToString();
        }
    }
    public void turnOnSheild()
    {
        SheiildGameobject.SetActive(true);
        SheildHealth = MaxSheildHealth;
        isSheildActiveSheild = true;
    }
    public bool isThereSheild()
    {
        return isSheildActiveSheild;
    }
    public void attackSheild(int damage)
    {
        SheildHealth -= damage;
    }



}
