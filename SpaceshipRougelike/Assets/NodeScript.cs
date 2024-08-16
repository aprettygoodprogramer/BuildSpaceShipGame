using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeScript : MonoBehaviour
{
    private int whatTypeOfPlanet;
    public shipAnimationScript ShipAnimationScript;
    public GameObject Map;
    public GameObject testShip;
    public EnemyShipSpwaner ESS;
    public SpaceShopScript SSS;
    public int WhatRandomEvent;
    void Start()
    {
        GameObject EMObject = GameObject.Find("SpaceShopManager");
        SSS = EMObject.GetComponent<SpaceShopScript>();
        whatTypeOfPlanet = Random.Range(1, 5);
    }

    public void OnButtonPress()
    {
        SSS.SpaceshopFalse();
        if (whatTypeOfPlanet == 1) {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-10.17479f, -26.22f);
            WhatRandomEvent = Random.Range(1, 3);
            if (WhatRandomEvent == 1)
            {
                ESS.SpwanShip(new Vector3(-10.17479f + 5, -26.22f, 0), 2);
            }
            else if (WhatRandomEvent == 2)
            {
                ESS.SpwanShop();
            }
             
        }

        if (whatTypeOfPlanet == 2)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-24.87f, -26.37f);
            WhatRandomEvent = Random.Range(1, 3);
            if (WhatRandomEvent == 1)
            {
                ESS.SpwanShip(new Vector3(-24.87f + 5, -26.37f, 0), 2);
            }
            else if (WhatRandomEvent == 2)
            {
                ESS.SpwanShop();
            }


        }
        if (whatTypeOfPlanet == 3)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-9.653739f, -45.05f);
            WhatRandomEvent = Random.Range(1, 3);

            if (WhatRandomEvent == 1)
            {


                ESS.SpwanShip(new Vector3(-9.653739f + 5, -45.05f, 0), 2);
            }
            else if (WhatRandomEvent == 2)
            {
                ESS.SpwanShop();
            }

        }
        if (whatTypeOfPlanet == 4)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-25.08f, -44.81f);
            
            WhatRandomEvent = Random.Range(1, 3);
            if (WhatRandomEvent == 1)
            {
                ESS.SpwanShip(new Vector3(-25.08f + 5, -44.81f, 0), 2);
            }
            if (WhatRandomEvent == 2)
            {
                ESS.SpwanShop();
            }

        }
        Map.SetActive(false);
    }
}
