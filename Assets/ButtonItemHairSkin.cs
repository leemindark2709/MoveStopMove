using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItemHairSkin : MonoBehaviour
{
    public bool isClickButtonItem;
    public string nameItem;
    public bool IsUnlock;
    public Transform Lock;
    public int Price;
    public void OnButtonClick()
    {
        HairSkinManager.instance.ButtonHairItemClick=transform.parent;
        HairSkinManager.instance.DisableHair();
        HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem(nameItem);
        HairSkinManager.instance.FindPositionHariItem(nameItem).gameObject.SetActive(true);
        //HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem(nameItem);
        foreach (Transform item in HairSkinManager.instance.HairItemButtons)
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
        if (HairSkinManager.instance.IsHair == HairSkinManager.instance.FindPositionHariItem(nameItem))
        {
            CharSkinManager.instance.SelectHairItem.gameObject.SetActive(false);
            CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(true);
        }
        else
        {
            CharSkinManager.instance.SelectHairItem.gameObject.SetActive(true);
            CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(false);
        }

        if (!IsUnlock)
        {
            CharSkinManager.instance.SelectHairItem.gameObject.SetActive(false);
            CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(false);
            CharSkinManager.instance.ADSHairItem.gameObject.SetActive(true);
            CharSkinManager.instance.GoldHairItem.gameObject.SetActive(true);
        }
        else
        {
            CharSkinManager.instance.ADSHairItem.gameObject.SetActive(false);
            CharSkinManager.instance.GoldHairItem.gameObject.SetActive(false);
        }
    }
}
