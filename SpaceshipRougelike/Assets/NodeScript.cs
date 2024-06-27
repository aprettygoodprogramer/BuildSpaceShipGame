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
        whatTypeOfPlanet = Random.Range(1, 2);
    }

    public void OnButtonPress()
    {
        if (whatTypeOfPlanet == 1) {
            ShipAnimationScript.ChangeShipIsMoving();
            ShipAnimationScript.ChangeWhereTeleport(-7.7f, -25.9f);
        }
        Map.SetActive(false);
    }
}
