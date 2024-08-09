using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnergyManager : MonoBehaviour
{
    public Image energyBarImage; // Reference to the UI Image that represents the energy bar.
    public float maxEnergy = 50f; // Maximum energy value.
    public float regenRate = 20f; // Energy regeneration rate per second.
    public float energyConsumption = 10f; // Energy consumed per action.
    private float currentEnergy;
    public follower Follower;
    public EnemyAiScript EAS;
    public GameObject EnergyGameObject;
    public int damageSet;
    void Start()
    {
        currentEnergy = maxEnergy;
    }

    void Update()
    {
        if (Follower.GetIsInBattle() == true)
        {
            EnergyGameObject.SetActive(true);
            RegenerateEnergy();
            UpdateEnergyBarUI();
        }
        if (Follower.GetIsInBattle() == false)
        {
            EnergyGameObject.SetActive(false);
        }

    }

    void RegenerateEnergy()
    {
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += regenRate * Time.deltaTime;
            if (currentEnergy > maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }
    }

        public void ConsumeEnergy(float energyTake)
    {
        if (currentEnergy >= energyTake)
        {
            currentEnergy -= energyTake;
            EAS.takeDamage(damageSet);
        }
        else
        {
            
        }
    }
    public void UpdateEnergyBarUI()
    {
        energyBarImage.fillAmount = currentEnergy / maxEnergy;
    }
    public void setDamageInt( int DAMAGE)
    {
        damageSet = DAMAGE;
    }
}
