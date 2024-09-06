using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFullSet : MonoBehaviour
{
    public void OnButtonClick()
    {





        FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(true);
        FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.CheckFullSet;
        CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(false);
        CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(true);
        FullSetSkinManager.instance.DisableEquippedText();


        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        HairSkinManager.instance.disableAllPanel();
        HairSkinManager.instance.DisableEquippedText();
        HairSkinManager.instance.IsHair = HairSkinManager.instance.HairItemPosition[4];
        PlayerPrefs.SetString("IsHair", "NoneHair");
        PlayerPrefs.Save();
        HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
        HairSkinManager.instance.IsHair.gameObject.SetActive(false);
        HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
        HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.HairItemButtons[0];
        HairSkinManager.instance.ButtonHairItemChose = null;
        GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(true);
        GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(false);
        GameManager.Instance.HairSkin.gameObject.SetActive(false);




        GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        TrousersSkinManager.instance.disableAllPanel();
        TrousersSkinManager.instance.DisableEquippedText();
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.CheckTrousers = TrousersSkinManager.instance.materials[0];

        PlayerPrefs.SetString("IsTrousers", "Yealow");
        PlayerPrefs.Save();

        TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
        TrousersSkinManager.instance.ButtonTrousersItemClick = TrousersSkinManager.instance.TrousersItemButtons[0];
        TrousersSkinManager.instance.ButtonTrousersItemChose = null;
        GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(true);
        GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(false);
        GameManager.Instance.TrousersSkin.gameObject.SetActive(false);


        GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        ShieldSkinManager.instance.disableAllPanel();
        ShieldSkinManager.instance.DisableEquippedText();
        ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.ShieldItemPosition[2];
        PlayerPrefs.SetString("IsShield", "NoneShield");
        PlayerPrefs.Save();
        ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[1];
        ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
        ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
        ShieldSkinManager.instance.ButtonShieldItemClick = ShieldSkinManager.instance.ShieldItemButtons[0];
        ShieldSkinManager.instance.ButtonShieldItemChose = null;
        GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(true);
        GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);


        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.CheckHair;

        CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(false);
        CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(true);
        FullSetSkinManager.instance.DisableEquippedText();
        foreach (Transform Button in FullSetSkinManager.instance.FullSetItemButtons)
        {
            if (Button == FullSetSkinManager.instance.ButtonFullSetItemClick)
            {
                FullSetSkinManager.instance.FindPositionFullSetItem(Button.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().nameItem).gameObject.SetActive(true);
                PlayerPrefs.SetString("IsFullSet", Button.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().nameItem);
                PlayerPrefs.Save();
                FullSetSkinManager.instance.ButtonFullSetItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
                Button.Find("Border").gameObject.SetActive(true);
                FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FindPositionFullSetItem(Button.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().nameItem);

                FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(true);
                FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.CheckFullSet;
            }
            else
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
                Button.Find("Border").gameObject.SetActive(false);
            }

        }
    }
}
