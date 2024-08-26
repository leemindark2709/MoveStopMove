using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFullSet : MonoBehaviour
{
    public void OnButtonClick()
    {

        FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.CheckFullSet;

        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.CheckHair;

        CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(false);
        CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(true);
        FullSetSkinManager.instance.DisableEquippedText();
        foreach (Transform Button in FullSetSkinManager.instance.FullSetItemButtons)
        {
            if (Button == FullSetSkinManager.instance.ButtonFullSetItemClick)
            {
                FullSetSkinManager.instance.ButtonFullSetItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
            }

        }
    }
}
