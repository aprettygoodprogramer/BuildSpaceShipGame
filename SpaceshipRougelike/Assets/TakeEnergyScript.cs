using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeEnergyScript : MonoBehaviour
{
    private EnergyManager EM;
    private EnemyAiScript EAS;
    private CurrencyHandler CH;
    private SheildManagerScrupo SMS;
    public float EnergyConsumed  = 30f;
    private bool hasGot = false;
    public int Damage;
    // Start is called before the first frame update

    void Start()
    {

        GameObject CHObject = GameObject.Find("CuurencyHolder");
        CH = CHObject.GetComponent<CurrencyHandler>();

        GameObject EMObject = GameObject.Find("EnemyAiManager");
        EAS = EMObject.GetComponent<EnemyAiScript>();

        GameObject SMSObject = GameObject.Find("SheildManager");
        SMS = SMSObject.GetComponent<SheildManagerScrupo>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hasGot == false)
        {
            GameObject EMObject = GameObject.Find("EnergyManager");
            EM = EMObject.GetComponent<EnergyManager>();
            hasGot = true;
        }
    }
    public void TakeEnergy()
    {
        EM.ConsumeEnergy(EnergyConsumed);

    }
    public void DoDamage()
    {
        EM.setDamageInt(Damage);
    }

    public void activateSheild()
    {
        SMS.turnOnSheild();
    }

    public void StunEnemy()
    {
        
        EAS.StunEnemy(10f);
    }
    public void GiveEnergy()
    {
        CH.GiveEnergyForFule();
    }
    
}
