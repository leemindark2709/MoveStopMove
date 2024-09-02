using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrousersButton : MonoBehaviour
{
    public void OnButtonClick()
    {

        //GameManager.Instance.FullSetSkin.gameObject.SetActive(true);
        //GameManager.Instance.HairSkin.gameObject.SetActive(true);
        //GameManager.Instance.ShieldSkin.gameObject.SetActive(true);
        //GameManager.Instance.HairSkin.GetComponent<HairSkinManager>().enableAll();
        //GameManager.Instance.ShieldSkin.GetComponent<ShieldSkinManager>().enableAll();
        //GameManager.Instance.FullSetSkin.GetComponent<FullSetSkinManager>().enableAll();
        //GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        //GameManager.Instance.HairSkin.gameObject.SetActive(false);
        //GameManager.Instance.ShieldSkin.gameObject.SetActive(false);

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

        if (GameManager.Instance.FullSetSkin.gameObject.activeSelf)
        {
            if (FullSetSkinManager.instance.CheckFullSet != null)
            {
                FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false);

            }
            FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false);
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;
        }



        FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = GameManager.Instance.Pants;
        GameManager.Instance.TrousersSkin.gameObject.SetActive(true);
        if (TrousersSkinManager.instance.IsTrousers == TrousersSkinManager.instance.materials[0])
        {
            Debug.Log("NOOO");

            //TrousersSkinManager.instance.ButtonTrousersItemClick = TrousersSkinManager.instance.ButtonTrousersItemChose;
            //if (TrousersSkinManager.instance.ButtonTrousersItemChose != null)
            //{
            //    GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousersItem").gameObject.SetActive(false);
            //    GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousersItem").gameObject.SetActive(true);
            //}

            TrousersSkinManager.instance.CheckTrousers = TrousersSkinManager.instance.materials[0];
            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.materials[2];

           TrousersSkinManager.instance.disableAllPanel();
            TrousersSkinManager.instance.TrousersItemButtons[0].Find("Border").gameObject.SetActive(true);
            TrousersSkinManager.instance.ButtonTrousersItemClick = TrousersSkinManager.instance.TrousersItemButtons[0];
            if (!TrousersSkinManager.instance.ButtonTrousersItemClick.Find("BackGround").GetComponent<ButtonItemTrousersSkin>().IsUnlock)
            {
                GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(false);
                GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(false);
                GameManager.Instance.TrousersSelectUnequip.Find("ADSTrousersItem").gameObject.SetActive(true);
                GameManager.Instance.TrousersSelectUnequip.Find("GoldTrousersItem").gameObject.SetActive(true);


            }
            TrousersSkinManager.instance.ButtonTrousersItemChose = null;



        }
        if (TrousersSkinManager.instance.IsTrousers !=  TrousersSkinManager.instance.materials[0])
        {
            Debug.Log("okokokokok");
            ////TrousersSkinManager.instance.CheckTrousers.gameObject.SetActive(false);
            TrousersSkinManager.instance.pantsRenderer.material = TrousersSkinManager.instance.IsTrousers;
            GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(true);
            GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(false);

        }





        //Debug.Log("Click duoc nha");
        GameManager.Instance.HairSkin.gameObject.SetActive(false);
      
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(false);
        GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
        GameManager.Instance.PanelTrousersButton.gameObject.SetActive(false);
        GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
        GameManager.Instance.PanelFullSetButton.gameObject.SetActive(true);

        GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(true);
        GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(false);

        foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (TrousersSkinManager.instance.TrousersItemButtons == null) return;
            if (TrousersSkinManager.instance.ButtonTrousersItemChose == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                != TrousersSkinManager.instance.ButtonTrousersItemChose.GetComponent<RectTransform>())
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
