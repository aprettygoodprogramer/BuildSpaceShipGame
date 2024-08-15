using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HullStrengthScript : MonoBehaviour
{
    public int HullStrength = 3;
    public int HullStrengthMax = 3;
    public int HowMuchHullStrengthToAdd = 0;
    public TMP_Text HullText;
    public BlastOffScript BOS;
    private bool HasSetMax = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HullText.text = "Current Hull Strength: " + HullStrength.ToString();
        if (BOS.getIsflying() == true && HasSetMax == false)
        {
            HullStrengthMax = HullStrength;
            HasSetMax = true;

        }
        if (HullStrength < 0)
        {
            SceneManager.LoadScene(1);
        }
        
    }
    public void ChangeMuchHull(int amount)
    {
        HowMuchHullStrengthToAdd = amount;
    }
    public int GetMuchHullStrength()
    {
        return HowMuchHullStrengthToAdd;
    }
    public void SetHowMuchHullToHullStrenght()
    {
        HullStrength += HowMuchHullStrengthToAdd;
    }
    public void MinusHull(int heeheh)
    {
        HullStrength -= heeheh;
    }
    public void FullyRepairHull()
    {
        HullStrength = HullStrengthMax;
    }
}
