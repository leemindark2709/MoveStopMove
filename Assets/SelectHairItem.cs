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
                HairSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem).gameObject.SetActive(true);
                HairSkinManager.instance.ButtonHairItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
                Button.Find("Border").gameObject.SetActive(true);
                HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem);

                HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
                HairSkinManager.instance.IsHair = HairSkinManager.instance.CheckHair;

            }
            else
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
                Button.Find("Border").gameObject.SetActive(false);
            }

        }
    }
}