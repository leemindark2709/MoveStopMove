using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnequipTrousers : MonoBehaviour
{
    public void OnButtonClick()
    {
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(true);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(false);
        //HairSkinManager.instance.DisableHair();
        //HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        //HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");

        TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.CheckTrousers = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.materials[0];


        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (Button == TrousersSkinManager.instance.ButtonTrousersItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }


    }
}
