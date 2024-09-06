using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnEnquipHairItem : MonoBehaviour
{

    public void OnButtonClick()
    {


        CharSkinManager.instance.SelectHairItem.gameObject.SetActive(true);
        CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(false);
        HairSkinManager.instance.DisableHair();
        HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        PlayerPrefs.SetString("IsHair", "NoneHair");
        PlayerPrefs.Save();
        HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in HairSkinManager.instance.HairItemButtons)
        {
            if (Button == HairSkinManager.instance.ButtonHairItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }


    }
}
