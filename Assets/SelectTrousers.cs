using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrousers : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.CheckTrousers;
        //TrousersSkinManager.instance.CheckHair.gameObject.SetActive(true);
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        TrousersSkinManager.instance.DisableEquippedText();


        GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        ShieldSkinManager.instance.disableAllPanel();
        ShieldSkinManager.instance.DisableEquippedText();
        ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.ShieldItemPosition[2];
        ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[1];
        ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
        ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
        ShieldSkinManager.instance.ButtonShieldItemClick = ShieldSkinManager.instance.ShieldItemButtons[0];
        ShieldSkinManager.instance.ButtonShieldItemChose = null;
        GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(true);
        GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);

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







        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;
       
        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.CheckHair;
       
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        TrousersSkinManager.instance.DisableEquippedText();
        foreach (Transform Button in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (Button == TrousersSkinManager.instance.ButtonTrousersItemClick)
            {
                //TrousersSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem).gameObject.SetActive(true);
                TrousersSkinManager.instance.ButtonTrousersItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
                Button.Find("Border").gameObject.SetActive(true);
                TrousersSkinManager.instance.CheckTrousers = Button.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().material;
                TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.CheckTrousers;
                TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;
            }
            else
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
                Button.Find("Border").gameObject.SetActive(false);
            }

        }
    }
}
