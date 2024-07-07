using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpwaner : MonoBehaviour
{
    public GameObject testEnemyShip;
    public follower Follower123;
    public EnemySpaceshipScript ESS123;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpwanShip(Vector3 whereSpwan, int OddsMax)
    {

        Instantiate(testEnemyShip, whereSpwan, Quaternion.identity);
        Follower123.ChangeIsInBattle();
    }
}
