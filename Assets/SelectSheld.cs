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



        GameManager.Instance.FullSetSkin.gameObject.SetActive(true); // Changed HairSkin to FullSetSkin
        FullSetSkinManager.instance.disableAllPanel(); // Changed HairSkinManager to FullSetSkinManager
        FullSetSkinManager.instance.DisableEquippedText(); // Changed HairSkinManager to FullSetSkinManager
        FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.FullSetItemPosition[0];
        FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[1];
        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;

        PlayerPrefs.SetString("IsFullSet", "NoneFullSet");
        PlayerPrefs.Save();
        FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false); // Changed IsHair to IsFullSet
        FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false); // Changed CheckHair to CheckFullSet
        FullSetSkinManager.instance.ButtonFullSetItemClick = FullSetSkinManager.instance.FullSetItemButtons[0]; // Changed ButtonHairItemClick to ButtonFullSetItemClick and HairItemButtons to FullSetItemButtons
        FullSetSkinManager.instance.ButtonFullSetItemChose = null; // Changed ButtonHairItemChose to ButtonFullSetItemChose
        GameManager.Instance.FullSetSelectUnequip.Find("SelectFullSetItem").gameObject.SetActive(true); // Changed HairSelectUnequip to FullSetSelectUnequip and SelectHairItem to SelectFullSetItem
        GameManager.Instance.FullSetSelectUnequip.Find("UnequipFullSetItem").gameObject.SetActive(false); // Changed HairSelectUnequip to FullSetSelectUnequip and UnequipHairItem to UnequipFullSetItem
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false); // Changed HairSkin to FullSetSkin




        foreach (Transform Button in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (Button == ShieldSkinManager.instance.ButtonShieldItemClick)
            {
                ShieldSkinManager.instance.FindPositionShieldItem(Button.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem).gameObject.SetActive(true);
                PlayerPrefs.SetString("IsShield", Button.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem);
                PlayerPrefs.Save();
                ShieldSkinManager.instance.ButtonShieldItemChose = Button;
                Button.Find("EquippedText").gameObject.SetActive(true);
                Button.Find("Border").gameObject.SetActive(true);
                ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.FindPositionShieldItem(Button.Find("BackGround").GetComponent<ButtonItemShieldSkin>().nameItem);

                ShieldSkinManager.instance.CheckShield.gameObject.SetActive(true);
                ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.CheckShield;
            }
            else
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
                Button.Find("Border").gameObject.SetActive(false);
            }


        }
    }
}
