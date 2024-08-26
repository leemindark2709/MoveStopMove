using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrousers : MonoBehaviour
{
    
    public void OnButtonClick()
    {

        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;
       
        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.CheckHair;
       
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        TrousersSkinManager.instance.DisableEquippedText();
        foreach (Transform Button in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (Button == TrousersSkinManager.instance.ButtonTrousersItemClick)
            {
                TrousersSkinManager.instance.ButtonTrousersItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
            }

        }
    }
}
