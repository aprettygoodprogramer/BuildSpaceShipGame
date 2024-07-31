using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeEnergyScript : MonoBehaviour
{
    private EnergyManager EM;
    private EnemyAiScript EAS;
    public float EnergyConsumed  = 30f;
    private bool hasGot = false;
    public int Damage;
    // Start is called before the first frame update

    void Start()
    {
        GameObject EMObject = GameObject.Find("EnemyAiManager");
        EAS = EMObject.GetComponent<EnemyAiScript>();
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
        EAS.takeDamage(Damage);
    }
    
    
}
