using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeEnergyScript : MonoBehaviour
{
    private EnergyManager EM;
    private EnemyAiScript EAS;
    private SheildManagerScrupo SMS;
    public float EnergyConsumed  = 30f;
    private bool hasGot = false;
    public int Damage;
    // Start is called before the first frame update

    void Start()
    {
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
    
    
}
