using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSetButton : MonoBehaviour
{
    public void OnButtonClick()
    {
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
