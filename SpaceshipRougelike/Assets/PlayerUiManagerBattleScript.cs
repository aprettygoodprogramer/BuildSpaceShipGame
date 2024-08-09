using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiManagerBattleScript : MonoBehaviour
{
    public follower Follower;
    public BuildingSystemAmtHandler BSAH;
    public GameObject BasicGunButtonPrefab;
    public Transform buttonParent;
    public GameObject PannelGameObject;
    private bool buttonsCreated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Follower.GetIsInBattle())
        {
            PannelGameObject.SetActive(true);
            if (buttonsCreated == false)
            {
                CreateWeaponButtons();
            }
            buttonsCreated = true;
        }
        if (Follower.GetIsInBattle() == false)
        {
            PannelGameObject.SetActive(false);
        }

    }

    void CreateWeaponButtons()
    {

        if (BSAH.getAmount(0) != 0)
        {
            
            Instantiate(BasicGunButtonPrefab, buttonParent);
        }


    }


}
