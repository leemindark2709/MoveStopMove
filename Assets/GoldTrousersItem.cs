using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTrousersItem : MonoBehaviour
{
    public void OnButtonClick()
    {
        //TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.CheckTrousers;
        //TrousersSkinManager.instance.CheckHair.gameObject.SetActive(true);
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;
        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        //TrousersSkinManager.instance.DisableEquippedText();


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

        GameManager.Instance.FullSetSkin.gameObject.SetActive(true); // Changed HairSkin to FullSetSkin
        FullSetSkinManager.instance.disableAllPanel(); // Changed HairSkinManager to FullSetSkinManager
        FullSetSkinManager.instance.DisableEquippedText(); // Changed HairSkinManager to FullSetSkinManager
        FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.FullSetItemPosition[0];
        FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[1];
        PlayerPrefs.SetString("IsFullSet", "NoneFullSet");
        PlayerPrefs.Save();
        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;
        FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false); // Changed IsHair to IsFullSet
        FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false); // Changed CheckHair to CheckFullSet
        FullSetSkinManager.instance.ButtonFullSetItemClick = FullSetSkinManager.instance.FullSetItemButtons[0]; // Changed ButtonHairItemClick to ButtonFullSetItemClick and HairItemButtons to FullSetItemButtons
        FullSetSkinManager.instance.ButtonFullSetItemChose = null; // Changed ButtonHairItemChose to ButtonFullSetItemChose
        GameManager.Instance.FullSetSelectUnequip.Find("SelectFullSetItem").gameObject.SetActive(true); // Changed HairSelectUnequip to FullSetSelectUnequip and SelectHairItem to SelectFullSetItem
        GameManager.Instance.FullSetSelectUnequip.Find("UnequipFullSetItem").gameObject.SetActive(false); // Changed HairSelectUnequip to FullSetSelectUnequip and UnequipHairItem to UnequipFullSetItem
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false); // Changed HairSkin to FullSetSkin





        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.CheckTrousers;

        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.CheckHair;

        CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        TrousersSkinManager.instance.DisableEquippedText();

        CharSkinTrouserManager.instance.ADSTrousersItem.gameObject.SetActive(false);
        CharSkinTrouserManager.instance.GoldTrousersItem.gameObject.SetActive(false);







        foreach (Transform Button in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (Button == TrousersSkinManager.instance.ButtonTrousersItemClick)
            {


                Transform lockTransform = Button.Find("Lock");

                if (lockTransform != null && GameManager.Instance.Gold >= TrousersSkinManager.instance.ButtonTrousersItemClick.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Price)

                {
                    GameManager.Instance.Gold -= TrousersSkinManager.instance.ButtonTrousersItemClick.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().Price;

                    TrousersSkinManager.instance.ButtonTrousersItemClick.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock = true;
                    TrousersSkinManager.instance.ButtonTrousersItemChose = Button;
                    PlayerPrefs.SetInt(Button.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem, 1); // Lưu cấp độ nhân vật
                    PlayerPrefs.SetString("IsTrousers", Button.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem);
                    Debug.Log(PlayerPrefs.GetString("IsTrousers", Button.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().nameItem));

                    PlayerPrefs.Save(); // Lưu dữ liệu ngay lập tức để đảm bảo an toàn

                    //HairSkinManager.instance.ButtonHairItemChose = Button;

                    Button.Find("EquippedText").gameObject.SetActive(true);

                    //Button.Find("EquippedText").gameObject.SetActive(true);
                    lockTransform.gameObject.SetActive(false);

                    CharSkinTrouserManager.instance.ADSTrousersItem.gameObject.SetActive(false);
                    CharSkinTrouserManager.instance.GoldTrousersItem.gameObject.SetActive(false);

                }
                else
                {
                    CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
                    CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(false);

                }

                Button.Find("Border").gameObject.SetActive(true);
                //TrousersSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<TrousersSkinManager>().nameItem).gameObject.SetActive(true);


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
        TrousersSkinManager.instance.DisableEquippedText();
        if (TrousersSkinManager.instance.ButtonTrousersItemChose != null)
        {
            TrousersSkinManager.instance.ButtonTrousersItemChose.Find("EquippedText").gameObject.SetActive(true);

        }
    }
}
