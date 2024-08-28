using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSheld : MonoBehaviour
{
    public void OnButtonClick()
    {
       
            ShieldSkinManager.instance.CheckShield.gameObject.SetActive(true);
            ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.CheckShield;
            CharSkinManagerShield.instance.SelectShieldItem.gameObject.SetActive(false);
            CharSkinManagerShield.instance.UnequipShieldItem.gameObject.SetActive(true);
            ShieldSkinManager.instance.DisableEquippedText();

            foreach (Transform Button in ShieldSkinManager.instance.ShieldItemButtons)
            {
                if (Button == ShieldSkinManager.instance.ButtonShieldItemClick)
                {
                    ShieldSkinManager.instance.ButtonShieldItemChose = Button;
                    Button.Find("EquippedText").gameObject.SetActive(true);
                }

            
        }       
    }
}
