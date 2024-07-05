using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HullStrengthScript : MonoBehaviour
{
    public int HullStrength = 3;
    public int HowMuchHullStrengthToAdd = 0;
    public TMP_Text HullText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HullText.text = "Current Hull Strength: " + HullStrength.ToString();
        
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

}
