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
    public GameObject GeneraterButon;
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
        int deez = UnityEngine.Random.Range(1, 3);

        if (UnlockedBlueprints.Count >= 2)
        {

        }
        else
        {
            while (UnlockedBlueprints.Contains(deez))
            {
                deez = UnityEngine.Random.Range(1, 3);
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
        
    }
    public void showBlueprintUiShop()
    {
        Debug.Log("yooo LLLL");
        int skibidi = UnityEngine.Random.Range(1,3);
        if (skibidi == 1)
        {
            Debug.Log("yooo");
            Instantiate(StunGunButtonPrefab, PannelForShop); 
        }
        else if (skibidi == 2)
        {
            Debug.Log("yooo");
            Instantiate(GeneraterPrefab, PannelForShop);
        }

    }
}
