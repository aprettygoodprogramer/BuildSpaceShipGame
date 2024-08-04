using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using UnityEngine;
using TMPro;

public class EnemyAiScript : MonoBehaviour
{
    private bool timerEnded = false;
    public follower Follower;
    private bool isCoroutineRunning = false; 
    private Weapon[] enemyWeapons;
    private int AmountWeapon;
    public HullStrengthScript HSS;
    AudioSource audioData;
    public GameObject parentObject;
    public GameObject explosionPrefab;
    public int EnemyHealth;
    public TMP_Text enemyHealthText;

    //0 = Lothonium    1 = Raw Mats    2 = Fule    3 = Adv Parts    4 = Milky Way Dollars
    public int[] CurrencyGiveList;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Follower.GetIsInBattle() == true && !isCoroutineRunning)
        {
            StartCoroutine(TimerCoroutine());
        }

        if (timerEnded)
        {
            
            ATTACK();
            timerEnded = false;
        }
        if (Follower.GetIsInBattle())
        {
            enemyHealthText.text = "Enemy Hull Strength: " + EnemyHealth.ToString();
            if (EnemyHealth <= 0)
            {
                Follower.ChangeIsInBattle();
                GameObject Enemy = GameObject.FindWithTag("Enemy");
                Destroy(Enemy);
            }
        }

    }

    void ATTACK()
    {
        
        int damage;
        int randomNum = Random.Range(0, AmountWeapon);
        damage = enemyWeapons[randomNum].GetWeaponDamage();
        explodeThingy();
        HSS.MinusHull(damage);
        audioData.Play(0);
    }
    IEnumerator TimerCoroutine()
    {
        isCoroutineRunning = true;

        while (Follower.GetIsInBattle())
        {
            float waitTime = Random.Range(3f, 7f);

            yield return new WaitForSeconds(waitTime);

            timerEnded = true;
        }

        isCoroutineRunning = false;
    }
    public void getWeaponsForAi(Weapon[] weaponsHave)
    {
        enemyWeapons = weaponsHave;
        AmountWeapon = enemyWeapons.Count();
    }
    public void getHealthForAi(int funcHealth)
    {
        EnemyHealth = funcHealth;
    }
    void explodeThingy()
    {
        int Children = parentObject.transform.childCount;
        int deez = Random.Range(0, Children);
        Transform randomChild = parentObject.transform.GetChild(deez);

        Vector3 childPosition = randomChild.position;

        Instantiate(explosionPrefab, childPosition, Quaternion.identity);
    }
    public void takeDamage(int healthTaken)
    {
        EnemyHealth -= healthTaken;
    }
    public void howMuchGiveWhenDefeat(int[] giveList)
    {
        CurrencyGiveList = giveList;
    }
}
