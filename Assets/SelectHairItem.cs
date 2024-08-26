using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectHairItem : MonoBehaviour
{
    public void OnButtonClick()
    {
        HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        HairSkinManager.instance.IsHair = HairSkinManager.instance.CheckHair;
        CharSkinManager.instance.SelectHairItem.gameObject.SetActive(false);
        CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(true);
        HairSkinManager.instance.DisableEquippedText();
        
        foreach (Transform Button in HairSkinManager.instance.HairItemButtons)
        {
            if (Button == HairSkinManager.instance.ButtonHairItemClick)
            {
                HairSkinManager.instance.ButtonHairItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
            }

        }
    }
}
