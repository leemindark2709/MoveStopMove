using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnequipShield : MonoBehaviour
{
   public void OnButtonClick()
    {
        CharSkinManagerShield.instance.SelectShieldItem.gameObject.SetActive(true);
        CharSkinManagerShield.instance.UnequipShieldItem.gameObject.SetActive(false);
        ShieldSkinManager.instance.DisableShield();
        ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.FindPositionShieldItem("NoneShield");

        PlayerPrefs.SetString("IsShield", "NoneShield");
        PlayerPrefs.Save();
        ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.FindPositionShieldItem("NoneShield");
        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (Button == ShieldSkinManager.instance.ButtonShieldItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
