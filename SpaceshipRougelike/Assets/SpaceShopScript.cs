using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpaceShopScript : MonoBehaviour
{
    public Transform Pannel;
    public BlueprintManagerScript BM;
    public CurrencyHandler CH;
    public HullStrengthScript HSS;
    public bool isInShop;
    public bool hasSpwanedBlueprints;
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInShop == true)
        {
            if (hasSpwanedBlueprints == false)
            {
                BM.showBlueprintUiShop();
                hasSpwanedBlueprints = true;
            }
        }
        else
        {
            shopUI.SetActive(false);
        }
    }
    public void RepairHull()
    {
        if (CH.getCurrency(4) >= 7)
        {
            HSS.FullyRepairHull();
        }
    }
    public void SpaceshopTrue()
    {
        isInShop = true;
    }
    public bool isInShopA()
    {
        return isInShop;
    }
    public void SpaceshopFalse()
    {
        isInShop = false;
    }
}
