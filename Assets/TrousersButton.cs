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
            ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);


        }

        if (GameManager.Instance.HairSkin.gameObject.activeSelf)
        {
            //ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.ShieldItemPosition[0];
            ////ShieldSkinManager.instance.IsShield= ShieldSkinManager.instance.ShieldItemPosition[2];
            ////ShieldSkinManager.instance.IsShield.gameObject.SetActive(false);
            //ShieldSkinManager.instance.CheckShield.gameObject.SetActive(false);
            HairSkinManager.instance.CheckHair.gameObject.SetActive(false);
            HairSkinManager.instance.IsHair.gameObject.SetActive(false);




        }
        GameManager.Instance.TrousersSkin.gameObject.SetActive(true);





        Debug.Log("Click duoc nha");
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
