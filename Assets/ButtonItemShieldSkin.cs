using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItemShieldSkin : MonoBehaviour
{
    public bool isClickButtonItem;
    public string nameItem;

    public void OnButtonClick()
    {
        ShieldSkinManager.instance.ButtonShieldItemClick = transform.parent;
        ShieldSkinManager.instance.DisableShield();
        ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.FindPositionShieldItem(nameItem);
        ShieldSkinManager.instance.FindPositionShieldItem(nameItem).gameObject.SetActive(true);
        //ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.FindPositionShieldItem(nameItem);

        foreach (Transform item in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (item.Find("BackGround").gameObject != this.gameObject)
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

        if (ShieldSkinManager.instance.IsShield == ShieldSkinManager.instance.FindPositionShieldItem(nameItem))
        {
            CharSkinManagerShield.instance.SelectShieldItem.gameObject.SetActive(false);
            CharSkinManagerShield.instance.UnequipShieldItem.gameObject.SetActive(true);
        }
        else
        {
            CharSkinManagerShield.instance.SelectShieldItem.gameObject.SetActive(true);
            CharSkinManagerShield.instance.UnequipShieldItem.gameObject.SetActive(false);
        }
    }

}
