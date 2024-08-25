using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManagerScript : MonoBehaviour
{
    List<int> UnlockedBlueprints = new List<int>();
    public GameObject StunGunButton;
    public Transform Pannel;
    public GameObject StunGunButtonPrefab;
    public GameObject GeneraterPrefab;
    public GameObject LazerGun;
    public GameObject LazerGunPrefab;
    public GameObject GeneraterButon;
    public GameObject MachinegunButtonPregab;
    public GameObject MachineGunPrefab1;
    public Transform PannelForShop;
    public int deez;
    // Start is called before the first frame update
    void Start()
    {
        
        LoadBlueprints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  GetBlueprints()
    {
        //int chance = UnityEngine.Random.Range(1, 3);
        
        
            deez = UnityEngine.Random.Range(1, 5);

            if (UnlockedBlueprints.Count >= 4)
            {

            }
            else
            {
                while (UnlockedBlueprints.Contains(deez))
                {
                    deez = UnityEngine.Random.Range(1, 5);
                }

                UnlockedBlueprints.Add(deez);
                SaveBlueprints();
            }
        



    }
    public void addBlueprints(int index)
    {
        UnlockedBlueprints.Add(index);
        SaveBlueprints();
    }
    void LoadBlueprints()
    {
        string listString = PlayerPrefs.GetString("UnlockedBlueprints", "");
        if (!string.IsNullOrEmpty(listString))
        {
            UnlockedBlueprints = new List<int>(Array.ConvertAll(listString.Split(','), int.Parse));
        }
        foreach (int i in UnlockedBlueprints)
        {
            
            if (i == 1)
            {
                Debug.Log("deez my nuts");
                StunGunButton.SetActive(true);
            }
            if (i == 2)
            {
                GeneraterButon.SetActive(true);
            }
            if (i == 3)
            {
                MachinegunButtonPregab.SetActive(true);
            }
            if (i == 4)
            {
                LazerGun.SetActive(true);
            }
        }
    }
    void SaveBlueprints()
    {
        string listString = string.Join(",", UnlockedBlueprints);
        PlayerPrefs.SetString("UnlockedBlueprints", listString);
        PlayerPrefs.Save();
    }
    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void showBlueprintsUi()
    {
        if (deez == 1)
        {
            Instantiate(StunGunButtonPrefab, Pannel);

        }
        if (deez == 2)
        {
            Instantiate(GeneraterPrefab, Pannel);
  
        }
        if (deez == 3)
        {
            Instantiate(MachineGunPrefab1, Pannel);
        }
        if (deez == 4)
        {
            Instantiate(LazerGunPrefab, Pannel);
        }

    }
    public void showBlueprintUiShop()
    {
        int skibidi = UnityEngine.Random.Range(1,4);
        if (skibidi == 1)
        {
            Instantiate(StunGunButtonPrefab, PannelForShop); 
        }
        else if (skibidi == 2)
        {
            Instantiate(GeneraterPrefab, PannelForShop);
        }
        else if (skibidi == 3)

        {
            Instantiate(MachineGunPrefab1, PannelForShop);
        }
        else if (skibidi == 4)
        {
            Instantiate(LazerGunPrefab, PannelForShop);
        }

    }
}
