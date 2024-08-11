using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUiManagerBattleScript : MonoBehaviour
{
    public follower Follower;
    public BuildingSystemAmtHandler BSAH;
    public GameObject BasicGunButtonPrefab;
    public GameObject SheildButton;
    public Transform buttonParent;
    public GameObject PannelGameObject;
    public GameObject StunGunButton;
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
        if (BSAH.getAmount(2) != 0)
        {

            Instantiate(SheildButton, buttonParent);
        }

        if (BSAH.getAmount(3) != 0)
        {
            Instantiate(StunGunButton, buttonParent);
        }

    }


}
