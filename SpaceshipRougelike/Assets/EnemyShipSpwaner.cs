using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyShipSpwaner : MonoBehaviour
{
    public GameObject testEnemyShip;
    public GameObject FuleTanker;
    public GameObject Gunner;
    public follower Follower123;
    public HullStrengthScript HSS;
    public EnemySpaceshipScript ESS123;
    public EnemyAiScript EAS;
    public GameObject ShopGameObject;
    public SpaceShopScript SSS;
    private int gyatt;

    Weapon myWeapon = new Weapon(3, false);
    Weapon myWeapon1 = new Weapon(6, false);
    Weapon myWeapon2 = new Weapon( 2, false);

    Weapon FuleWeapon1 = new Weapon(4, false);
    Weapon FuleWeapon2 = new Weapon(3, false);
    Weapon FuleWeapon3 = new Weapon(7, false);

    Weapon GunnerWeapon = new Weapon(14, false);
    Weapon GunnerWeapon2 = new Weapon(20, false);
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
        if (HSS.GetMuchHullStrength() >= 35)

        {
             gyatt = UnityEngine.Random.Range(1, 4);
        }
        else
        {
            gyatt = UnityEngine.Random.Range(1, 3);
        }
        if (gyatt == 1)
        {
            Instantiate(testEnemyShip, whereSpwan, Quaternion.identity);
            Follower123.ChangeIsInBattle();


            List<Weapon> weapons = new List<Weapon>();


            weapons.Add(myWeapon);
            weapons.Add(myWeapon1);
            weapons.Add(myWeapon2);
            EAS.getHealthForAi(20);
            //0 = Lothonium    1 = Raw Mats    2 = Fule    3 = Adv Parts    4 = Milky Way Dollars
            int[] weaponGive = { 1, 2, 0, 0, 6 };
            EAS.howMuchGiveWhenDefeat(weaponGive);
            EAS.getWeaponsForAi(weapons.ToArray());
        }
        else if (gyatt == 2)
        {
            Instantiate(FuleTanker, whereSpwan, Quaternion.identity);
            Follower123.ChangeIsInBattle();


            List<Weapon> weapons = new List<Weapon>();


            weapons.Add(FuleWeapon1);
            weapons.Add(FuleWeapon2);
            weapons.Add(FuleWeapon3);
            EAS.getHealthForAi(30);
            //0 = Lothonium    1 = Raw Mats    2 = Fule    3 = Adv Parts    4 = Milky Way Dollars
            int[] weaponGive = { 0, 4, 25, 1, 10 };
            EAS.howMuchGiveWhenDefeat(weaponGive);
            EAS.getWeaponsForAi(weapons.ToArray());
        }
        else if (gyatt == 3)
        {
            Instantiate(Gunner, whereSpwan, Quaternion.identity);
            Follower123.ChangeIsInBattle();


            List<Weapon> weapons = new List<Weapon>();


            weapons.Add(GunnerWeapon);
            weapons.Add(GunnerWeapon2);

            EAS.getHealthForAi(60);
            //0 = Lothonium    1 = Raw Mats    2 = Fule    3 = Adv Parts    4 = Milky Way Dollars
            int[] weaponGive = { 10, 5, 2, 1, 5};
            EAS.howMuchGiveWhenDefeat(weaponGive);
            EAS.getWeaponsForAi(weapons.ToArray());
        }
    }
    public void SpwanShop()
    {
        ShopGameObject.SetActive(true);
        SSS.SpaceshopTrue();
    }

    public void DisableShop()
    {
        ShopGameObject.SetActive(false);
        SSS.SpaceshopFalse();
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

