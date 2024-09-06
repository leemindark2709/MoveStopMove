using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HairSkinManager : MonoBehaviour
{
    public static HairSkinManager instance;
    public List<Transform> HairItemButtons = new List<Transform>();
    public List<Transform> HairItemPosition = new List<Transform>();
    public Transform Player;
    public Transform CheckHair;
    public Transform IsHair;
    public Transform ButtonHairItemClick ;
    public Transform ButtonHairItemChose;
    private void Awake()
    {

        Player = GameManager.Instance.PLayer;
        int index = 0;
        foreach (Transform t in transform)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
            HairItemButtons.Add(t);
            if (t.Find("BackGround").GetComponent<ButtonItemHairSkin>().nameItem== PlayerPrefs.GetString("IsHair", "NoneHair"))
            {
                ButtonHairItemChose = t;
                t.Find("EquippedText").gameObject.SetActive(true);

            }
            if (index != 0)
            {
                t.Find("Border").gameObject.SetActive(false);
            }

            index++; // Increment the index

        }
        HairItemPosition.Add(FindPositionHariItem("Arrow"));
        HairItemPosition.Add(FindPositionHariItem("Crown"));
        HairItemPosition.Add(FindPositionHariItem("headphone"));
        HairItemPosition.Add(FindPositionHariItem("Rau"));
        HairItemPosition.Add(FindPositionHariItem("NoneHair"));
        DisableHair();
        IsHair = FindPositionHariItem(PlayerPrefs.GetString("IsHair", "NoneHair"));
        if (transform.name=="HairSkin")
        {
            GameManager.Instance.HairSkin.GetComponent<HairSkinManager>().ButtonHairItemClick
= GameManager.Instance.HairSkin.GetComponent<HairSkinManager>().HairItemButtons[0];

        }
 
        //ButtonHairItemClick = HairItemButtons[i];
        instance = this;
    }
    private void Update()
    {
        //if (CheckHair == null)
        //{
        //    CheckHair = HairItemPosition[3];
        //    CheckHair.gameObject.SetActive(true);
        //}

    }
    private void Start()
    {
        //CheckHair.gameObject.SetActive(true);
        
        

    }
   
    public void DisableHair()
    {
        foreach (Transform item in HairItemPosition)
        {
            item.gameObject.SetActive(false);
        }
    }
    public void DisableEquippedText()
    {
        foreach (Transform t in HairItemButtons)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
        }
    }

    public Transform FindPositionHariItem(string nameItem)
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
    public void disableAllPanel()
    {

        foreach (Transform t in HairItemButtons)
        {
            t.Find("Border").gameObject.SetActive(false);
        }

    }
    public void enableAll()
    {
        CharSkinManager.instance.SelectHairItem.gameObject.SetActive(true);
        CharSkinManager.instance.UnequipHairItem.gameObject.SetActive(false);
        HairSkinManager.instance.DisableHair();
        HairSkinManager.instance.CheckHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        HairSkinManager.instance.IsHair = HairSkinManager.instance.FindPositionHariItem("NoneHair");
        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in HairSkinManager.instance.HairItemButtons)
        {
            if (Button == HairSkinManager.instance.ButtonHairItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }
    }
}
