using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class CurrencyHandler : MonoBehaviour
{
    int LothoniumAmt = 1000;
    int RawMaterialsAmt = 1000;
    int FuleAmt = 1000;
    int AdvancedPartsAmt = 1000;
    int MilkyWayDollarsAmt = 1000;
    public TextMeshProUGUI textToFade;
    public EnergyManager EM;

    public TextMeshProUGUI textToFade2;


    public float fadeDuration = 3.5f;
    public TMP_Text LothoniumTxt;
    public TMP_Text RawMaterialsTxt;
    public TMP_Text FuleTxt;
    public TMP_Text AdvancedPartsTxt;
    public TMP_Text MilkyWayDollarsTxt;
   



    public bool isInMenu;
    public TMP_Text LothoniumTxtGain;
    public TMP_Text RawMaterialsTxtGain;
    public TMP_Text FuleTxtGain;
    public TMP_Text AdvancedPartsTxtGain;
    public TMP_Text MilkyWayDollarsTxtGain;
    public GameObject deeznuts123;
    int LothoniumAmtGain = 0;
    int RawMaterialsAmtGain = 0;
    int FuleAmtGain = 0;
    int AdvancedPartsAmtGain = 0;
    int MilkyWayDollarsAmtGain = 0;
    public string StartOfGame = "1";
    // Start is called before the first frame update
    void Start()
    {
        Color color = textToFade.color;
        color.a = 0;
        textToFade.color = color;

        Color color2 = textToFade2.color;
        color2.a = 0;
        textToFade2.color = color2;


        if (!PlayerPrefs.HasKey("StartOfGame"))
        {
            LothoniumAmt = 1000;
            RawMaterialsAmt = 1000;
            FuleAmt = 1000;
            AdvancedPartsAmt = 1000;
            MilkyWayDollarsAmt = 1000;
            PlayerPrefs.SetString("StartOfGame", "2");
            PlayerPrefs.Save();
        }
        else
        {



            LothoniumAmt = PlayerPrefs.GetInt("Lothonium", 0);
            RawMaterialsAmt = PlayerPrefs.GetInt("Raw Materials", 0);
            FuleAmt = PlayerPrefs.GetInt("Fule", 0);
            AdvancedPartsAmt = PlayerPrefs.GetInt("Advanced Parts", 0);
            MilkyWayDollarsAmt = PlayerPrefs.GetInt("Milky Way Dollars", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LothoniumTxt.text = "Lothonium: " + LothoniumAmt.ToString();
        RawMaterialsTxt.text = "Raw Materials: " + RawMaterialsAmt.ToString();
        FuleTxt.text = "Fule: " + FuleAmt.ToString();
        AdvancedPartsTxt.text = "Advanced Parts: " + AdvancedPartsAmt.ToString();
        MilkyWayDollarsTxt.text = "Milky Way Dollars: " + MilkyWayDollarsAmt.ToString();
        if (isInMenu)
        {
            LothoniumTxtGain.text = "+ " + LothoniumAmtGain.ToString() + " Lothonium";
            RawMaterialsTxtGain.text = "+ " + RawMaterialsAmtGain.ToString() + " Raw Materials";
            FuleTxtGain.text = "+ " + FuleAmtGain.ToString() + " Fule";
            AdvancedPartsTxtGain.text = "+ " + AdvancedPartsAmtGain.ToString()  + " AdvancedParts";
            MilkyWayDollarsTxtGain.text = "+ " + MilkyWayDollarsAmtGain.ToString() + " Milky Way Dollars";
        }
        if (isInMenu == false)
        {
            deeznuts123.SetActive(false);
        }
    }

    public int getCurrency(int whatKind)
    {
        if (whatKind == 0)
        {
            return LothoniumAmt;
        }
        if (whatKind == 1)
        {
            return RawMaterialsAmt;
        }
        if (whatKind == 2)
        {
            return FuleAmt;
        }
        if (whatKind == 3)
        {
            return AdvancedPartsAmt;
        }
        if (whatKind == 4)
        {
            return MilkyWayDollarsAmt;
        }
        else
        {
            return 0;
        }
    }
    public void subtractCurrency(int whatKind, int howMuch)
    {
        if (whatKind == 0)
        {
           LothoniumAmt-=howMuch; 
        }
        if (whatKind == 1)
        {
            RawMaterialsAmt-=howMuch;
        }
        if (whatKind == 2)
        {
            FuleAmt-=howMuch;
        }
        if (whatKind == 3)
        {
            AdvancedPartsAmt-=howMuch;
        }
        if (whatKind == 4)
        {
           MilkyWayDollarsAmt-=howMuch;
        }
    }
    public void AddCurrency(int whatKind, int howMuch)
    {
        if (whatKind == 0)
        {
            LothoniumAmt += howMuch;
        }
        if (whatKind == 1)
        {
            RawMaterialsAmt += howMuch;
        }
        if (whatKind == 2)
        {
            FuleAmt += howMuch;
        }
        if (whatKind == 3)
        {
            AdvancedPartsAmt += howMuch;
        }
        if (whatKind == 4)
        {
            MilkyWayDollarsAmt += howMuch;
        }
    }
    public void noArmory()
    {
        StartCoroutine(FadeTextToZeroAlpha(fadeDuration, 1));
    }
    public void NoThrustors()
    {
        StartCoroutine(FadeTextToZeroAlpha(fadeDuration, 2));
    }
    private IEnumerator FadeTextToZeroAlpha(float duration, int whichOne)
    {
        if (whichOne == 1)
        {
            Color originalColor = textToFade.color;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(1.0f - (elapsedTime / duration));
                textToFade.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }

            textToFade.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        }
        else if (whichOne == 2)
        {
            Color originalColor = textToFade2.color;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Clamp01(1.0f - (elapsedTime / duration));
                textToFade2.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }

            textToFade2.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
        }
    }
    public void showAddedCurrencys(int[] stuffYoGot)
    {
        deeznuts123.SetActive(true);
        isInMenu = true;
        LothoniumAmtGain = stuffYoGot[0];
        RawMaterialsAmtGain = stuffYoGot[1];
        FuleAmtGain = stuffYoGot[2];
        AdvancedPartsAmtGain = stuffYoGot[3];
        MilkyWayDollarsAmtGain = stuffYoGot[4];

    }
    public void turnOffMenu()
    {
        isInMenu = false;
    }
    public void SaveCurrency()
    {
        PlayerPrefs.SetInt("Lothonium", LothoniumAmt);
        PlayerPrefs.SetInt("Raw Materials", RawMaterialsAmt);
        PlayerPrefs.SetInt("Fule", FuleAmt);
        PlayerPrefs.SetInt("Advanced Parts", AdvancedPartsAmt);
        PlayerPrefs.SetInt("Milky Way Dollars", MilkyWayDollarsAmt);
        PlayerPrefs.Save();

    }
    void OnApplicationQuit()
    {
        SaveCurrency();
    }
    public bool GetIsInMenu()
    {
        return isInMenu;
    }

    public void GiveEnergyForFule()
    {
        if (FuleAmt >= 7)
        {
            EM.AddEnergy();
            FuleAmt -= 7; 

        }
    }
    public void GiveMoney()
    {
         LothoniumAmt = 1000;
         RawMaterialsAmt = 1000;
         FuleAmt = 1000;
         AdvancedPartsAmt = 1000;
         MilkyWayDollarsAmt = 1000;
    }
}
