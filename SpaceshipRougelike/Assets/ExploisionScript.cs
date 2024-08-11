using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ExploisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool IsButton;
    public CurrencyHandler CH;
    void Start()
    {
        GameObject EMObject = GameObject.Find("CuurencyHolder");
        CH = EMObject.GetComponent<CurrencyHandler>();
        if (IsButton == false)
        {
            Invoke("DestroySelf", 0.23f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsButton == true)
        {
            if (CH.GetIsInMenu() == false)
            {
                DestroySelf();
            }
        }


    }
    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
