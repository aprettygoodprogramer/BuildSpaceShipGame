using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NodeScript : MonoBehaviour
{
    private int whatTypeOfPlanet;
    public shipAnimationScript ShipAnimationScript;
    public GameObject Map;
    void Start()
    {
        whatTypeOfPlanet = Random.Range(1, 5);
    }

    public void OnButtonPress()
    {
        if (whatTypeOfPlanet == 1) {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-10.17479f, -26.22f);
            Debug.Log("hehe 1");
        }

        if (whatTypeOfPlanet == 2)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-24.87f, -26.37f);
            Debug.Log("haha 2");

        }
        if (whatTypeOfPlanet == 3)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-9.653739f, -45.05f);

        }
        if (whatTypeOfPlanet == 4)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-25.08f, -44.81f);

        }
        Map.SetActive(false);
    }
}
