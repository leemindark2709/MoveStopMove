using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSetButton : MonoBehaviour
{
    public void OnButtonClick()
    {





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
        }
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

        //if (GameManager.Instance.FullSetSkin.gameObject.activeSelf)
        //{
        //    FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false);
        //    FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false);
        //    FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material = GameManager.Instance.Yeallow;
        //}


        GameManager.Instance.FullSetSkin.gameObject.SetActive(true);
        FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;
        if (FullSetSkinManager.instance.IsFullSet == FullSetSkinManager.instance.FullSetItemPosition[0])
        {
            Debug.Log("NOOO");
            FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(false);
            FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[1];
            FullSetSkinManager.instance.CheckFullSet.gameObject.SetActive(true);
            FullSetSkinManager.instance.disableAllPanel();
            FullSetSkinManager.instance.ButtonFullSetItemClick = FullSetSkinManager.instance.FullSetItemButtons[0];
           
            FullSetSkinManager.instance.FullSetItemButtons[0].Find("Border").gameObject.SetActive(true);
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").gameObject.GetComponent<Renderer>().material
               = FullSetSkinManager.instance.FullSetItemButtons[0].Find("BackGround").GetComponent<ButtonItemFullSetSkin>().material;

            FullSetSkinManager.instance.ButtonFullSetItemChose = null;
        }

        if (FullSetSkinManager.instance.IsFullSet != FullSetSkinManager.instance.FullSetItemPosition[0])
        {
            Debug.Log("okokokokok");
            ////HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            //HairSkinManager.instance.IsHair.gameObject.SetActive(true);
            FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(true);
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").gameObject.GetComponent<Renderer>().material
               = FullSetSkinManager.instance.ButtonFullSetItemChose.Find("BackGround").GetComponent<ButtonItemFullSetSkin>().material;
        }






        Debug.Log("Click duoc nha");
        GameManager.Instance.HairSkin.gameObject.SetActive(false);
        GameManager.Instance.TrousersSkin.gameObject.SetActive(false);
        GameManager.Instance.ShieldSkin.gameObject.SetActive(false);
        GameManager.Instance.FullSetSkin.gameObject.SetActive(true);


        GameManager.Instance.PanelHairButton.gameObject.SetActive(true);
        GameManager.Instance.PanelTrousersButton.gameObject.SetActive(true);
        GameManager.Instance.PanelShieldButton.gameObject.SetActive(true);
        GameManager.Instance.PanelFullSetButton.gameObject.SetActive(false);

        GameManager.Instance.TrousersSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.HairSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.ShieldSelectUnequip.gameObject.SetActive(false);
        GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(true);


        foreach (Transform item in FullSetSkinManager.instance.FullSetItemButtons)
        {
            if (FullSetSkinManager.instance.FullSetItemButtons == null) return;
            if (FullSetSkinManager.instance.ButtonFullSetItemChose == null) return;
            if (item.gameObject.GetComponent<RectTransform>()
                !=FullSetSkinManager.instance.ButtonFullSetItemChose.GetComponent<RectTransform>())
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
