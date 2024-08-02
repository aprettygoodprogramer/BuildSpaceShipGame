using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyScriptUiShower : MonoBehaviour
{
    public TMP_Text EnemyUIHealthText;
    public EnemySpaceshipScript enemySpaceshipScript;
    public follower Follower;
    public GameObject self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Follower.GetIsInBattle())
        {
            self.SetActive(true);
            int enemyHp = enemySpaceshipScript.GetEnemyHp();
            

        }
    }
}
