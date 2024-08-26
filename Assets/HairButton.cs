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
        GameManager.Instance.HairSkin.gameObject.SetActive(true);
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
