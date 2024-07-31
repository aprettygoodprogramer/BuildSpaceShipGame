using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShipSpwaner : MonoBehaviour
{
    public GameObject testEnemyShip;
    public follower Follower123;
    public EnemySpaceshipScript ESS123;
    public EnemyAiScript EAS;
    Weapon myWeapon = new Weapon(3, false);
    Weapon myWeapon1 = new Weapon(6, false);
    Weapon myWeapon2 = new Weapon( 2, false);
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


        List<Weapon> weapons = new List<Weapon>();


        weapons.Add(myWeapon);
        weapons.Add(myWeapon1);
        weapons.Add(myWeapon2);
        EAS.getHealthForAi(20);
        EAS.getWeaponsForAi(weapons.ToArray());
    }
}
public class Weapon
{
    private int weaponDamage;
    private bool specialWeapon;
    private Weapon myWeapon;

    public Weapon(int damage, bool isSpecial)
    {

        weaponDamage = damage;
        specialWeapon = isSpecial;

    }

    public Weapon(Weapon myWeapon)
    {
        this.myWeapon = myWeapon;
    }



    public int GetWeaponDamage()
    {
        return weaponDamage;
    }

    public bool GetSpecialWeapon()
    {
        return specialWeapon;
    }
}

