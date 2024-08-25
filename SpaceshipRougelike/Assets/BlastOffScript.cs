using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlastOffScript : MonoBehaviour
{
    public GameObject ShopMenu;
    public GameObject goButton;
    public GameObject shopMenu;
    public GameObject ShopMenuPg2;
    public CurrencyHandler CH;
    public float acceleration = 20f; 
    private float speed = 5f; 
    private bool isFlying = false;
    private float timer = 0.0f;
    public Transform ownTransform;
    public shipAnimationScript hehe;
    public bool hasBlastedOff;
    public bool HasSave;
    public GameObject Map;
    public BuildingSystemAmtHandler BSAH;

    void Update()
    {
        if (hehe.GetShipIsMoving())
        {

            ownTransform.position = hehe.GetWhereTeleport();
            hehe.ChangeShipIsMoving(false);
            

        }
    }

    void FixedUpdate()
    {
        if (HasSave == false)
        {
            CH.SaveCurrency();
            HasSave = true;
        }
        if (isFlying)
        {
            startBlastoff();
        }
    }
   
    public void blastOff()
    {
        if (BSAH.getAmount(6) != 0)
        {
            ShopMenu.SetActive(false);
            goButton.SetActive(false);
            ShopMenuPg2.SetActive(false);

            isFlying = true;
        }
        else
        {
            CH.NoThrustors();
        }

    }
    public void setMap()
    {
        if (isFlying == true)
        {
            Map.SetActive(true);
        }

    }
    void startBlastoff()
    {

            timer += Time.deltaTime;

        if (timer <= 2.5f)
        {

            speed += acceleration * Time.deltaTime;

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    public bool getIsflying()
    {
        return isFlying;
    }
    

}
