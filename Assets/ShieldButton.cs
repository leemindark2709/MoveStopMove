using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Click duoc nha");

        if (GameManager.Instance.HairSkin.gameObject.activeSelf)
        {
            //ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[0];
            ////ShieldSkinManager.instance.IsShield= ShieldSkinManager.instance.ShieldItemPosition[2];
            ////ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
            //ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            if (HairSkinManager.instance.CheckHair != null)
            {
                HairSkinManager.instance.CheckHair.gameObject.SetActive(false);

            }
            HairSkinManager.instance.IsHair.gameObject.SetActive(false);


        }


        if (GameManager.Instance.TrousersSkin.gameObject.activeSelf)
        {

            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
            FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
        }


        GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        if (ShieldSkinManager.instance.IsShield == ShieldSkinManager.instance.ShieldItemPosition[2])
        {
            Debug.Log("NOOO");

            //HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.ButtonHairItemChose;
            //if (HairSkinManager.instance.ButtonHairItemChose!=null)
            //{
            //    GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(false);
            //    GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(true);

            //}
            GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(false);
            GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(true);
            ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[1];
            ShieldSkinManager.instance.CheckShield.gameObject.SetActive(true);

            ShieldSkinManager.instance.disableAllPanel();
            ShieldSkinManager.instance.ShieldItemButtons[0].Find("Border").gameObject.SetActive(true);
            ShieldSkinManager.instance.ButtonShieldItemClick = ShieldSkinManager.instance.ShieldItemButtons[0];
            ShieldSkinManager.instance.ButtonShieldItemChose = null;
        }
        if (ShieldSkinManager.instance.IsShield != ShieldSkinManager.instance.ShieldItemPosition[2])
        {
            Debug.Log("okokokokok");
            ////HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            //HairSkinManager.instance.IsHair.gameObject.SetActive(true);
            ShieldSkinManager.instance.IsShield.gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(true);
            GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(false);

        }


        if (GameManager.Instance.FullSetSkin.gameObject.activeSelf)
        {
            if (FullSetSkinManager.instance.CheckFullSet != null)
            {
                FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false);

            }
            FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false);
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;
        }


        GameManager.Instance.HairSkin.gameObject.SetActive(false);
        GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false);

        GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
        GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);
        GameManager.Instance.PanelShieldButton.gameObject.SetActive(false);
        GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);

        GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(true);
        GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);

        foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (ShieldSkinManager.instance.ShieldItemButtons == null) return;
            if (ShieldSkinManager.instance.ButtonShieldItemChose == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                != ShieldSkinManager.instance.ButtonShieldItemChose.GetComponent<RectTransform>())
            {
                Debug.Log("click");
                item.Find("Border").gameObject.SetActive(false);
                //item.Find("Border").gameObject.SetActive(true);

            }
            else
            {
                item.Find("Border").gameObject.SetActive(true);

            }

        }
    }
}
