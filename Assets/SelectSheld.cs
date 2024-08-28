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






        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        HairSkinManager.instance.disableAllPanel();
        HairSkinManager.instance.DisableEquippedText();
        HairSkinManager.instance.IsHair = HairSkinManager.instance.HairItemPosition[4];
        HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
        HairSkinManager.instance.IsHair.gameObject.SetActive(false);
        HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
        HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.HairItemButtons[0];
        HairSkinManager.instance.ButtonHairItemChose = null;
        GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(true);
        GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(false);
        GameManager.Instance.HairSkin.gameObject.SetActive(false);





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
