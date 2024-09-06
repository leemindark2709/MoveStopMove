using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        //GameManager.Instance.FullSetSkin.gameObject.SetActive(true);
        //GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        //GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        //GameManager.Instance.TrousersSkin.GetComponent<TrousersSkinManager>().enableAll();
        //GameManager.Instance.ShieldSkin.GetComponent<ShieldSkinManager>().enableAll();
        //GameManager.Instance.FullSetSkin.GetComponent<FullSetSkinManager>().enableAll();
        //GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        //GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
        //GameManager.Instance.ShieldSkin.gameObject.SetActive(false);


        Debug.Log("Click duoc nha");

        if (GameManager.Instance.ShieldSkin.gameObject.activeSelf)
        {
            //ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[0];
            ////ShieldSkinManager.instance.IsShield= ShieldSkinManager.instance.ShieldItemPosition[2];
            ////ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
            //ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            if (ShieldSkinManager.instance.CheckShield != null)
            {
                ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);

            }
            ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);


        }
        if (GameManager.Instance.TrousersSkin.gameObject.activeSelf)
        {
            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[0];
            FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;


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




        GameManager.Instance.HairSkin.gameObject.SetActive(true);
        if (HairSkinManager.instance.IsHair == HairSkinManager.instance.HairItemPosition[4])
        {
            Debug.Log("NOOO");


            //ShieldSkinManager.instance.ButtonShieldItemClick = ShieldSkinManager.instance.ButtonShieldItemChose;
            //if (ShieldSkinManager.instance.ButtonShieldItemChose != null)
            //{
            //    GameManager.Instance.ShieldSelectUnequip.Find("SelectShieldItem").gameObject.SetActive(false);
            //    GameManager.Instance.ShieldSelectUnequip.Find("UnequipShieldItem").gameObject.SetActive(true);

            //}

            //HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            HairSkinManager.instance.CheckHair = HairSkinManager.instance.HairItemPosition[3];
            HairSkinManager.instance.CheckHair.gameObject.SetActive(true);

            HairSkinManager.instance.disableAllPanel();
            HairSkinManager.instance.HairItemButtons[0].Find("Border").gameObject.SetActive(true);
            HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.HairItemButtons[0];
            HairSkinManager.instance.ButtonHairItemChose = null;
            GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.Find("ADSHairItem").gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.Find("GoldHairItem").gameObject.SetActive(false);
            GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(true);
        }
        if (HairSkinManager.instance.IsHair != HairSkinManager.instance.HairItemPosition[4])
        {
            Debug.Log("okokokokok");
            ////HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            HairSkinManager.instance.IsHair.gameObject.SetActive(true);
            HairSkinManager.instance.ButtonHairItemClick = HairSkinManager.instance.ButtonHairItemChose;
            GameManager.Instance.HairSelectUnequip.Find("UnequipHairItem").gameObject.SetActive(true);
            GameManager.Instance.HairSelectUnequip.Find("SelectHairItem").gameObject.SetActive(false);

        }



        GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        GameManager.Instance.PanelHairButton.gameObject.SetActive(false);
        GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);
        GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
        GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);

        GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.HairSelectUnequip.gameObject.SetActive(true);
        GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);

        foreach (Transform item in HairSkinManager.instance.HairItemButtons)
        {
            if (HairSkinManager.instance.ButtonHairItemChose == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                != HairSkinManager.instance.ButtonHairItemChose.GetComponent<RectTransform>())
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