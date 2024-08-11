using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public SheildManagerScrupo SMS;
    public BlueprintManagerScript BMS;
    public GameObject MapButtonRenenable;
    public int[] CurrencyGiveList;
    public CurrencyHandler CH;
    public bool isStuns;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(isStuns);

        if (Follower.GetIsInBattle() && !isCoroutineRunning)
        {
            StartCoroutine(TimerCoroutine());
        }

        if (timerEnded)
        {
            if (!isStuns)
            {
                ATTACK();
                timerEnded = false;
            }
        }

        if (Follower.GetIsInBattle())
        {
            enemyHealthText.text = "Enemy Hull Strength: " + EnemyHealth.ToString();
            if (EnemyHealth <= 0)
            {
                timerEnded = false;
                Follower.IsInBattleFalse();
                GameObject Enemy = GameObject.FindWithTag("Enemy");
                Destroy(Enemy);
                MapButtonRenenable.SetActive(true);
                BMS.GetBlueprints();
                for (int i = 0; i < CurrencyGiveList.Length; i++)
                {
                    CH.AddCurrency(i, CurrencyGiveList[i]);
                }
                CH.showAddedCurrencys(CurrencyGiveList);
                CH.SaveCurrency();
                BMS.showBlueprintsUi();
            }
        }
    }

    void ATTACK()
    {
        int damage;
        int randomNum = Random.Range(0, AmountWeapon);
        damage = enemyWeapons[randomNum].GetWeaponDamage();
        explodeThingy();

        if (SMS.isThereSheild())
        {
            SMS.attackSheild(damage);
        }
        else
        {
            HSS.MinusHull(damage);
        }

        audioData.Play(0);
    }

    IEnumerator TimerCoroutine()
    {
        isCoroutineRunning = true;

        while (Follower.GetIsInBattle())
        {
            if (!isStuns)
            {
                float waitTime = Random.Range(3f, 7f);
                yield return new WaitForSeconds(waitTime);
                timerEnded = true;
            }
            else
            {
                yield return null; // Wait without attacking if stunned
            }
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

    public void StunEnemy(float stunDuration)
    {
        if (!isStuns) // Only stun if not already stunned
        {
            StartCoroutine(StunCoroutine(stunDuration));
        }
    }

    private IEnumerator StunCoroutine(float stunDuration)
    {
        isStuns = true;
        yield return new WaitForSeconds(stunDuration);
        isStuns = false;
    }
}
