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
    // Start is called before the first frame update
    void Start()
    {
        
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
            Debug.Log("heheheh");
            timerEnded = false;
        }
    }

    IEnumerator TimerCoroutine()
    {
        isCoroutineRunning = true; // Mark that the coroutine is running

        while (Follower.GetIsInBattle()) // Keep the coroutine running as long as the condition is met
        {
            float waitTime = Random.Range(3f, 14f);

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
