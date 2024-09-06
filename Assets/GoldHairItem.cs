using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GoldHairItem : MonoBehaviour
{
    public void OnButtonClick()
    {


        HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        //HairSkinManager.instance.IsHair = HairSkinManager.instance.CheckHair;
        CharSkinManager.instance.SelectHairItem.gameObject.SetActive(false);
        CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(true);
       



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


        GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        TrousersSkinManager.instance.disableAllPanel();
        TrousersSkinManager.instance.DisableEquippedText();
        TrousersSkinManager.instance.IsTrousers = TrousersSkinManager.instance.materials[0];
        PlayerPrefs.SetString("IsTrousers", "Yealow");
        PlayerPrefs.Save();
        TrousersSkinManager.instance.CheckTrousers = TrousersSkinManager.instance.materials[0];
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
        PlayerPrefs.SetString("IsFullSet", "NoneFullSet");
        PlayerPrefs.Save();
        FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[1];
        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;
        FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false); // Changed IsHair to IsFullSet
        FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false); // Changed CheckHair to CheckFullSet
        FullSetSkinManager.instance.ButtonFullSetItemClick = FullSetSkinManager.instance.FullSetItemButtons[0]; // Changed ButtonHairItemClick to ButtonFullSetItemClick and HairItemButtons to FullSetItemButtons
        FullSetSkinManager.instance.ButtonFullSetItemChose = null; // Changed ButtonHairItemChose to ButtonFullSetItemChose
        GameManager.Instance.FullSetSelectUnequip.Find("SelectFullSetItem").gameObject.SetActive(true); // Changed HairSelectUnequip to FullSetSelectUnequip and SelectHairItem to SelectFullSetItem
        GameManager.Instance.FullSetSelectUnequip.Find("UnequipFullSetItem").gameObject.SetActive(false); // Changed HairSelectUnequip to FullSetSelectUnequip and UnequipHairItem to UnequipFullSetItem
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false); // Changed HairSkin to FullSetSkin

        //if (GameManager.Instance.Gold)
        //{

        //}

        foreach (Transform Button in HairSkinManager.instance.HairItemButtons)
        {
            if (Button == HairSkinManager.instance.ButtonHairItemClick)
            {
              

                //HairSkinManager.instance.ButtonHairItemClick.Find("Lock").gameObject.SetActive(false);

                HairSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem).gameObject.SetActive(true);
               
                // Tìm đối tượng với tên "Lock"
                Transform lockTransform = Button.Find("Lock");

             
                if (lockTransform != null&&GameManager.Instance.Gold >= HairSkinManager.instance.ButtonHairItemClick.Find("BackGround").GetComponent<ButtonItemHairSkin>().Price)
                {
                    GameManager.Instance.Gold -= HairSkinManager.instance.ButtonHairItemClick.Find("BackGround").GetComponent<ButtonItemHairSkin>().Price;


                    HairSkinManager.instance.ButtonHairItemClick.Find("BackGround").GetComponent<ButtonItemHairSkin>().IsUnlock = true;
                    //PlayerPrefs.SetString("")
                    PlayerPrefs.SetInt(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem, 1); // Lưu cấp độ nhân vật
                    PlayerPrefs.SetString("IsHair", Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem);


                    PlayerPrefs.Save(); // Lưu dữ liệu ngay lập tức để đảm bảo an toàn

                    HairSkinManager.instance.ButtonHairItemChose = Button;
                   
                    Button.Find("EquippedText").gameObject.SetActive(true);
                    // Nếu tìm thấy, đặt đối tượng "Lock" không hoạt động
                    lockTransform.gameObject.SetActive(false);
                    CharSkinManager.instance.ADSHairItem.gameObject.SetActive(false);
                    CharSkinManager.instance.GoldHairItem.gameObject.SetActive(false);
                    HairSkinManager.instance.IsHair = HairSkinManager.instance.CheckHair;

                }
                else
                {
                    CharSkinManager.instance.SelectHairItem.gameObject.SetActive(false);
                    CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(false);

                }

                Button.Find("Border").gameObject.SetActive(true);
                HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem(Button.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem);

                HairSkinManager.instance.CheckHair.gameObject.SetActive(true);

            }
            else
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
                Button.Find("Border").gameObject.SetActive(false);
            }

        }
        HairSkinManager.instance.DisableEquippedText();
        if (HairSkinManager.instance.ButtonHairItemChose!=null)
        {
            HairSkinManager.instance.ButtonHairItemChose.Find("EquippedText").gameObject.SetActive(true);

        }


    }
}
