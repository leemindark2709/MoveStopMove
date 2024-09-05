using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItemTrousersSkin : MonoBehaviour
{
    public bool isClickButtonItem;
    public string nameItem;
    public bool IsUnlock;
    public Transform Lock;
    public int Price;
    public Material material;
    public void OnButtonClick()
    {

        //TrousersSkinManager.instance.ButtonTrousersItemChose = transform.parent;
        //TrousersSkinManager.instance.ButtonTrousersItemClick = transform.parent;

        //TrousersSkinManager.instance.CheckTrousers = HairSkinManager.instance.FindPositionHariItem(nameItem);
        //TrousersSkinManager.instance.FindPositionHariItem(nameItem).gameObject.SetActive(true);
        //TrousersSkinManager.instance.IsTrousers = HairSkinManager.instance.FindPositionHariItem(nameItem);
        TrousersSkinManager.instance.ButtonTrousersItemClick = transform.parent;
        TrousersSkinManager.instance.CheckTrousers = material;
        TrousersSkinManager.instance.FindPositionHariItem("Pants").GetComponent<Renderer>().material
           = TrousersSkinManager.instance.CheckTrousers;
        
        foreach (Transform item in TrousersSkinManager.instance.TrousersItemButtons)
        {
            if (item.Find("BackGround").gameObject != this.gameObject)
            {
                Debug.Log("click");
                item.Find("Border").gameObject.SetActive(false);
                //item.Find("Border").gameObject.SetActive(true);
                TrousersSkinManager.instance.pantsRenderer.material = material;

            }
            else
            {
                item.Find("Border").gameObject.SetActive(true);

            }

        }
        if (TrousersSkinManager.instance.IsTrousers == TrousersSkinManager.instance.CheckTrousers)
        {
            CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(false);
            CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(true);
        }
        else
        {
            CharSkinTrouserManager.instance.SelectTrousersItem.gameObject.SetActive(true);
            CharSkinTrouserManager.instance.UnequipTrousersItem.gameObject.SetActive(false);
        }
        if (!IsUnlock)
        {
            GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("ADSTrousersItem").gameObject.SetActive(true);
            GameManager.Instance.TrousersSelectUnequip.Find("GoldTrousersItem").gameObject.SetActive(true);
        }
        else
        {
            //GameManager.Instance.TrousersSelectUnequip.Find("UnequipTrousers").gameObject.SetActive(false);
            //GameManager.Instance.TrousersSelectUnequip.Find("SelectTrousers").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("ADSTrousersItem").gameObject.SetActive(false);
            GameManager.Instance.TrousersSelectUnequip.Find("GoldTrousersItem").gameObject.SetActive(false);
        }
    }
}
