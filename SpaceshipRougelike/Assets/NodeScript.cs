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
    void Start()
    {
        whatTypeOfPlanet = Random.Range(1, 5);
    }

    public void OnButtonPress()
    {
        if (whatTypeOfPlanet == 1) {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-10.17479f, -26.22f);
            ESS.SpwanShip(new Vector3(-10.17479f+5, -26.22f, 0), 2);

        }

        if (whatTypeOfPlanet == 2)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-24.87f, -26.37f);
            ESS.SpwanShip(new Vector3(-24.87f + 5, -26.37f, 0), 2);



        }
        if (whatTypeOfPlanet == 3)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-9.653739f, -45.05f);
            ESS.SpwanShip(new Vector3(-9.653739f + 5, -45.05f, 0), 2);


        }
        if (whatTypeOfPlanet == 4)
        {
            ShipAnimationScript.ChangeShipIsMoving(true);
            ShipAnimationScript.ChangeWhereTeleport(-25.08f, -44.81f);
            ESS.SpwanShip(new Vector3(-25.08f + 5, -44.81f, 0), 2);


        }
        Map.SetActive(false);
    }
}
