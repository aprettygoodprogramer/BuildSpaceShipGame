using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAiScript : MonoBehaviour
{
    private bool timerEnded = false;
    public follower Follower;
    private bool isCoroutineRunning = false; // To ensure coroutine is started only once
    private Weapon[] enemyWeapons;
    private int AmountWeapon;
    public HullStrengthScript HSS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(AmountWeapon);
        if (Follower.GetIsInBattle() == true && !isCoroutineRunning)
        {
            StartCoroutine(TimerCoroutine());
        }

        if (timerEnded)
        {
            
            ATTACK();
            timerEnded = false;
        }
    }
    void ATTACK()
    {
        
        int damage;
        int randomNum = Random.Range(0, AmountWeapon);
        damage = enemyWeapons[randomNum].GetWeaponDamage();
        Debug.Log(enemyWeapons[randomNum].GetWeaponDamage());
        Debug.Log(randomNum + "random Num");
        HSS.MinusHull(damage);
    }
    IEnumerator TimerCoroutine()
    {
        isCoroutineRunning = true; // Mark that the coroutine is running

        while (Follower.GetIsInBattle()) // Keep the coroutine running as long as the condition is met
        {
            float waitTime = Random.Range(3f, 7f);

            yield return new WaitForSeconds(waitTime);

            timerEnded = true;
        }

        isCoroutineRunning = false; // Mark that the coroutine is no longer running
    }
    public void getWeaponsForAi(Weapon[] weaponsHave)
    {
        enemyWeapons = weaponsHave;
        AmountWeapon = enemyWeapons.Count();
    }
}
