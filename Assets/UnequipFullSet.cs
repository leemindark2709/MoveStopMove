using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnequipFullSet : MonoBehaviour
{
    public void OnButtonClick()
    {
        CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(true);
        CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(false);
        //HairSkinManager.instance.DisableHair();
        //HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        //HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");

        //FullSetSkinManager.instance.pantsRenderer.material = FullSetSkinManager.instance.materials[0];

        FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false);
        FullSetSkinManager.instance.IsFullSet= FullSetSkinManager.instance.FullSetItemPosition[0];
        FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[1];
        FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material
            = GameManager.Instance.Yeallow;
        FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh 
            =GameManager.Instance.Pants;
        FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.FullSetItemPosition[0];
        FullSetSkinManager.instance.ButtonFullSetItemChose = null;
        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        PlayerPrefs.SetString("IsFullSet", "NoneFullSet");
        PlayerPrefs.Save();
        foreach (Transform Button in FullSetSkinManager.instance.FullSetItemButtons)
        {
            if (Button == FullSetSkinManager.instance.ButtonFullSetItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }


    }
}
