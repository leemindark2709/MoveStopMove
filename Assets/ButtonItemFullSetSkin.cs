using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonItemFullSetSkin : MonoBehaviour
{
    public bool isClickButtonItem;
    public string nameItem;
    public Material material;

    public void OnButtonClick()
    {
        FullSetSkinManager.instance.ButtonFullSetItemClick = transform.parent;
        FullSetSkinManager.instance.DisableFullSet();
        FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FindPositionFullSetItem(nameItem);
        FullSetSkinManager.instance.FindPositionFullSetItem(nameItem).gameObject.SetActive(true);
        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material=material;
        FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh = null;

        //FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.FindPositionFullSetItem(nameItem);

        foreach (Transform item in FullSetSkinManager.instance.FullSetItemButtons)
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

        if (FullSetSkinManager.instance.IsFullSet == FullSetSkinManager.instance.FindPositionFullSetItem(nameItem))
        {
            CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(false);
            CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(true);
        }
        else
        {
            CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(true);
            CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(false);
        }
    }

}
