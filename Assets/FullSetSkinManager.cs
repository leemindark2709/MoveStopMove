using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSetSkinManager : MonoBehaviour
{
    public static FullSetSkinManager instance;
    public List<Transform> FullSetItemButtons = new List<Transform>();
    public List<Transform> FullSetItemPosition = new List<Transform>();
    public Transform Player;
    public Transform CheckFullSet;
    public Transform IsFullSet;
    public Transform ButtonFullSetItemClick;
    public Transform ButtonFullSetItemChose;

    private void Awake()
    {
        instance = this;
        //CheckShield.gameObject.SetActive(true);

        //Player = GameManager.Instance.PLayer;
        int index = 0;
        foreach (Transform t in transform)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
            ButtonFullSetItemChose = t;
            FullSetItemButtons.Add(t);
            if (index != 0)
            {
                t.Find("Border").gameObject.SetActive(false);
            }

            index++; // Increment the index
        }

        //DisableFullSet();
        IsFullSet = FindPositionFullSetItem(PlayerPrefs.GetString("IsFullSet", "NoneFullSet"));
    }

    private void Update()
    {
        //if (CheckShield == null)
        //{
        //    CheckShield = ShieldItemPosition[3];
        //    CheckShield.gameObject.SetActive(true);
        //}
    }

    private void Start()
    {
    

       
    }
    public void disableAllPanel()
    {

        foreach (Transform t in FullSetItemButtons)
        {
            t.Find("Border").gameObject.SetActive(false);
        }

    }
    public void DisableFullSet()
    {
        foreach (Transform item in FullSetItemPosition)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void DisableEquippedText()
    {
        foreach (Transform t in FullSetItemButtons)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
        }
    }

    public Transform FindPositionFullSetItem(string nameItem)
    {
        return FindInChildren(Player.transform, nameItem);
    }

    private Transform FindInChildren(Transform parent, string nameItem)
    {
        foreach (Transform child in parent)
        {
            if (child.name == nameItem)
            {
                return child;
            }

            Transform found = FindInChildren(child, nameItem); // Gọi đệ quy
            if (found != null)
            {
                return found;
            }
        }
        return null; // Không tìm thấy
    }
    public void enableAll()
    {
        foreach (Transform t in FullSetItemPosition)
        {

            CharSkinManagerFullSet.instance.SelectFullSetItem.gameObject.SetActive(true);
            CharSkinManagerFullSet.instance.UnequipFullSetItem.gameObject.SetActive(false);
            //HairSkinManager.instance.DisableHair();
            //HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
            //HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");

            //FullSetSkinManager.instance.pantsRenderer.material = FullSetSkinManager.instance.materials[0];

            FullSetSkinManager.instance.IsFullSet.gameObject.SetActive(false);
            FullSetSkinManager.instance.IsFullSet = FullSetSkinManager.instance.FullSetItemPosition[2];
            FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[2];
            FullSetSkinManager.instance.CheckFullSet = FullSetSkinManager.instance.FullSetItemPosition[2];
            FullSetSkinManager.instance.FindPositionFullSetItem("initialShadingGroup1").GetComponent<Renderer>().material
                = GameManager.Instance.Yeallow;
            FullSetSkinManager.instance.FindPositionFullSetItem("Pants").GetComponent<SkinnedMeshRenderer>().sharedMesh
                = GameManager.Instance.Pants;
            //FullSetSkinManager.instance.IsFullSet = null;
            //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
            foreach (Transform Button in FullSetSkinManager.instance.FullSetItemButtons)
            {
                if (Button == FullSetSkinManager.instance.ButtonFullSetItemClick)
                {
                    Button.Find("EquippedText").gameObject.SetActive(false);
                }

            }
        }
    }
}
