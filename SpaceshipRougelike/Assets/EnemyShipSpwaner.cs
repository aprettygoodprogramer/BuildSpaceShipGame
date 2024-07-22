using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpwaner : MonoBehaviour
{
    public GameObject testEnemyShip;
    public follower Follower123;
    public EnemySpaceshipScript ESS123;
    public EnemyAiScript EAS;
    Weapon myWeapon = new Weapon(0, 3, false);
    Weapon myWeapon1 = new Weapon(1, 10, false);
    Weapon myWeapon2 = new Weapon(2, 2, false);
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
        weapons.Add(new Weapon(myWeapon));
        weapons.Add(new Weapon(myWeapon1));
        weapons.Add(new Weapon(myWeapon2));
        Weapon[] weaponsArray = weapons.ToArray();
        EAS.getWeaponsForAi(weaponsArray);



    }
}
public class Weapon
{
    private int weaponId;
    private int weaponDamage;
    private bool specialWeapon;
    private Weapon myWeapon;

    public Weapon(int id, int damage, bool isSpecial)
    {
        weaponId = id;
        weaponDamage = damage;
        specialWeapon = isSpecial;
    }

    public Weapon(Weapon myWeapon)
    {
        this.myWeapon = myWeapon;
    }

    public int GetWeaponId()
    {
        return weaponId;
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

