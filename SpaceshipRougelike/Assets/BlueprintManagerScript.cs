using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueprintManagerScript : MonoBehaviour
{
    List<int> UnlockedBlueprints = new List<int>();
    public GameObject StunGunButton;
    // Start is called before the first frame update
    void Start()
    {
        
        LoadBlueprints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int  GetBlueprints()
    {
        int deez = 1;
        UnlockedBlueprints.Add(deez);
        SaveBlueprints();


        return deez;

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
}
