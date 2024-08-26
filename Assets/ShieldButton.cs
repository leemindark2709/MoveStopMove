using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Click duoc nha");
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
        GameManager.Instance.FullSetSelectUnequip.gameObject.SetActive(true);

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
