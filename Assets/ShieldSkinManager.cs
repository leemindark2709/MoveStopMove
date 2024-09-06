using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkinManager : MonoBehaviour
{
    public static ShieldSkinManager instance;
    public List<Transform> ShieldItemButtons = new List<Transform>();
    public List<Transform> ShieldItemPosition = new List<Transform>();
    public Transform Player;
    public Transform CheckShield;
    public Transform IsShield;
    public Transform ButtonShieldItemClick;
    public Transform ButtonShieldItemChose;

    private void Awake()
    {
        //CheckShield.gameObject.SetActive(true);

        Player = GameManager.Instance.PLayer;
        int index = 0;
        foreach (Transform t in transform)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
            ButtonShieldItemChose = t;
            ShieldItemButtons.Add(t);
            if (index != 0)
            {
                t.Find("Border").gameObject.SetActive(false);
            }

            index++; // Increment the index
        }
        ShieldItemPosition.Add(FindPositionShieldItem("ShieldBlack"));
        ShieldItemPosition.Add(FindPositionShieldItem("ShieldCaptain"));
        ShieldItemPosition.Add(FindPositionShieldItem("NoneShield"));
        DisableShield();
        IsShield = FindPositionShieldItem((PlayerPrefs.GetString("IsShield", "NoneHair")));

        if (transform.name == "ShieldSkin")
        {
            GameManager.Instance.ShieldSkin.GetComponent<ShieldSkinManager>().ButtonShieldItemClick
= GameManager.Instance.ShieldSkin.GetComponent<ShieldSkinManager>().ShieldItemButtons[0];

        }
        instance = this;
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

        foreach (Transform t in ShieldItemButtons)
        {
            t.Find("Border").gameObject.SetActive(false);
        }

    }
    public void DisableShield()
    {
        foreach (Transform item in ShieldItemPosition)
        {
            item.gameObject.SetActive(false);
        }
    }

    public void DisableEquippedText()
    {
        foreach (Transform t in ShieldItemButtons)
        {
            t.Find("EquippedText").gameObject.SetActive(false);
        }
    }

    public Transform FindPositionShieldItem(string nameItem)
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
        CharSkinManagerShield.instance.SelectShieldItem.gameObject.SetActive(true);
        CharSkinManagerShield.instance.UnequipShieldItem.gameObject.SetActive(false);
        ShieldSkinManager.instance.DisableShield();
        ShieldSkinManager.instance.CheckShield = ShieldSkinManager.instance.FindPositionShieldItem("NoneShield");
        ShieldSkinManager.instance.IsShield = ShieldSkinManager.instance.FindPositionShieldItem("NoneShield");
        //HairSkinManager.instance.CheckHair.gameObject.SetActive(true);
        foreach (Transform Button in ShieldSkinManager.instance.ShieldItemButtons)
        {
            if (Button == ShieldSkinManager.instance.ButtonShieldItemClick)
            {
                Button.Find("EquippedText").gameObject.SetActive(false);
            }

        }

    }

}
